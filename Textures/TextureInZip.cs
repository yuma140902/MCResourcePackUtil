using MCResourcePackUtil.GraphicFilters;
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
	class TextureInZip : ITexture //TODO
	{
		private string extractedPngPath;
		private string extractedMcmetaPath;
		private string relPath;

		public TextureInZip(ZipArchiveEntry pngEntry)
		{
			this.extractedPngPath = Path.GetTempFileName();
			pngEntry.ExtractToFile(this.extractedPngPath, true);

			var entryMcmeta = pngEntry.Archive.GetEntry(pngEntry.FullName + ".mcmeta");
			if(entryMcmeta != null) {
				this.extractedMcmetaPath = Path.GetTempFileName();
				entryMcmeta.ExtractToFile(this.extractedMcmetaPath, true);
			}

			this.relPath = pngEntry.FullName.Replace("/", "\\");
		}

		Mat img;

		public void LoadPngFileToMemory() => this.img = Cv2.ImRead(this.extractedPngPath, ImreadModes.Unchanged);

		public void ApplyFilter(IGraphicFilter filter) => this.img = filter.Filter(img);

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
			if(File.Exists(this.extractedMcmetaPath) && !File.Exists(destMcmeta)) {
				File.Copy(this.extractedMcmetaPath, destMcmeta);
			}
		}
	}
}
