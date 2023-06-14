using MCResourcePackUtil.Textures;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.ResourcePacks
{
	class ResourcePackModFile : IResourcePack
	{
		public string Name { get; private set; }

		public string Description => "";

		private readonly string path;

		public ResourcePackModFile(string modFilePath)
		{
			if (!File.Exists(modFilePath)) throw new ArgumentException();
			this.path = modFilePath;
			this.Name = Path.GetFileName(modFilePath);
		}

		public IEnumerable<ITexture> EnumerateTextures()
		{
			using (var ar = ZipFile.OpenRead(this.path)) {
				foreach(var entry in ar.Entries) {
					if(Path.GetExtension(entry.Name).ToLower() == ".png") {
						yield return new TextureInZip(entry);
					}
				}
			}
		}
	}
}
