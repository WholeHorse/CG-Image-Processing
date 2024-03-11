using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class EmbossingFilter : MatrixFilter
    {
        private int[,] kernel = new int[,]
        {
            { -2, -1, 0 },
            { -1, 1, 1 },
            { 0, 1, 2 }
        };

        private int shift = 128;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            int resultR = 0;
            int resultG = 0;
            int resultB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idx = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idy = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idx, idy);

                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            }

            resultR = Clamp((int)(resultR + shift + 255) / 2, 0, 255);
            resultG = Clamp((int)(resultG + shift + 255) / 2, 0, 255);
            resultB = Clamp((int)(resultB + shift + 255) / 2, 0, 255);

            int intensity = Clamp((int)(0.299 * resultR + 0.587 * resultG + 0.114 * resultB), 0, 255);
            Color resultColor = Color.FromArgb(intensity, intensity, intensity);

            return resultColor;
        }
    }
}
