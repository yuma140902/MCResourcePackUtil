using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.ResourcePacks
{
	class ResourcePackLoaderPlainFolder : IResourcePackLoader
	{
		public IResourcePack Load(string path) => new ResourcePackPlainFolder(path);
	}
}
