using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.ResourcePacks
{
	interface IResourcePackLoader
	{
		IResourcePack Load(string path);
	}
}
