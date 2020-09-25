using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.Util
{
	// 参考: https://maywork.net/computer/csharp_temp_file_dir/
	class TemporaryDirectory : IDisposable
	{
		public string Path { get; private set; }

		public TemporaryDirectory()
		{
			string tmp = System.IO.Path.GetTempFileName();
			if (File.Exists(tmp)) {
				File.Delete(tmp);
				Directory.CreateDirectory(tmp);
			}
			this.Path = tmp;
		}

		public void Dispose() => Dispose(true);

		protected virtual void Dispose(bool disposing)
		{
			if (Directory.Exists(this.Path)) {
				Directory.Delete(this.Path, recursive: true);
			}
		}

		~TemporaryDirectory() => Dispose(false);
	}
}
