using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class OpeningFilter : Filters
    {
        private bool[,] structElem;

        public OpeningFilter(bool[,] structElem)
        {
            this.structElem = structElem;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Bitmap erodedImage = new ErosionFilter(structElem).processImage(sourceImage, new BackgroundWorker());
            Bitmap openedImage = new DilationFilter(structElem).processImage(erodedImage, new BackgroundWorker());
            return openedImage.GetPixel(x, y);
        }
    }
}
