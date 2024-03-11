using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class ScharrFilter : MatrixFilter
    {
        private int[,] kernelHorizontal = new int[,]
        {
            { 3, 0, -3 },
            { 10, 0, -10 },
            { 3, 0, -3 }
        };

        private int[,] kernelVertical = new int[,]
        {
            { 3, 10, 3 },
            { 0, 0, 0 },
            { -3, -10, -3 }
        };

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernelHorizontal.GetLength(0) / 2;
            int radiusY = kernelHorizontal.GetLength(1) / 2;

            float resultRx = 0;
            float resultRy = 0;

            float resultGx = 0;
            float resultGy = 0;

            float resultBx = 0;
            float resultBy = 0;

            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idx = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idy = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idx, idy);

                    resultRx += neighborColor.R * kernelHorizontal[k + radiusX, l + radiusY];
                    resultRy += neighborColor.R * kernelVertical[k + radiusX, l + radiusY];

                    resultGx += neighborColor.G * kernelHorizontal[k + radiusX, l + radiusY];
                    resultGy += neighborColor.G * kernelVertical[k + radiusX, l + radiusY];

                    resultBx += neighborColor.B * kernelHorizontal[k + radiusX, l + radiusY];
                    resultBy += neighborColor.B * kernelVertical[k + radiusX, l + radiusY];
                }
            }

            int intensityR = Clamp((int)Math.Sqrt(resultRx * resultRx + resultRy * resultRy), 0, 255);
            int intensityG = Clamp((int)Math.Sqrt(resultGx * resultGx + resultGy * resultGy), 0, 255);
            int intensityB = Clamp((int)Math.Sqrt(resultBx * resultBx + resultBy * resultBy), 0, 255);

            Color resultColor = Color.FromArgb(intensityR, intensityG, intensityB);

            return resultColor;
        }
    }
}
