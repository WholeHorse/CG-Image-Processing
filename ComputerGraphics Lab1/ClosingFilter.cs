using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class ClosingFilter : Filters
    {
        private bool[,] structElem;

        public ClosingFilter(bool[,] structElem)
        {
            this.structElem = structElem;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Bitmap dilatedImage = new DilationFilter(structElem).processImage(sourceImage, new BackgroundWorker());
            Bitmap closedImage = new ErosionFilter(structElem).processImage(dilatedImage, new BackgroundWorker());
            return closedImage.GetPixel(x, y);
        }
    }
}
