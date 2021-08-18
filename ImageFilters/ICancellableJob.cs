using System;

namespace ImageFilters
{
	public interface ICancellableJob
	{
		Action CancelCallback { get; set; }

		Func<bool> ShouldCancelFunc { get; set; }

		bool IsCancelled { get; }

		void Run();
	}
}
