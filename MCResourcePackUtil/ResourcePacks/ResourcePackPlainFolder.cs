using MCResourcePackUtil.Textures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.ResourcePacks
{
	class ResourcePackPlainFolder : IResourcePack
	{
		public string Name { get; private set; }

		public string Description { get; private set; }

		private string path;

		public ResourcePackPlainFolder(string path)
		{
			if (!Directory.Exists(path)) throw new ArgumentException($"ディレクトリ {path} が存在しません。");
			this.path = path;
			this.Name = Path.GetFileName(this.path);
			this.Description = Path.GetDirectoryName(this.path);
		}

		public IEnumerable<ITexture> EnumerateTextures()
		{
			foreach(string file in Directory.EnumerateFiles(this.path, "*.png", SearchOption.AllDirectories)) {
				yield return new TextureInFolder(this.path, file);
			}
		}
	}
}
