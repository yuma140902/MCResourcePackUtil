using MCResourcePackUtil.GraphicFilters;
using MCResourcePackUtil.Util;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.Textures
{
	class TextureInZip : ITexture
	{
		private TemporaryFile extractedPng;
		private TemporaryFile extractedMcmeta;
		private string relPath;

		public TextureInZip(ZipArchiveEntry pngEntry)
		{
			this.extractedPng = new TemporaryFile();
			pngEntry.ExtractToFile(this.extractedPng.Path, true);

			var entryMcmeta = pngEntry.Archive.GetEntry(pngEntry.FullName + ".mcmeta");
			if (entryMcmeta != null) {
				this.extractedMcmeta = new TemporaryFile();
				entryMcmeta.ExtractToFile(this.extractedMcmeta.Path, true);
			}

			this.relPath = pngEntry.FullName.Replace("/", "\\");
		}

		private Mat img;

		private bool disposedValue;

		public void LoadPngFileToMemory() => this.img = Cv2.ImRead(this.extractedPng.Path, ImreadModes.Unchanged);

		public void ApplyFilter(IGraphicFilter filter) => this.img = filter.Apply(img);

		public void WriteToResourcePack(string destResourcePackRoot)
		{
			string destPng = Path.Combine(destResourcePackRoot, this.relPath);
			string destMcmeta = Path.Combine(destResourcePackRoot, this.relPath + ".mcmeta");
			string destDir = Path.GetDirectoryName(destPng);

			if (!Directory.Exists(destDir)) {
				Directory.CreateDirectory(destDir);
			}

			if (!File.Exists(destPng)) {
				this.img.ImWrite(destPng);
			}
			if (this.extractedMcmeta != null && File.Exists(this.extractedMcmeta.Path) && !File.Exists(destMcmeta)) {
				File.Copy(this.extractedMcmeta.Path, destMcmeta);
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue) {
				if (disposing) {
					// マネージドリソースを破棄
					this.extractedPng.Dispose();
					this.extractedMcmeta?.Dispose();
					this.img?.Dispose();
				}

				// アンマネージドリソースを破棄
				disposedValue = true;
			}
		}

		~TextureInZip() => Dispose(disposing: false);

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
