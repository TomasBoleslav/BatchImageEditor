using System.Collections.Generic;
using System.Linq;

namespace BatchImageEditor
{
	/// <summary>
	/// Contains information about images supported by the editor.
	/// </summary>
	internal static class SupportedImages
	{
		/// <summary>
		/// Gets file extensions of the supported images.
		/// </summary>
		/// <returns>File extensions of the supported images.</returns>
		public static IReadOnlyList<string> GetFileExtensions()
		{
			var fileExtensions = SupportedExtensions.Select(ext => $".{ext}");
			return fileExtensions.ToList();
		}

		/// <summary>
		/// Gets a formatted string for a file dialog filter.
		/// </summary>
		/// <returns>A file dialog filter containing extensions of supported images.</returns>
		public static string GetDialogFilter()
		{
			var joinedExtensions = string.Join(';', SupportedExtensions.Select(ext => $"*.{ext}"));
			return $"Image Files({joinedExtensions})|{joinedExtensions}|All files (*.*)|*.*";
		}

		private static readonly string[] SupportedExtensions = { "jpg", "jpeg", "bmp", "gif", "png" };
	}
}
