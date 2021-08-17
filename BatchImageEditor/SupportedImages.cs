using System.Collections.Generic;
using System.Linq;

namespace BatchImageEditor
{
	public static class SupportedImages
	{
		public static IReadOnlyList<string> GetFileExtensions()
		{
			var fileExtensions = SupportedExtensions.Select(ext => $".{ext}");
			return fileExtensions.ToList();
		}

		public static string GetDialogFilter()
		{
			var joinedExtensions = string.Join(';', SupportedExtensions.Select(ext => $"*.{ext}"));
			return $"Image files ({joinedExtensions}) | {joinedExtensions} | All files (*.*) | *.*";
		}

		private static readonly string[] SupportedExtensions = { "jpg", "jpeg", "bmp", "gif", "png" };
	}
}
