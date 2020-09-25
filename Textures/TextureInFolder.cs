using MCResourcePackUtil.GraphicFilters;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.Textures
{
	class TextureInFolder : ITexture
	{
		private readonly string rootPath;
		private readonly string relPngFile;
		private readonly string relMcmetaFile;
		private Mat img;
		private bool disposedValue;

		public TextureInFolder(string rootPath, string pngPath)
		{
			this.rootPath = rootPath;

			this.relPngFile = new Uri(this.rootPath + (this.rootPath.EndsWith("\\") ? "" : "\\"))
				.MakeRelativeUri(new Uri(pngPath)).ToString().Replace("/", "\\");
			this.relMcmetaFile = this.relPngFile + ".mcmeta";
		}

		public void LoadPngFileToMemory()
			=> this.img = Cv2.ImRead(Path.Combine(this.rootPath, this.relPngFile), ImreadModes.Unchanged);

		public void ApplyFilter(IGraphicFilter filter) => this.img = filter.Filter(img);

		public void WriteToResourcePack(string destResourcePackRoot)
		{
			string destDir = Path.Combine(destResourcePackRoot, Path.GetDirectoryName(this.relPngFile));
			string destPng = Path.Combine(destResourcePackRoot, this.relPngFile);
			string destMcmeta = Path.Combine(destResourcePackRoot, this.relMcmetaFile);
			string srcPng = Path.Combine(this.rootPath, this.relPngFile);
			string srcMcmeta = Path.Combine(this.rootPath, this.relMcmetaFile);

			if (!Directory.Exists(destDir)) {
				Directory.CreateDirectory(destDir);
			}
			if (File.Exists(srcPng) && !File.Exists(destPng)) {
				Cv2.ImWrite(destPng, this.img);
				Debug.WriteLine($"{destPng} への書き込み");
			}
			else {
				Debug.WriteLine($"{destPng} はすでに存在する、または元ファイルが存在しないのでスキップしました");
			}
			if (File.Exists(srcMcmeta) && !File.Exists(destMcmeta)) {
				File.Copy(srcMcmeta, destMcmeta);
				Debug.WriteLine($"{srcMcmeta} を {destMcmeta} へコピー");
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue) {
				if (disposing) {
					// マネージドリソースを破棄
					img?.Dispose();
				}

				// アンマネージドリソースを破棄
				disposedValue = true;
			}
		}

		~TextureInFolder() => Dispose(disposing: false);

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
