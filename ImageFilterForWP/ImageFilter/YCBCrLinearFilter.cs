/* 
 * HaoRan ImageFilter Classes v0.4
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

using System.Windows.Media;
using System;

namespace HaoRan.ImageFilter
{
    public class YCBCrLinearFilter : IImageFilter
    {
        private Range inY = new Range(0.0f, 1.0f);
        private Range inCb = new Range(-0.5f, 0.5f);
        private Range inCr = new Range(-0.5f, 0.5f);

        private Range outY = new Range(0.0f, 1.0f);
        private Range outCb = new Range(-0.5f, 0.5f);
        private Range outCr = new Range(-0.5f, 0.5f);

        public YCBCrLinearFilter(Range inCb)
        {
            this.inCb = inCb;
        }
       
        public YCBCrLinearFilter(Range inCb, Range inCr)
        {
            this.inCb = inCb;
            this.inCr = inCr;
        }


        public Image process(Image imageIn)
        {
            Color rgb = new Color();
            YCbCr ycbcr = new YCbCr();

            float ky = 0, by = 0;
            float kcb = 0, bcb = 0;
            float kcr = 0, bcr = 0;

            // Y line parameters
            if (inY.Max != inY.Min)
            {
                ky = (outY.Max - outY.Min) / (inY.Max - inY.Min);
                by = outY.Min - ky * inY.Min;
            }
            // Cb line parameters
            if (inCb.Max != inCb.Min)
            {
                kcb = (outCb.Max - outCb.Min) / (inCb.Max - inCb.Min);
                bcb = outCb.Min - kcb * inCb.Min;
            }
            // Cr line parameters
            if (inCr.Max != inCr.Min)
            {
                kcr = (outCr.Max - outCr.Min) / (inCr.Max - inCr.Min);
                bcr = outCr.Min - kcr * inCr.Min;
            }

            for (int x = 0; x < imageIn.getWidth(); x++)
            {
                for (int y = 0; y < imageIn.getHeight(); y++)
                {
                    rgb.R = (byte)imageIn.getRComponent(x, y);
                    rgb.G = (byte)imageIn.getGComponent(x, y);
                    rgb.B = (byte)imageIn.getBComponent(x, y);

                    // convert to YCbCr
                    ycbcr = YCbCr.FromRGB(rgb, ycbcr);

                    // correct Y
                    if (ycbcr.Y >= inY.Max)
                        ycbcr.Y = outY.Max;
                    else if (ycbcr.Y <= inY.Min)
                        ycbcr.Y = outY.Min;
                    else
                        ycbcr.Y = ky * ycbcr.Y + by;

                    // correct Cb
                    if (ycbcr.Cb >= inCb.Max)
                        ycbcr.Cb = outCb.Max;
                    else if (ycbcr.Cb <= inCb.Min)
                        ycbcr.Cb = outCb.Min;
                    else
                        ycbcr.Cb = kcb * ycbcr.Cb + bcb;

                    // correct Cr
                    if (ycbcr.Cr >= inCr.Max)
                        ycbcr.Cr = outCr.Max;
                    else if (ycbcr.Cr <= inCr.Min)
                        ycbcr.Cr = outCr.Min;
                    else
                        ycbcr.Cr = kcr * ycbcr.Cr + bcr;

                    // convert back to RGB
                    rgb = YCbCr.ToRGB(ycbcr, rgb);

                    imageIn.setPixelColor(x, y, rgb.R, rgb.G, rgb.B);
                }
            }
            return imageIn;
        }


        /// <summary>
        /// YCbCr components.
        /// </summary>
        /// 
        /// <remarks>The class encapsulates <b>YCbCr</b> color components.</remarks>
        /// 
        public class YCbCr
        {
            /// <summary>
            /// Index of <b>Y</b> component.
            /// </summary>
            public const short YIndex = 0;

            /// <summary>
            /// Index of <b>Cb</b> component.
            /// </summary>
            public const short CbIndex = 1;

            /// <summary>
            /// Index of <b>Cr</b> component.
            /// </summary>
            public const short CrIndex = 2;

            /// <summary>
            /// <b>Y</b> component.
            /// </summary>
            public float Y;

            /// <summary>
            /// <b>Cb</b> component.
            /// </summary>
            public float Cb;

            /// <summary>
            /// <b>Cr</b> component.
            /// </summary>
            public float Cr;

            /// <summary>
            /// Initializes a new instance of the <see cref="YCbCr"/> class.
            /// </summary>
            public YCbCr() { }

            /// <summary>
            /// Initializes a new instance of the <see cref="YCbCr"/> class.
            /// </summary>
            /// 
            /// <param name="y"><b>Y</b> component.</param>
            /// <param name="cb"><b>Cb</b> component.</param>
            /// <param name="cr"><b>Cr</b> component.</param>
            /// 
            public YCbCr(float y, float cb, float cr)
            {
                this.Y = Math.Max(0.0f, Math.Min(1.0f, y));
                this.Cb = Math.Max(-0.5f, Math.Min(0.5f, cb));
                this.Cr = Math.Max(-0.5f, Math.Min(0.5f, cr));
            }

            /// <summary>
            /// Convert from RGB to YCbCr color space (Rec 601-1 specification). 
            /// </summary>
            /// 
            /// <param name="rgb">Source color in <b>RGB</b> color space.</param>
            /// <param name="ycbcr">Destination color in <b>YCbCr</b> color space.</param>
            /// 
            public static YCbCr FromRGB(Color rgb, YCbCr ycbcr)
            {
                float r = (float)rgb.R / 255;
                float g = (float)rgb.G / 255;
                float b = (float)rgb.B / 255;

                ycbcr.Y = (float)(0.2989 * r + 0.5866 * g + 0.1145 * b);
                ycbcr.Cb = (float)(-0.1687 * r - 0.3313 * g + 0.5000 * b);
                ycbcr.Cr = (float)(0.5000 * r - 0.4184 * g - 0.0816 * b);
                return ycbcr;
            }

            /// <summary>
            /// Convert from RGB to YCbCr color space (Rec 601-1 specification).
            /// </summary>
            /// 
            /// <param name="rgb">Source color in <b>RGB</b> color space.</param>
            /// 
            /// <returns>Returns <see cref="YCbCr"/> instance, which represents converted color value.</returns>
            /// 
            public static YCbCr FromRGB(Color rgb)
            {
                YCbCr ycbcr = new YCbCr();
                FromRGB(rgb, ycbcr);
                return ycbcr;
            }

            /// <summary>
            /// Convert from YCbCr to RGB color space.
            /// </summary>
            /// 
            /// <param name="ycbcr">Source color in <b>YCbCr</b> color space.</param>
            /// <param name="rgb">Destination color in <b>RGB</b> color spacs.</param>
            /// 
            public static Color ToRGB(YCbCr ycbcr, Color rgb)
            {
                // don't warry about zeros. compiler will remove them
                float r = Math.Max(0.0f, Math.Min(1.0f, (float)(ycbcr.Y + 0.0000 * ycbcr.Cb + 1.4022 * ycbcr.Cr)));
                float g = Math.Max(0.0f, Math.Min(1.0f, (float)(ycbcr.Y - 0.3456 * ycbcr.Cb - 0.7145 * ycbcr.Cr)));
                float b = Math.Max(0.0f, Math.Min(1.0f, (float)(ycbcr.Y + 1.7710 * ycbcr.Cb + 0.0000 * ycbcr.Cr)));

                rgb.R = (byte)(r * 255);
                rgb.G = (byte)(g * 255);
                rgb.B = (byte)(b * 255);
                //rgb.Alpha = 255;
                return rgb;
            }

            /// <summary>
            /// Convert the color to <b>RGB</b> color space.
            /// </summary>
            /// 
            /// <returns>Returns <see cref="RGB"/> instance, which represents converted color value.</returns>
            /// 
            public Color ToRGB()
            {
                Color rgb = new Color();
                ToRGB(this, rgb);
                return rgb;
            }
        }

        public struct Range
        {
            private float min, max;

            /// <summary>
            /// Minimum value of the range.
            /// </summary>
            /// 
            /// <remarks><para>The property represents minimum value (left side limit) or the range -
            /// [<b>min</b>, max].</para></remarks>
            /// 
            public float Min
            {
                get { return min; }
                set { min = value; }
            }

            /// <summary>
            /// Maximum value of the range.
            /// </summary>
            /// 
            /// <remarks><para>The property represents maximum value (right side limit) or the range -
            /// [min, <b>max</b>].</para></remarks>
            /// 
            public float Max
            {
                get { return max; }
                set { max = value; }
            }

            /// <summary>
            /// Length of the range (deffirence between maximum and minimum values).
            /// </summary>
            public float Length
            {
                get { return max - min; }
            }


            /// <summary>
            /// Initializes a new instance of the <see cref="Range"/> structure.
            /// </summary>
            /// 
            /// <param name="min">Minimum value of the range.</param>
            /// <param name="max">Maximum value of the range.</param>
            /// 
            public Range(float min, float max)
            {
                this.min = min;
                this.max = max;
            }
        }
    }
}
