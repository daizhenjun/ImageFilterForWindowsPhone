
using System.Collections.ObjectModel;
using HaoRan.ImageFilter;

namespace ImageFilterForWP.ViewModels
{
   /// <summary>
   /// A list of effect items.
   /// </summary>
   public class EffectItems : ObservableCollection<EffectItem>
   {
      public EffectItems()
       {   
           //v0.3
           Add(new EffectItem(new ZoomBlurFilter(3, 2.0, 2.0), "/icons/radialdistortion_filter.jpg"));

           //v0.2
           //Add(new EffectItem(new LomoFilter(), "/icons/invert_filter.jpg"));
           //Add(new EffectItem(new ComicFilter(), "/icons/invert_filter.jpg"));
           //Add(new EffectItem(new SceneFilter(5f, Gradient.Scene()), "/icons/invert_filter.jpg"));
           //Add(new EffectItem(new SceneFilter(5f, Gradient.Scene1()), "/icons/invert_filter.jpg"));
           //Add(new EffectItem(new SceneFilter(5f, Gradient.Scene2()), "/icons/invert_filter.jpg"));
           //Add(new EffectItem(new SceneFilter(5f, Gradient.Scene3()), "/icons/invert_filter.jpg"));
           //Add(new EffectItem(new FilmFilter(80f), "/icons/invert_filter.jpg"));//
           Add(new EffectItem(new FocusFilter(), "/icons/invert_filter.jpg"));//
           Add(new EffectItem(new CleanGlassFilter(), "/icons/invert_filter.jpg"));//
           //Add(new EffectItem(new PaintBorderFilter(0x00FF00), "/icons/invert_filter.jpg"));//green
           //Add(new EffectItem(new PaintBorderFilter(0x0000FF), "/icons/invert_filter.jpg"));//blue
           //Add(new EffectItem(new PaintBorderFilter(0xFFFF00), "/icons/invert_filter.jpg"));//yellow
           

          //v0.1
          Add(new EffectItem(new InvertFilter(), "/icons/invert_filter.jpg"));
          Add(new EffectItem(new BlackWhiteFilter(), "/icons/blackwhite_filter.jpg"));
          Add(new EffectItem(new EdgeFilter(), "/icons/edge_filter.jpg"));
          Add(new EffectItem(new PixelateFilter(), "/icons/pixelate_filter.jpg"));
          Add(new EffectItem(new NeonFilter(), "/icons/neon_filter.jpg"));
          Add(new EffectItem(new BigBrotherFilter(), "/icons/bigbrother_filter.jpg"));
          Add(new EffectItem(new MonitorFilter(), "/icons/monitor_filter.jpg"));
          Add(new EffectItem(new ReliefFilter(), "/icons/relief_filter.jpg"));
          Add(new EffectItem(new BrightContrastFilter(), "/icons/brightcontrast_filter.jpg"));
          Add(new EffectItem(new SaturationModifyFilter(), "/icons/saturationmodify_filter.jpg"));
          Add(new EffectItem(new ThresholdFilter(), "/icons/threshold_filter.jpg"));

          Add(new EffectItem(new NoiseFilter(), "/icons/noisefilter.jpg"));
          Add(new EffectItem(new BannerFilter(10, true), "/icons/banner_filter1.jpg"));
          Add(new EffectItem(new BannerFilter(10, false), "/icons/banner_filter2.jpg"));
          Add(new EffectItem(new RectMatrixFilter(), "/icons/rectmatrix_filter.jpg"));
          Add(new EffectItem(new BlockPrintFilter(), "/icons/blockprint_filter.jpg"));
          Add(new EffectItem(new BrickFilter(), "/icons/brick_filter.jpg"));
          Add(new EffectItem(new GaussianBlurFilter(), "/icons/gaussianblur_filter.jpg"));
          Add(new EffectItem(new LightFilter(), "/icons/light_filter.jpg"));
          Add(new EffectItem(new MistFilter(), "/icons/mist_filter.jpg"));
          Add(new EffectItem(new MosaicFilter(), "/icons/mosaic_filter.jpg"));
          Add(new EffectItem(new OilPaintFilter(), "/icons/oilpaint_filter.jpg"));

          Add(new EffectItem(new RadialDistortionFilter(), "/icons/radialdistortion_filter.jpg"));
          Add(new EffectItem(new ReflectionFilter(true), "/icons/reflection1_filter.jpg"));
          Add(new EffectItem(new ReflectionFilter(false), "/icons/reflection2_filter.jpg"));
          Add(new EffectItem(new SmashColorFilter(), "/icons/smashcolor_filter.jpg"));
          Add(new EffectItem(new TintFilter(), "/icons/tint_filter.jpg"));
          Add(new EffectItem(new VignetteFilter(), "/icons/vignette_filter.jpg"));
          Add(new EffectItem(new AutoAdjustFilter(), "/icons/autoadjust_filter.jpg"));
          Add(new EffectItem(new ColorQuantizeFilter(), "/icons/colorquantize_filter.jpg"));
          Add(new EffectItem(new WaterWaveFilter(), "/icons/waterwave_filter.jpg"));
          Add(new EffectItem(new VintageFilter(), "/icons/vintage_filter.jpg"));

          Add(new EffectItem(new OldPhotoFilter(), "/icons/oldphoto_filter.jpg"));
          Add(new EffectItem(new SepiaFilter(), "/icons/sepia_filter.jpg"));
          Add(new EffectItem(new RainBowFilter(), "/icons/rainbow_filter.jpg"));
          Add(new EffectItem(new FeatherFilter(), "/icons/feather_filter.jpg"));
          Add(new EffectItem(new XRadiationFilter(), "/icons/xradiation_filter.jpg"));
          Add(new EffectItem(new NightVisionFilter(), "/icons/nightvision_filter.jpg"));


          
          
      }
   }
}
