using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    /// <summary>
    /// Represents the settings for generating a fractal image.
    /// </summary>
    public class SettingsTemplate
    {
        #region fields

        private int _zoom;
        private int _iteration;
        private int _resulution;
        private int _radius;

        /// <summary>
        /// Gets or sets the type of fractal to generate (e.g., Mandelbrot, Julia).
        /// </summary>
        public fraktal fractal
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the zoom level for the fractal.
        /// Minimum value is 1. Values below 1 will be clamped to 1.
        /// </summary>
        public int zoom
        {
            get               
            {
                return _zoom;
            }
            set 
            {
                _zoom = (value >= 1) ? value : 1;
            }
        }

        /// <summary>
        /// Gets or sets the horizontal offset (X-coordinate of the center) for the fractal view.
        /// </summary>
        public double xDifference
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the vertical offset (Y-coordinate of the center) for the fractal view.
        /// </summary>
        public double yDifference
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the resolution (width and height in pixels) of the fractal image.
        /// Minimum value is 256. Values below 256 will be clamped to 256.
        /// </summary>
        public int resulution
        {
            get { return _resulution; }
            set { _resulution = (value >= 256) ? value : 256; }
        }
        
        /// <summary>
        /// Gets or sets the maximum number of iterations for calculating fractal points.
        /// Minimum value is 50. Values below 50 will be clamped to 50.
        /// </summary>
        public int iteration
        {
            get
            {
                return _iteration;
            }
            set
            {
                _iteration = (value >= 50) ? value : 50;
            }
        }

        /// <summary>
        /// Gets or sets the escape radius (squared) for the fractal calculation.
        /// Minimum value is 4. Values below 4 will be clamped to 4.
        /// </summary>
        public int radius
        {
            get { return _radius; }
            set { _radius = (value >= 4) ? value : 4; }
        }

        /// <summary>
        /// Gets or sets the color scheme used for rendering the fractal.
        /// </summary>
        public FractalColor fractalColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the real part of the complex constant C for Julia sets.
        /// </summary>
        public double juliaX
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the imaginary part of the complex constant C for Julia sets.
        /// </summary>
        public double juliaY
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the resolution of the color palette.
        /// </summary>
        public ColorResulution colorResulution
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the color used for points inside the fractal set.
        /// </summary>
        public InnerColor innerColor
        {
            get;
            set;
        }

        #endregion

        #region Konstruktor

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsTemplate"/> class with specified parameters.
        /// </summary>
        /// <param name="fractal">The type of fractal.</param>
        /// <param name="zoom">The zoom level.</param>
        /// <param name="xDifference">The horizontal offset.</param>
        /// <param name="yDifference">The vertical offset.</param>
        /// <param name="resulution">The image resolution.</param>
        /// <param name="iteration">The maximum number of iterations.</param>
        /// <param name="radius">The escape radius (squared).</param>
        /// <param name="fractalColor">The fractal color scheme.</param>
        /// <param name="juliaX">The real part of the Julia constant C.</param>
        /// <param name="juliaY">The imaginary part of the Julia constant C.</param>
        /// <param name="colorResulution">The color palette resolution.</param>
        public SettingsTemplate(fraktal fractal, int zoom, double xDifference, double yDifference, int resulution, int iteration, int radius, FractalColor fractalColor, double juliaX, double juliaY, ColorResulution colorResulution)
        {
            this.fractal = fractal;
            this.zoom = zoom; // Setter will validate
            this.xDifference = xDifference;
            this.yDifference = yDifference;
            this.resulution = resulution; // Setter will validate
            this.iteration = iteration; // Setter will validate
            this.radius = radius; // Setter will validate
            this.fractalColor = fractalColor;
            this.juliaX = juliaX;
            this.juliaY = juliaY;
            this.colorResulution = colorResulution;
            // Assuming InnerColor is not part of this constructor, or set to a default.
            // If it needs to be in constructor, add it to parameters and this.innerColor = innerColor;
            this.innerColor = InnerColor.Black; // Default if not specified
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsTemplate"/> class with default values.
        /// </summary>
        public SettingsTemplate()
        {
            fractal = fraktal.Mandelbrot;
            xDifference = -0.75; // Changed default
            yDifference = 0;
            zoom = 1; // Changed default, setter will ensure it's >= 1
            resulution = 1024; // Setter will ensure it's >= 256
            iteration = 200; // Setter will ensure it's >= 50
            radius = 4; // Setter will ensure it's >= 4
            fractalColor = FractalColor.Blue;
            colorResulution = ColorResulution.Normal;
            innerColor = InnerColor.Black; // Default
            // juliaX and juliaY default to 0.0 which is fine.
            juliaX = 0.0;
            juliaY = 0.0;
        }

        #endregion
    }
}
