using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using ImageFilters;

namespace Experiments
{
	class MockJob : ICancellableJob
	{
		public Action CancelAction { get; set; }  // TODO: this should maybe be an event - Cancelled - but maybe not, it is invoked only once

		public Func<bool> ShouldCancelFunc { get; set; }

		public bool IsCancelled { get; private set; }

		public MockJob(int millisecondsTimeout)
		{
			_millisecondsTimeout = millisecondsTimeout;
		}

		public void Run()
		{
			Thread.Sleep(_millisecondsTimeout);
			if (ShouldCancelFunc != null && ShouldCancelFunc.Invoke())
			{
				CancelAction?.Invoke();
				IsCancelled = true;
			}
		}

		private readonly int _millisecondsTimeout;
	}


	class Program
	{
		private static Task RunActionAsync(Action action, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew(
				() =>
				{
					action.Invoke();
				},
				cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);
		}

		private static void CallTask()
		{
			var tokenSource = new CancellationTokenSource();
			CancellationToken ct = tokenSource.Token;

			var task = Task.Run(() =>
			{
				try
				{
					throw new OperationCanceledException(ct);
					ct.ThrowIfCancellationRequested();
					while (true)
					{
						if (ct.IsCancellationRequested)
						{
							ct.ThrowIfCancellationRequested();
						}
					}
				}
				catch (OperationCanceledException)
				{
					throw;
				}
			}, tokenSource.Token); // Pass same token to Task.Run.
			Thread.Sleep(500);
			tokenSource.Cancel();
			Console.WriteLine("Waiting");
			task.Wait();
		}

		private static void CallTask2()
		{
			var task1 = Task.Run(() => { throw new OperationCanceledException("This exception is expected!"); });


			try
			{
				task1.Wait();
			}
			catch (AggregateException ae)
			{
				foreach (var e in ae.InnerExceptions)
				{
					// Handle the custom exception.
					if (e is OperationCanceledException)
					{
						Console.WriteLine(e.Message);
					}
					// Rethrow any other exception.
					else
					{
						throw e;
					}
				}
			}
		}

		private static void CallTask3()
		{
			CancellationTokenSource tokenSource = new();
			ParallelOptions options = new()
			{
				TaskScheduler = TaskScheduler.Default,
				MaxDegreeOfParallelism = 4,
				CancellationToken = tokenSource.Token
			};
			Console.WriteLine($"Number of running threads: {Process.GetCurrentProcess().Threads.Count}");
			Task task = null;
			task = Task.Factory.StartNew(
				() =>
				{
					throw new OperationCanceledException(tokenSource.Token);
					Parallel.ForEach(Enumerable.Range(0, 5), options,
						x =>
						{
							Console.WriteLine($"Number of running threads: {Process.GetCurrentProcess().Threads.Count}");
							Console.WriteLine(x);
							tokenSource.Cancel();
						});
				},
				tokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
			try
			{
				task.Wait();
			}
			catch (AggregateException ae)
			{
				foreach (var e in ae.InnerExceptions)
				{
					// Handle the custom exception.
					if (e is OperationCanceledException)
					{
						Console.WriteLine(e.Message);
						Console.WriteLine("YES");
					}
					// Rethrow any other exception.
					else
					{
						throw e;
					}
				}
			}
		}

		private static IEnumerable<ImageProcessingJob> CreateJobs(string inputFilename, IEnumerable<IImageFilter> filters, int count)
		{
			var jobs = new ImageProcessingJob[count];
			for (int i = 0; i < count; i++)
			{
				jobs[i] = new ImageProcessingJob(inputFilename, $@"C:\Users\boles\Plocha\output\out-{i}.jpg", filters)
				{
					SuccessCallback = job => Console.WriteLine($"Successfully saved {job.InputFilename} to {job.OutputFilename}, in {Thread.CurrentThread.ManagedThreadId}"),
					FailCallback = (job, message) => Console.WriteLine($"Job failed: {message}, in {Thread.CurrentThread.ManagedThreadId}"),
					ShouldCancelFunc = () => false,
					CancelAction = () => Console.WriteLine("Canceled")
				};
			}
			return jobs;
		}

		static void Main(string[] args)
		{
			var filters = new IImageFilter[]
			{
				new FlipFilter(FlipType.Horizontal),
				new ColorAdjustingFilter(new RgbColorAdjuster(255, 0, 0)),
			};
			var jobs = CreateJobs(@"C:\Users\boles\Plocha\web-inspirace.jpg", filters, 100);
			var batchProcessor = new BatchProcessor(jobs, 4);
			batchProcessor.Run();
			Thread.Sleep(1000);
			batchProcessor.Cancel();
			try
			{
				batchProcessor.WaitForCompletion();
			}
			catch (AggregateException ae)
			{
				foreach (var e in ae.InnerExceptions)
				{
					if (e is OperationCanceledException)
					{
						Console.WriteLine(e.Message);
					}
					else
					{
						throw e;
					}
				}
			}
			/*
			var job = new ImageProcessingJob(@"C:\Users\boles\Plocha\web-inspirace.jpg", @"C:\Users\boles\Plocha\output.jpg", filters)
			{
				SuccessCallback = job => Console.WriteLine($"Successfully saved {job.InputFilename} to {job.OutputFilename}"),
				FailCallback = (job, message) => Console.WriteLine($"Job failed: {message}"),
				ShouldCancelFunc = () => false,
				CancelAction = () => Console.WriteLine("Canceled")
			};
			job.Run();
			*/
		}
	}
}
