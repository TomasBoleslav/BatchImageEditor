using System;

namespace ImageFilters
{
	// TODO: RotateFlip changes shape - how will it affect DirectBitmap?
	public class RotateFlipFilter : IImageFilter
	{
		public RotateFlipFilter()
		{

		}

		public void Apply(ref DirectBitmap inputBitmap)
		{
			ThrowHelper.ThrowIfNull(inputBitmap, nameof(inputBitmap));
			
			
			throw new NotImplementedException();
		}
	}
}
