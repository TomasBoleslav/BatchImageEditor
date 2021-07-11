using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BatchImageEditor
{
	class FileSearcher
	{
		public FileSearcher(IEnumerable<string> extensionList)
		{
			extensions = extensionList.Select(ext => ext.ToLowerInvariant()).ToHashSet();
		}

		public IEnumerable<string> EnumerateFiles(string folder, SearchOption searchOption)
		{
			var filenames = Directory.EnumerateFiles(folder, "*", searchOption);
			foreach (string filename in filenames)
			{
				string extension = Path.GetExtension(filename).ToLowerInvariant();
				if (extensions.Contains(extension))
				{
					yield return filename;
				}
			}
		}

		private readonly IReadOnlySet<string> extensions;
	}
}
