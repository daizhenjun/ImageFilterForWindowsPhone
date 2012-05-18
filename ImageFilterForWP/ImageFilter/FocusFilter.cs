using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace HaoRan.ImageFilter
{
    public class FocusFilter : GaussianBlurFilter
    {
         /// <summary>
        /// Should be in the range [0, 1].
        /// </summary>
        public float Size = 0.5f;

        public FocusFilter()
        {
            Size = 0.5f;
            Sigma = 25f;
        }

        public override Image process(Image imageIn)
        {
            int ratio = imageIn.getWidth() > imageIn.getHeight() ? imageIn.getHeight() * 32768 / imageIn.getWidth() : imageIn.getWidth() * 32768 / imageIn.getHeight();

            // Calculate center, min and max
            int cx = imageIn.getWidth() >> 1;
            int cy = imageIn.getHeight() >> 1;
            int max = cx * cx + cy * cy;
            int min = (int)(max * (1 - Size));
            int diff = max - min;

            int width = imageIn.getWidth();
            int height = imageIn.getHeight();
            float[] imageArray = ConvertImageWithPadding(imageIn, width, height);
            imageArray = ApplyBlur(imageArray, width, height);
            int newwidth = width + Padding * 2;
            for (int i = 0; i < height; i++)
            {
                int num = ((i + 3) * newwidth) + 3;
                for (int j = 0; j < width; j++)
                {
                     // Calculate distance to center and adapt aspect ratio
                    int dx = cx - j;
                    int dy = cy - i;
                    if (imageIn.getWidth() > imageIn.getHeight())
                    {
                        dy = (dy * ratio) >> 14;
                    }
                    else
                    {
                        dx = (dx * ratio) >> 14;
                    }
                    int distSq = dx * dx + dy * dy;

                    if (distSq > min)
                    {
                        int pos = (num + j) * 3;
                        imageIn.setPixelColor(j, i, (byte)(imageArray[pos] * 255f), (byte)(imageArray[pos + 1] * 255f), (byte)(imageArray[pos + 2] * 255f));
                     }
                }
            }
            return imageIn;
        }
    }
}
