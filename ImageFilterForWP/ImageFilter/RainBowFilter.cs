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

using System.Collections.Generic;
using System.Windows.Media;

namespace HaoRan.ImageFilter
{
    public class RainBowFilter : IImageFilter
    {

        public ImageBlender blender = new ImageBlender();
        public bool IsDoubleRainbow = false;
        private GradientFilter gradientFx;
        public float gradAngleDegree = 40f;

        public RainBowFilter()
        {
            blender.Mixture = 0.25f;
            blender.Mode = BlendMode.Additive;

            IsDoubleRainbow = true;

            List<Color> rainbowColors = Gradient.RainBow().MapColors;
            if (this.IsDoubleRainbow)
            {
                rainbowColors.RemoveAt(rainbowColors.Count - 1);//remove red
                rainbowColors.AddRange(Gradient.RainBow().MapColors);
            }
            gradientFx = new GradientFilter();
            gradientFx.OriginAngleDegree = gradAngleDegree;
            gradientFx.Gradientf = new Gradient(rainbowColors);
        }

        //@Override
        public Image process(Image imageIn)
        {
            Image clone = gradientFx.process(imageIn.clone());
            return blender.Blend(imageIn, clone);
        }
    }

}
