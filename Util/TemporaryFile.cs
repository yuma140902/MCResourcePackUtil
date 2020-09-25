using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.Util
{
	class TemporaryFile : IDisposable
	{
		public readonly string Path;

		public TemporaryFile() => this.Path = System.IO.Path.GetTempFileName();

		public void Dispose() => Dispose(true);

		protected virtual void Dispose(bool disposing)
		{
			if (File.Exists(this.Path)) {
				try { File.Delete(this.Path); }
				catch (Exception) { }
			}
		}
		
		~TemporaryFile() => Dispose(false);
	}
}
