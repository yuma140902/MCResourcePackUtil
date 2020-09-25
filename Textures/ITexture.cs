using MCResourcePackUtil.GraphicFilters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.Textures
{
	interface ITexture
	{
		void LoadPngFileToMemory();
		void ApplyFilter(IGraphicFilter filter);
		void WriteToResourcePack(string destResourcePackRoot);
		//あるいは出力先をIOutputで一般化するのはあきらめて、すべてフォルダに出力したあと、必要に応じてZip圧縮する ←これがよさげ。IOutputは削除
	}
}
