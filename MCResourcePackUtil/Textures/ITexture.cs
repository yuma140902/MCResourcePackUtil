using MCResourcePackUtil.GraphicFilters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.Textures
{
	interface ITexture : IDisposable
	{
		void LoadPngFileToMemory();
		void ApplyFilter(IGraphicFilter filter);
		void WriteToResourcePack(string destResourcePackRoot);
	}
}
