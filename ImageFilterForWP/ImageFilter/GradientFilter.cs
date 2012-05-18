/* 
 * HaoRan ImageFilter Classes v0.1
 * Copyright (C) 2012 Zhenjun Dai
 *
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by the
 * Free Software Foundation; either version 2.1 of the License, or (at your
 * option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public License
 * for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this library; if not, write to the Free Software Foundation.
 */


using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace HaoRan.ImageFilter
{
    public class Palette
    {
        public byte[] Blue;
        public byte[] Green;
        public int Length;
        public byte[] Red;

        public Palette(int length)
        {
            this.Length = length;
            this.Red = new byte[length];
            this.Green = new byte[length];
            this.Blue = new byte[length];
        }
    }

    public class TintColors
    {
        public static Color LightCyan()
        {
            return Color.FromArgb(255, 0xeb, 0xf5, 0xe1);
        }

        public static Color Sepia()
        {
            return Color.FromArgb(255, 230, 179, 179);
        }
    }

    public class Gradient
    {
        public List<Color> MapColors;

        public Gradient()
        {
            List<Color> list = new List<Color>();
            list.Add(Colors.Black);
            list.Add(Colors.White);
            this.MapColors = list;
        }

        public Gradient(List<Color> colors)
        {
            this.MapColors = colors;
        }


        private Palette CreateGradient(List<Color> colors, int length)
        {
            if (colors == null || colors.Count < 2)
            {
                return null;
            }

            Palette palette = new Palette(length);
            byte[] red = palette.Red;
            byte[] green = palette.Green;
            byte[] blue = palette.Blue;
            int num = length / (colors.Count - 1);
            float num1 = 1f / ((float)num);
            int index = 0;
            Color rgb = colors[0];
            int colorR = rgb.R;
            int colorG = rgb.G;
            int colorB = rgb.B;
            for (int i = 1; i < colors.Count; i++)
            {
                int r = colors[i].R;
                int g = colors[i].G;
                int b = colors[i].B;
                for (int j = 0; j < num; j++)
                {
                    float num2 = j * num1;
                    int rr = colorR + ((int)((r - colorR) * num2));
                    int gg = colorG + ((int)((g - colorG) * num2));
                    int bb = colorB + ((int)((b - colorB) * num2));
                    red[index] = (byte)(rr > 0xff ? 0xff : ((rr < 0) ? 0 : rr));
                    green[index] = (byte)(gg > 0xff ? 0xff : ((gg < 0) ? 0 : gg));
                    blue[index] = (byte)(bb > 0xff ? 0xff : ((bb < 0) ? 0 : bb));
                    index++;
                }
                colorR = r;
                colorG = g;
                colorB = b;
            }
            if (index < length)
            {
                red[index] = red[index - 1];
                green[index] = green[index - 1];
                blue[index] = blue[index - 1];
            }
            return palette;
        }

        public Palette CreatePalette(int length)
        {
            return CreateGradient(this.MapColors, length);
        }

      

        public static Gradient BlackSepia()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Colors.Black);
            colors.Add(TintColors.Sepia());
            return new Gradient(colors);
        }

        public static Gradient WhiteSepia()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Colors.White);
            colors.Add(TintColors.Sepia());
            return new Gradient(colors);
        }

        public static Gradient RainBow()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Colors.Red);
            colors.Add(Colors.Magenta);
            colors.Add(Colors.Blue);
            colors.Add(Colors.Cyan);
            colors.Add(Colors.Green);
            colors.Add(Colors.Yellow);
            colors.Add(Colors.Red);
            return new Gradient(colors);
        }

        public static Gradient Inverse()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Colors.White);
            colors.Add(Colors.Black);
            return new Gradient(colors);
        }

        public static Gradient Fade()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Colors.Black);
            colors.Add(Color.FromArgb(255, 0xEE, 0xE8, 0xCD));//Cornsilk2  , reference http://www.wescn.com/tool/color_3.html
            colors.Add(Colors.Black);
            return new Gradient(colors);
        }

        public static Gradient Scene()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Color.FromArgb(255, 0xFF, 0xD7, 0x00));//Gold  , reference http://www.wescn.com/tool/color_3.html
            colors.Add(Colors.White);
            colors.Add(Color.FromArgb(255, 0xFF, 0xD7, 0x00));//Gold
            return new Gradient(colors);
        }

        public static Gradient Scene1()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Color.FromArgb(255, 0x64, 0x95, 0xED));//CornflowerBlue  , reference http://www.wescn.com/tool/color_3.html
            colors.Add(Colors.White);
            colors.Add(Color.FromArgb(255, 0x64, 0x95, 0xED));//CornflowerBlue
            return new Gradient(colors);
        }

       
        public static Gradient Scene2()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Color.FromArgb(255, 0x00, 0xBF, 0xFF));//DeepSkyBlue  , reference http://www.wescn.com/tool/color_3.html
            colors.Add(Color.FromArgb(255, 0xDC, 0xDC, 0xDC));//Gainsboro
            colors.Add(Color.FromArgb(255, 0x00, 0xBF, 0xFF));//DeepSkyBlue
            return new Gradient(colors);
        }

        public static Gradient Scene3()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Colors.Orange);// , reference http://www.wescn.com/tool/color_3.html
            colors.Add(Colors.White);
            colors.Add(Colors.Orange);//
            return new Gradient(colors);
        }
    }


    public class GradientFilter : IImageFilter
    {
        private Palette palette = null;
        public Gradient Gradientf;
        public float OriginAngleDegree;

        // Methods
        public GradientFilter()
        {
            this.OriginAngleDegree = 0f;
            this.Gradientf = new Gradient();
        }

        public void ClearCache()
        {
            this.palette = null;
        }

        //@Override
        public Image process(Image imageIn)
        {
            int width = imageIn.getWidth();
            int height = imageIn.getHeight();
            double d = this.OriginAngleDegree * 0.0174532925;
            float cos = (float)Math.Cos(d);
            float sin = (float)Math.Sin(d);
            float radio = (cos * width) + (sin * height);
            float dcos = cos * radio;
            float dsin = sin * radio;
            int dist = (int)Math.Sqrt((double)((dcos * dcos) + (dsin * dsin)));
            dist = Math.Max(Math.Max(dist, width), height);

            if ((this.palette == null) || (dist != this.palette.Length))
            {
                this.palette = this.Gradientf.CreatePalette(dist);
            }
            byte[] red = this.palette.Red;
            byte[] green = this.palette.Green;
            byte[] blue = this.palette.Blue;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    radio = (cos * j) + (sin * i);
                    dcos = cos * radio;
                    dsin = sin * radio;
                    dist = (int)Math.Sqrt((double)((dcos * dcos) + (dsin * dsin)));
                    imageIn.setPixelColor(j, i, red[dist], green[dist], blue[dist]);
                }
            }
            return imageIn;
        }
    }
}
