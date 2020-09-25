using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.GraphicFilters
{
	interface IGraphicFilter
	{
		Mat Filter(Mat image);
	}
}
