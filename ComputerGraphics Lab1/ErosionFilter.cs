using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class ErosionFilter : MatrixFilter
    {
        private bool[,] structElem;

        public ErosionFilter(bool[,] structElem)
        {
            this.structElem = structElem;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = structElem.GetLength(0) / 2;
            int radiusY = structElem.GetLength(1) / 2;
            int min = 255;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    if (structElem[k + radiusX, l + radiusY])
                    {
                        int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                        int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                        int intensity = (int)((sourceImage.GetPixel(idX, idY).R + sourceImage.GetPixel(idX, idY).G + sourceImage.GetPixel(idX, idY).B) / 3);
                        min = Math.Min(min, intensity);
                    }
                }
            }

            return Color.FromArgb(min, min, min);
        }
    }
}
