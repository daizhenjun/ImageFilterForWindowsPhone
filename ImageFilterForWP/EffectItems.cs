
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
           //99种效果
         
           //v0.4 
           Add(new EffectItem(new VideoFilter(VideoFilter.VIDEO_TYPE.VIDEO_STAGGERED), "/icons/video_filter1.jpg"));
           Add(new EffectItem(new VideoFilter(VideoFilter.VIDEO_TYPE.VIDEO_TRIPED), "/icons/video_filter2.jpg"));
           Add(new EffectItem(new VideoFilter(VideoFilter.VIDEO_TYPE.VIDEO_3X3), "/icons/video_filter3.jpg"));
           Add(new EffectItem(new VideoFilter(VideoFilter.VIDEO_TYPE.VIDEO_DOTS), "/icons/video_filter4.jpg"));
           Add(new EffectItem(new TileReflectionFilter(20, 8, 45, 1), "/icons/tilereflection_filter1.jpg"));
           Add(new EffectItem(new TileReflectionFilter(20, 8, 45, 2), "/icons/tilereflection_filter2.jpg"));
           Add(new EffectItem(new FillPatternFilter("/ImageFilterForWP;component/icons/texture1.png"), "/icons/fillpattern_filter.jpg"));
           Add(new EffectItem(new FillPatternFilter("/ImageFilterForWP;component/icons/texture2.png"), "/icons/fillpattern_filter1.jpg"));
           Add(new EffectItem(new MirrorFilter(true), "/icons/mirror_filter1.jpg"));
           Add(new EffectItem(new MirrorFilter(false), "/icons/mirror_filter2.jpg"));
           Add(new EffectItem(new YCBCrLinearFilter(new YCBCrLinearFilter.Range(-0.3f, 0.3f)), "/icons/ycb_crlinear_filter.jpg"));
           Add(new EffectItem(new YCBCrLinearFilter(new YCBCrLinearFilter.Range(-0.276f, 0.163f), new YCBCrLinearFilter.Range(-0.202f, 0.5f)), "/icons/ycb_crlinear_filter2.jpg"));
           Add(new EffectItem(new TexturerFilter(new CloudsTexture(), 0.8, 0.8), "/icons/texturer_filter.jpg"));
           Add(new EffectItem(new TexturerFilter(new LabyrinthTexture(), 0.8, 0.8), "/icons/texturer_filter1.jpg"));
           Add(new EffectItem(new TexturerFilter(new MarbleTexture(), 1.8, 0.8), "/icons/texturer_filter2.jpg"));
           Add(new EffectItem(new TexturerFilter(new WoodTexture(), 0.8, 0.8), "/icons/texturer_filter3.jpg"));
           Add(new EffectItem(new TexturerFilter(new TextileTexture(), 0.8, 0.8), "/icons/texturer_filter4.jpg"));
           Add(new EffectItem(new HslModifyFilter(20f), "/icons/hslmodify_filter.jpg"));
           Add(new EffectItem(new HslModifyFilter(40f), "/icons/hslmodify_filter0.jpg"));
           Add(new EffectItem(new HslModifyFilter(60f), "/icons/hslmodify_filter1.jpg"));
           Add(new EffectItem(new HslModifyFilter(80f), "/icons/hslmodify_filter2.jpg"));
           Add(new EffectItem(new HslModifyFilter(100f), "/icons/hslmodify_filter3.jpg"));
           Add(new EffectItem(new HslModifyFilter(150f), "/icons/hslmodify_filter4.jpg"));
           Add(new EffectItem(new HslModifyFilter(200f), "/icons/hslmodify_filter5.jpg"));
           Add(new EffectItem(new HslModifyFilter(250f), "/icons/hslmodify_filter6.jpg"));
           Add(new EffectItem(new HslModifyFilter(300f), "/icons/hslmodify_filter7.jpg"));

           //v0.3
           Add(new EffectItem(new ZoomBlurFilter(30), "/icons/zoomblur_filter.jpg"));
           Add(new EffectItem(new ThreeDGridFilter(16, 100), "/icons/threedgrid_filter.jpg"));
           Add(new EffectItem(new ColorToneFilter(Image.rgb(254, 168, 33), 192), "/icons/colortone_filter.jpg"));
           Add(new EffectItem(new ColorToneFilter(0x00FF00, 192), "/icons/colortone_filter2.jpg"));//green
           Add(new EffectItem(new ColorToneFilter(0x0000FF, 192), "/icons/colortone_filter3.jpg"));//blue
           Add(new EffectItem(new ColorToneFilter(0xFFFF00, 192), "/icons/colortone_filter4.jpg"));
           Add(new EffectItem(new SoftGlowFilter(10, 0.1f, 0.1f), "/icons/softglow_filter.jpg"));
           Add(new EffectItem(new TileReflectionFilter(20, 8), "/icons/tilereflection_filter.jpg"));
           Add(new EffectItem(new BlindFilter(true, 96, 100, 0xffffff), "/icons/blind_filter1.jpg"));
           Add(new EffectItem(new BlindFilter(false, 96, 100, 0x000000), "/icons/blind_filter2.jpg"));
           Add(new EffectItem(new RaiseFrameFilter(20), "/icons/raiseframe_filter.jpg"));
           Add(new EffectItem(new ShiftFilter(10), "/icons/shift_filter.jpg"));
           Add(new EffectItem(new WaveFilter(25, 10), "/icons/wave_filter.jpg"));
           Add(new EffectItem(new BulgeFilter(-97), "/icons/bulge_filter.jpg"));
           Add(new EffectItem(new TwistFilter(27, 106), "/icons/twist_filter.jpg"));
           Add(new EffectItem(new RippleFilter(38, 15, true), "/icons/ripple_filter.jpg"));
           Add(new EffectItem(new IllusionFilter(3), "/icons/illusion_filter.jpg"));
           Add(new EffectItem(new SupernovaFilter(0x00FFFF, 20, 100), "/icons/supernova_filter.jpg"));
           Add(new EffectItem(new LensFlareFilter(), "/icons/lensflare_filter.jpg"));
           Add(new EffectItem(new PosterizeFilter(2), "/icons/posterize_filter.jpg"));
           Add(new EffectItem(new GammaFilter(50), "/icons/gamma_filter.jpg"));
           Add(new EffectItem(new SharpFilter(), "/icons/sharp_filter.jpg"));


           //v0.2
           Add(new EffectItem(new LomoFilter(), "/icons/invert_filter.jpg"));
           Add(new EffectItem(new ComicFilter(), "/icons/invert_filter.jpg"));
           Add(new EffectItem(new SceneFilter(5f, Gradient.Scene()), "/icons/invert_filter.jpg"));
           Add(new EffectItem(new SceneFilter(5f, Gradient.Scene1()), "/icons/invert_filter.jpg"));
           Add(new EffectItem(new SceneFilter(5f, Gradient.Scene2()), "/icons/invert_filter.jpg"));
           Add(new EffectItem(new SceneFilter(5f, Gradient.Scene3()), "/icons/invert_filter.jpg"));
           Add(new EffectItem(new FilmFilter(80f), "/icons/invert_filter.jpg"));
           Add(new EffectItem(new FocusFilter(), "/icons/invert_filter.jpg"));
           Add(new EffectItem(new CleanGlassFilter(), "/icons/invert_filter.jpg"));
           Add(new EffectItem(new PaintBorderFilter(0x00FF00), "/icons/invert_filter.jpg"));//green
           Add(new EffectItem(new PaintBorderFilter(0x0000FF), "/icons/invert_filter.jpg"));//blue
           Add(new EffectItem(new PaintBorderFilter(0xFFFF00), "/icons/invert_filter.jpg"));//yellow


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
