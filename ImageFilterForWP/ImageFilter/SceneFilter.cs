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
namespace HaoRan.ImageFilter
{
    public class SceneFilter : IImageFilter //仿instagram特效
    {
        private GradientFilter gradientFx;
        private SaturationModifyFilter saturationFx;

        public SceneFilter(float angle, Gradient gradient)
        {
            gradientFx = new GradientFilter();
            gradientFx.Gradientf = gradient;
            gradientFx.OriginAngleDegree = angle;

            saturationFx = new SaturationModifyFilter();
            saturationFx.SaturationFactor = -0.6f;
        }

        //@Override
        public Image process(Image imageIn)
        {
            Image clone = imageIn.clone();
            imageIn = gradientFx.process(imageIn);
            ImageBlender blender = new ImageBlender();
            blender.Mode = BlendMode.Subractive;
            return saturationFx.process(blender.Blend(clone, imageIn));
            //return imageIn;// saturationFx.process(imageIn);
        }
    }
}