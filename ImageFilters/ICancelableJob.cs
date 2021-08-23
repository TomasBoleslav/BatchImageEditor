using System;

namespace ImageFilters
{
	/// <summary>
	/// A job that can be canceled using a delegate function.
	/// </summary>
	public interface ICancelableJob
	{
		/// <summary>
		/// Gets or sets an action that should be called after the job was canceled.
		/// </summary>
		Action CancelAction { get; set; }

		/// <summary>
		/// Gets or sets a function that will be used to check whether the job should be canceled.
		/// </summary>
		Func<bool> ShouldCancelFunc { get; set; }

		/// <summary>
		/// Gets an indicator whether the job was canceled.
		/// </summary>
		bool IsCanceled { get; }

		/// <summary>
		/// Runs the job.
		/// </summary>
		void Run();
	}
}
