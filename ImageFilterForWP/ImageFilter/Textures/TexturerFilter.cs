// AForge Image Processing Library
//
// Copyright ?Andrew Kirillov, 2005-2007
// andrew.kirillov@gmail.com
//
namespace HaoRan.ImageFilter
{
	using System;

	/// <summary>
	/// Texturer filter
	/// </summary>
    /// 
    /// <remarks>Adjust pixel colors using factors from texture.</remarks>
    /// 
    public class TexturerFilter : IImageFilter
	{
        // texture generator
		private ITextureGenerator textureGenerator;
        // generated texture
		private float[,] texture = null;

        // filtering factor
		private double filterLevel = 0.5;
        // preservation factor
        private double preserveLevel = 0.5;

        /// <summary>
        /// Filter level value
        /// </summary>
        /// 
        /// <remarks>Filtering factor determines image fraction to filter.</remarks>
        /// 
		public double FilterLevel
		{
			get { return filterLevel; }
			set { filterLevel = Math.Max( 0.0, Math.Min( 1.0, value ) ); }
		}

        /// <summary>
        /// Preserve level value
        /// </summary>
        /// 
        /// <remarks>Preserving factor determines image fraction to keep from filtering.</remarks>
        /// 
        public double PreserveLevel
        {
            get { return preserveLevel; }
            set { preserveLevel = Math.Max( 0.0, Math.Min( 1.0, value ) ); }
        }

        /// <summary>
        /// Generated texture
        /// </summary>
        /// 
        /// <remarks>Two dimensional array of texture intecities.</remarks>
        /// 
		public float[,] Texture
		{
			get { return texture; }
			set { texture = value; }
		}

        /// <summary>
        /// Texture generator
        /// </summary>
        /// 
        /// <remarks>Generator used to generate texture.</remarks>
        /// 
		public ITextureGenerator TextureGenerator
		{
			get { return textureGenerator; }
			set { textureGenerator = value; }
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Texturer"/> class
        /// </summary>
        /// 
        /// <param name="texture">Generated texture</param>
        /// 
		public TexturerFilter( float[,] texture )
		{
			this.texture = texture;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Texturer"/> class
        /// </summary>
        /// 
        /// <param name="texture">Generated texture</param>
        /// <param name="filterLevel">Filter level value</param>
        /// <param name="preserveLevel">Preserve level value</param>
        /// 
		public TexturerFilter( float[,] texture, double filterLevel, double preserveLevel )
		{
			this.texture        = texture;
			this.filterLevel    = filterLevel;
            this.preserveLevel  = preserveLevel;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Texturer"/> class
        /// </summary>
        /// 
        /// <param name="generator">Texture generator</param>
        /// 
		public TexturerFilter( ITextureGenerator generator )
		{
			this.textureGenerator = generator;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Texturer"/> class
        /// </summary>
        /// 
        /// <param name="generator">Texture generator</param>
        /// <param name="filterLevel">Filter level value</param>
        /// <param name="preserveLevel">Preserve level value</param>
        /// 
        public TexturerFilter(ITextureGenerator generator, double filterLevel, double preserveLevel)
		{
			this.textureGenerator   = generator;
			this.filterLevel        = filterLevel;
            this.preserveLevel      = preserveLevel;
		}

		
        public Image process(Image imageIn) 
        {
            // get source image size
            int width = imageIn.getWidth();
            int height = imageIn.getHeight();

            // processing region's dimension
            int widthToProcess = width;
            int heightToProcess = height;

            // if generator was specified, then generate a texture
            // otherwise use provided texture
            if ( textureGenerator != null )
            {
                texture = textureGenerator.Generate( width, height );
            }
            else
            {
                widthToProcess = Math.Min( width, texture.GetLength( 1 ) );
                heightToProcess = Math.Min( height, texture.GetLength( 0 ) );
            }

            int r, g, b;
         
            // texture
            for ( int y = 0; y < heightToProcess; y++ )
            {
                for ( int x = 0; x < widthToProcess; x++ )
                {
                    double t = texture[y, x];
                    r = imageIn.getRComponent(x, y);
                    g = imageIn.getGComponent(x, y);
                    b = imageIn.getBComponent(x, y);
                    // process each pixel
                   
                    r = (byte) Math.Min( 255.0f, ( preserveLevel * r) + ( filterLevel * r) * t );
                    g = (byte) Math.Min( 255.0f, ( preserveLevel * g) + ( filterLevel * g) * t );
                    b = (byte) Math.Min( 255.0f, ( preserveLevel * b) + ( filterLevel * b) * t );
                    imageIn.setPixelColor(x, y, r, g, b);                
                }
            }
            return imageIn;
        }
	}
}
