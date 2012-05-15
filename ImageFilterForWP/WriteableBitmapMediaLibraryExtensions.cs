
using System.IO;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;

namespace ImageFilterForWP
{
   /// <summary>
   /// WriteableBitmap extension for WP7 media library
   /// </summary>
   public static class WriteableBitmapMediaLibraryExtensions
   {
      /// <summary>
      /// Saves the WriteableBitmap encoded as JPEG to the Media library using the best quality of 100.
      /// </summary>
      /// <param name="bitmap">The WriteableBitmap to save.</param>
      /// <param name="name">The name of the destination file.</param>
      public static void SaveToMediaLibrary(this WriteableBitmap bitmap, string name)
      {
         SaveToMediaLibrary(bitmap, name, 100);
      }

      /// <summary>
      /// Saves the WriteableBitmap encoded as JPEG to the Media library.
      /// </summary>
      /// <param name="bitmap">The WriteableBitmap to save.</param>
      /// <param name="name">The name of the destination file.</param>
      /// <param name="quality">The quality for JPEG encoding in the range 0-100, where 100 is best quality size.</param>
      public static void SaveToMediaLibrary(this WriteableBitmap bitmap, string name, int quality)
      {
         using (var stream = new MemoryStream())
         {
            // Save the picture to the WP7 media library
            bitmap.SaveJpeg(stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, quality);
            stream.Seek(0, SeekOrigin.Begin);
            new MediaLibrary().SavePicture(name, stream);
         }
      }
   }
}
