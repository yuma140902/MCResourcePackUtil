using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.ResourcePacks
{
	static class ResourcePackLoaders
	{
		private readonly static IResourcePackLoader plainFolderLoader = new ResourcePackLoaderPlainFolder();
		private readonly static IResourcePackLoader modFileLoader = new ResourcePackLoaderModFile();
		private readonly static IResourcePackLoader zipLoader = new ResourcePackLoaderZip();
		private readonly static IResourcePackLoader folderLoader = new ResourcePackLoaderFolder();

		public static IResourcePack Load(EnumResourcePackType packType, string packPath)
		{
			switch (packType) {
				case EnumResourcePackType.PlainFolder:
					return plainFolderLoader.Load(packPath);
				case EnumResourcePackType.Mod:
					return modFileLoader.Load(packPath);
				case EnumResourcePackType.Zip:
					return zipLoader.Load(packPath);
				case EnumResourcePackType.Folder:
					return folderLoader.Load(packPath);
				default:
					throw new NotImplementedException($"{packType} のローダーがありません。");
			}
		}
	}
}
