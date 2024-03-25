using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class BlackHatFilter : MatrixFilter
    {
        private bool[,] structElem;

        public BlackHatFilter(bool[,] structElem)
        {
            this.structElem = structElem;
        }

        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            ClosingFilter closing = new ClosingFilter(structElem);
            Bitmap closingImage = closing.processImage(sourceImage, worker);

            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int intensitySource = (int)((sourceImage.GetPixel(i, j).R + sourceImage.GetPixel(i, j).G + sourceImage.GetPixel(i, j).B) / 3);
                    int intensityClosing = (int)((closingImage.GetPixel(i, j).R + closingImage.GetPixel(i, j).G + closingImage.GetPixel(i, j).B) / 3);
                    int intensityResult = Clamp(intensityClosing - intensitySource, 0, 255);
                    resultImage.SetPixel(i, j, Color.FromArgb(intensityResult, intensityResult, intensityResult));
                }
            }

            return resultImage;
        }
    }
}
