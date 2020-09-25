using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.GraphicFilters
{
	class TraditionalBeautyFilter : IGraphicFilter
	{
		public readonly static TraditionalBeautyFilter Instance = new TraditionalBeautyFilter();

		private static readonly InputArray kernelDiffXY = InputArray.Create(new double[,]
			{
				{-1.0, 0.0, 0.0 },
				{ 0.0, 1.0, 0.0 },
				{ 0.0, 0.0, 0.0 }
			});

		private TraditionalBeautyFilter() { }

		public Mat Filter(Mat input)
		{
			// アルファチャンネルがない場合はアルファチャンネルを付加
			if (input.Channels() <= 3) {
				Cv2.CvtColor(input, input, ColorConversionCodes.BGR2BGRA);
			}
			input.ConvertTo(input, MatType.CV_8U);

			// グレースケールに変換
			using var grayscaled = input.CvtColor(ColorConversionCodes.BGRA2GRAY);

			// 画像を縦横それぞれ4倍に拡大
			Cv2.Resize(input, input, OpenCvSharp.Size.Zero, 4.0d, 4.0d, InterpolationFlags.Nearest);
			Cv2.Resize(grayscaled, grayscaled, OpenCvSharp.Size.Zero, 4.0d, 4.0d, InterpolationFlags.Nearest);

			// アルファチャンネルを保存しておく
			using var alphaCh = input.ExtractChannel(3);

			// 元画像をHSVに変換
			input.ConvertTo(input, MatType.CV_8U);
			Cv2.CvtColor(input, input, ColorConversionCodes.BGRA2BGR);
			Cv2.CvtColor(input, input, ColorConversionCodes.BGR2HSV);

			// ドットを識別する
			using var edgeXY = grayscaled.Filter2D(grayscaled.Type(), kernelDiffXY);

			var output = input.Clone();
			using var brightness = new Mat();
			Cv2.Add(input.ExtractChannel(2), edgeXY, brightness);  // もと画像の輝度とedgeXYを足してbrightnessとする
			brightness.InsertChannel(output, 2);  // brightnessをoutputの輝度として設定

			// outputをHSVからBGRAに変換
			Cv2.CvtColor(output, output, ColorConversionCodes.HSV2BGR);
			Cv2.CvtColor(output, output, ColorConversionCodes.BGR2BGRA);

			// outputに元画像のアルファチャンネルをもどす
			alphaCh.InsertChannel(output, 3);

			input.Dispose();
			return output;
		}
	}
}
