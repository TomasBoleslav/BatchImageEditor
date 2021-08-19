using System;

namespace ImageFilters
{
	public interface ICancellableJob
	{
		Action CancelAction { get; set; }

		Func<bool> ShouldCancelFunc { get; set; }

		bool IsCancelled { get; }

		void Run();
	}
}
