﻿using Xunit;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageFilters.Tests
{
	public sealed class MedianFilterTests
	{
		[Fact]
		public void Apply_AssignsNewBitmapToParameter()
		{
			var directBitmap = new DirectBitmap(5, 5, PixelFormat.Format24bppRgb);
			var oldDirectBitmap = directBitmap;
			var filter = new MedianFilter(1);

			filter.Apply(ref directBitmap);

			Assert.NotSame(oldDirectBitmap, directBitmap);
		}

		[Fact]
		public void Apply_DisposesOldBitmap()
		{
			var directBitmap = new DirectBitmap(5, 5, PixelFormat.Format24bppRgb);
			var oldDirectBitmap = directBitmap;
			var filter = new MedianFilter(1);

			filter.Apply(ref directBitmap);

			Assert.True(oldDirectBitmap.IsDisposed);
		}

		[Theory]
		[InlineData(1, 1, PixelFormat.Format24bppRgb, 1, 2, 3)]
		[InlineData(5, 1, PixelFormat.Format24bppRgb, 1, 2, 3)]
		[InlineData(5, 10, PixelFormat.Format24bppRgb, 1, 2, 3)]
		[InlineData(5, 1, PixelFormat.Format32bppRgb, 1, 2, 3)]
		[InlineData(5, 1, PixelFormat.Format32bppArgb, 1, 2, 3)]
		public void Apply_BitmapWithOneColor_ResultHasSameColor(
			int bitmapSize, int radius, PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color clearColor = Color.FromArgb(a, r, g, b);
			var directBitmap = new DirectBitmap(bitmapSize, bitmapSize, pixelFormat);
			BitmapHelper.Clear(directBitmap, clearColor);
			var filter = new MedianFilter(radius);
			Color expectedColor = clearColor;

			filter.Apply(ref directBitmap);

			for (int y = 0; y < directBitmap.Height; y++)
			{
				for (int x = 0; x < directBitmap.Width; x++)
				{
					Color actualColor = directBitmap.GetPixel(x, y);
					Assert.Equal(expectedColor, actualColor);
				}
			}
		}

		[Theory]
		[InlineData(3, 1, 1, PixelFormat.Format24bppRgb)]
		[InlineData(5, 2, 2, PixelFormat.Format24bppRgb)]
		[InlineData(5, 2, 3, PixelFormat.Format24bppRgb)]
		[InlineData(5, 2, 2, PixelFormat.Format32bppRgb)]
		[InlineData(5, 2, 2, PixelFormat.Format32bppArgb)]
		public void Apply_InnerPixelAndIncreasingColors_ResultHasSameColor(
			int bitmapSize, int x, int y, PixelFormat pixelFormat)
		{
			int radius = 1;
			var directBitmap = CreateBitmapWithIncreasingColor(bitmapSize, bitmapSize, pixelFormat);
			var oldBitmap = directBitmap.Copy();
			var filter = new MedianFilter(radius);

			filter.Apply(ref directBitmap);

			Assert.Equal(oldBitmap.GetPixel(x, y), directBitmap.GetPixel(x, y));
		}

		[Theory]
		[InlineData(3, 1, 1, PixelFormat.Format24bppRgb)]
		[InlineData(5, 2, 2, PixelFormat.Format24bppRgb)]
		[InlineData(5, 2, 2, PixelFormat.Format32bppRgb)]
		[InlineData(5, 2, 2, PixelFormat.Format32bppArgb)]
		public void Apply_InnerPixelAndMoreColors_ResultIsMedianOfNeighbors(
			int bitmapSize, int x, int y, PixelFormat pixelFormat)
		{
			int radius = 1;
			Color[][] colors =
			{
				new[] { 5.ToColor(), 9.ToColor(), 3.ToColor() },
				new[] { 6.ToColor(), 8.ToColor(), 7.ToColor() },
				new[] { 4.ToColor(), 2.ToColor(), 1.ToColor() },
			};
			Color expectedColor = 5.ToColor();
			var directBitmap = new DirectBitmap(bitmapSize, bitmapSize, pixelFormat);
			SetColorsAroundInnerPoint(directBitmap, colors, x, y);
			var filter = new MedianFilter(radius);

			filter.Apply(ref directBitmap);

			Assert.Equal(expectedColor, directBitmap.GetPixel(x, y));
		}

		[Theory]
		[InlineData(PixelFormat.Format24bppRgb)]
		[InlineData(PixelFormat.Format32bppRgb)]
		[InlineData(PixelFormat.Format32bppArgb)]
		public void Apply_EdgePixelAndMoreColors_ResultIsMedianOfNeighbors(PixelFormat pixelFormat)
		{
			int bitmapSize = 3;
			int radius = 1;
			var directBitmap = new DirectBitmap(bitmapSize, bitmapSize, pixelFormat);
			directBitmap.SetPixel(0, 0, 1.ToColor());
			directBitmap.SetPixel(1, 0, 1.ToColor());
			directBitmap.SetPixel(0, 1, 2.ToColor());
			directBitmap.SetPixel(1, 1, 3.ToColor());
			Color expectedColor = 1.ToColor();
			var filter = new MedianFilter(radius);

			filter.Apply(ref directBitmap);

			Assert.Equal(expectedColor, directBitmap.GetPixel(0, 0));
		}

		private static readonly Color StartColor = Color.FromArgb(1, 2, 3);

		private static DirectBitmap CreateBitmapWithIncreasingColor(int width, int height, PixelFormat pixelFormat)
		{
			var directBitmap = new DirectBitmap(width, height, pixelFormat);
			int colorIndex = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Color addition = Color.FromArgb(1, 1, 1).Multiply(colorIndex);
					directBitmap.SetPixel(x, y, StartColor.Add(addition));
					colorIndex++;
				}
			}
			return directBitmap;
		}

		private static void SetColorsAroundInnerPoint(DirectBitmap bitmap, Color[][] colors, int x, int y)
		{
			int halfHeight = colors.Length / 2;
			for (int i = 0; i < colors.Length; i++)
			{
				int halfWidth = colors[i].Length / 2;
				for (int j = 0; j < colors[i].Length; j++)
				{
					int destY = y + i - halfHeight;
					int destX = x + j - halfWidth;
					bitmap.SetPixel(destX, destY, colors[i][j]);
				}
			}
		}
	}
}