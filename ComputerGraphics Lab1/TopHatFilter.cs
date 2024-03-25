using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class TopHatFilter : Filters
    {
        private bool[,] structElem;

        public TopHatFilter(bool[,] structElem)
        {
            this.structElem = structElem;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Bitmap openedImage = new OpeningFilter(structElem).processImage(sourceImage, new BackgroundWorker());
            int originalIntensity = (int)((sourceImage.GetPixel(x, y).R + sourceImage.GetPixel(x, y).G + sourceImage.GetPixel(x, y).B) / 3);
            int openedIntensity = (int)((openedImage.GetPixel(x, y).R + openedImage.GetPixel(x, y).G + openedImage.GetPixel(x, y).B) / 3);
            int resultIntensity = Clamp(originalIntensity - openedIntensity, 0, 255);

            return Color.FromArgb(resultIntensity, resultIntensity, resultIntensity);
        }
    }

}
