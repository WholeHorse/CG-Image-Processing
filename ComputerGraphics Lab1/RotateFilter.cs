using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class RotateFilter : Filters
    {
        private double centerX;
        private double centerY;
        private double angleInRadians;

        public RotateFilter(double centerX, double centerY, double angleInDegrees)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.angleInRadians = angleInDegrees * Math.PI / 180.0;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int newX = (int)((x - centerX) * Math.Cos(angleInRadians) - (y - centerY) * Math.Sin(angleInRadians) + centerX);
            int newY = (int)((x - centerX) * Math.Sin(angleInRadians) + (y - centerY) * Math.Cos(angleInRadians) + centerY);

            if (newX < 0 || newX >= sourceImage.Width || newY < 0 || newY >= sourceImage.Height)
            {
                return Color.Black;
            }

            Color resultColor = sourceImage.GetPixel(newX, newY);

            return resultColor;
        }
    }
}
