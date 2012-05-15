
using System.Windows.Media;
using System.Windows.Media.Imaging;

using HaoRan.ImageFilter;

namespace ImageFilterForWP
{
   /// <summary>
   /// A generic effect item.
   /// </summary>
   public class EffectItem
   {
      public IImageFilter Effect { get; private set; }
      public string Name { get; private set; }
      public ImageSource Thumbnail { get; set; }

      public EffectItem(IImageFilter effect)
      {
         Effect = effect;
        // Name = effect.Name;
      }

      public EffectItem(IImageFilter effect, string thumbnailRelativeResourcePath)
         : this(effect)
      {
         // Load the thumbnail from the resource stream using the WriteableBitmapEx lib
          Thumbnail = new BitmapImage(new System.Uri(thumbnailRelativeResourcePath, System.UriKind.RelativeOrAbsolute));// new WriteableBitmap(0, 0).FromResource(thumbnailRelativeResourcePath);
      }

      public EffectItem(IImageFilter effect, string thumbnailRelativeResourcePath, string name)
         : this(effect, thumbnailRelativeResourcePath)
      {
         Name = name;
      }
   }
}
