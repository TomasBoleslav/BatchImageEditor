using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageFilters;

namespace BatchImageEditor
{
	/*
	public interface ISettingsModel
	{
		void ResetToSavedOrDefault();

		void Save();

		void SetInputImage();

		IEnumerable<IImageFilter> CreateFilters();
	}

	public abstract class SettingsBase<TModel> : ISettingsModel
	{
		// This is bad, I cannot 
		public IEnumerable<IImageFilter> CreateFilters()
		{
			throw new NotImplementedException();
		}

		public void ResetToSavedOrDefault()
		{
			// this is done badly, I
			throw new NotImplementedException();
		}

		public void Save()
		{
			_savedModel = this.Copy();
		}

		public virtual void SetInputImage()
		{
		}

		protected abstract TModel Copy();

		private TModel _savedModel;
	}

	public class MedianModel : ISettingsModel
	{

	}

	// I need access to model from EditDialog - Reset, Display
	// EditDialog:
	//   Model - Reset, CreateFilters, SetInputImage, SettingsUpdated/Changed (computes new image)
	//   UserControl - AddControl(UC), Dock*/
}
