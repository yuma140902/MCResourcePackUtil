using MCResourcePackUtil.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.ResourcePacks
{
	interface IResourcePack
	{
		string Name { get; }
		string Description { get; }
		IEnumerable<ITexture> EnumerateTextures();
	}
}
