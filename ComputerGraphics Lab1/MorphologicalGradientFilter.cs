using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class MorphologicalGradientFilter : MatrixFilter
    {
        private bool[,] structElem;

        public MorphologicalGradientFilter(bool[,] structElem)
        {
            this.structElem = structElem;
        }

        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            DilationFilter dilation = new DilationFilter(structElem);
            Bitmap dilationImage = dilation.processImage(sourceImage, worker);
            ErosionFilter erosion = new ErosionFilter(structElem);
            Bitmap erosionImage = erosion.processImage(sourceImage, worker);

            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int intensityDilation = (int)((dilationImage.GetPixel(i, j).R + dilationImage.GetPixel(i, j).G + dilationImage.GetPixel(i, j).B) / 3);
                    int intensityErosion = (int)((erosionImage.GetPixel(i, j).R + erosionImage.GetPixel(i, j).G + erosionImage.GetPixel(i, j).B) / 3);
                    int intensityResult = Clamp(intensityDilation - intensityErosion, 0, 255);
                    resultImage.SetPixel(i, j, Color.FromArgb(intensityResult, intensityResult, intensityResult));
                }
            }

            return resultImage;
        }
    }
}
