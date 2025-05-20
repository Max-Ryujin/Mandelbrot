using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Mandelbrot
{
    public static class Logic
    {
        /// <summary>
        /// Calculates the Mandelbrot or Julia fractal bitmap based on the provided settings.
        /// </summary>
        /// <param name="dBitmap">The DirectBitmap to draw the fractal on.</param>
        /// <param name="settings">The settings for fractal generation.</param>
        public static void CalculateBitmap(DirectBitmap dBitmap, SettingsTemplate settings)
        {
            if (dBitmap == null) throw new ArgumentNullException(nameof(dBitmap));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            try
            {
                if (settings.fractal == fraktal.Mandelbrot)
                {
                    //Calulate MandelBrot
                    calculateMandelbrot(dBitmap,settings);
                }
                else
                {
                    calculateJulia(dBitmap, settings);
                }
            }
            catch (Exception)
            {
                // Re-throw the exception to be caught by the UI layer
                throw;
            }
        }

        /// <summary>
        /// Calculates the Mandelbrot set for the given bitmap and settings.
        /// </summary>
        /// <param name="dMap">The DirectBitmap to draw on.</param>
        /// <param name="settings">The fractal settings.</param>
        static void calculateMandelbrot(DirectBitmap dMap, SettingsTemplate settings)
        {
            int zoomValue = settings.zoom * 100;
            int totalPixels = settings.resulution * settings.resulution;
            Parallel.For(0, totalPixels, ((i) => calculateMandelbrotPixel(dMap, settings, i, zoomValue)));
        }

        /// <summary>
        /// Calculates a single pixel for the Mandelbrot set.
        /// </summary>
        /// <param name="dMap">The DirectBitmap to draw on.</param>
        /// <param name="settings">The fractal settings.</param>
        /// <param name="workerNumber">The index of the pixel to calculate (flattens a 2D grid into 1D).</param>
        /// <param name="zoom">The pre-calculated zoom factor.</param>
        static private void calculateMandelbrotPixel(DirectBitmap dMap,SettingsTemplate settings,int workerNumber,int zoom)
        {
            int x = workerNumber / settings.resulution;
            int y = workerNumber % settings.resulution;
            // Calculate PixelPosition   
            double xwert = ((x - (settings.resulution / 2.0)) / zoom) + (settings.xDifference);
            double ywert = ((y - (settings.resulution / 2.0)) / zoom) + settings.yDifference;
            
            int iterations = mandelbrot_iterations(xwert, ywert, settings);
            dMap.SetPixel(x, y, calculateColor(iterations, settings));
        }

        /// <summary>
        /// Calculates the Julia set for the given bitmap and settings.
        /// </summary>
        /// <param name="dMap">The DirectBitmap to draw on.</param>
        /// <param name="settings">The fractal settings.</param>
        private static void calculateJulia(DirectBitmap dMap, SettingsTemplate settings)
        {
            int totalPixels = settings.resulution * settings.resulution;
            Parallel.For(0, totalPixels, ((i) => calculatejuliaPixel(dMap, settings, i)));
        }

        /// <summary>
        /// Calculates a single pixel for the Julia set.
        /// </summary>
        /// <param name="dmap">The DirectBitmap to draw on.</param>
        /// <param name="settings">The fractal settings.</param>
        /// <param name="workernumber">The index of the pixel to calculate (flattens a 2D grid into 1D).</param>
        public static void calculatejuliaPixel(DirectBitmap dmap, SettingsTemplate settings, int workernumber)
        {
            int x = workernumber / settings.resulution;
            int y = workernumber % settings.resulution;

            double xwert = ((x - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.xDifference);
            double ywert = ((y - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.yDifference);

            int iterations = julia_iterations(xwert, ywert, settings);
            dmap.SetPixel(x, y, calculateColor(iterations, settings));
        }

        /// <summary>
        /// Calculates the number of iterations for a point in the Julia set.
        /// </summary>
        /// <param name="x_val">The initial x-value in the complex plane for the point being tested.</param>
        /// <param name="y_val">The initial y-value in the complex plane for the point being tested.</param>
        /// <param name="settings">The fractal settings, including Julia constants (juliaX, juliaY).</param>
        /// <returns>The number of iterations before escaping, or -1 if it does not escape within the limit.</returns>
        public static int julia_iterations(double x_val, double y_val, SettingsTemplate settings)
        {
            double current_x = x_val;
            double current_y = y_val;

            for (int i = 1; i <= settings.iteration; i++)
            {          
                double xtemp = current_x;
                current_x = (current_x * current_x) - (current_y * current_y) + settings.juliaX;
                current_y = 2 * xtemp * current_y + settings.juliaY;

                if (betrag(current_x, current_y) > settings.radius)
                {
                    return i; // Escaped
                }
            }
            return -1; // Did not escape
        }

        /// <summary>
        /// Calculates the number of iterations for a point in the Mandelbrot set.
        /// </summary>
        /// <param name="x_coord">The x-coordinate in the complex plane (c_real).</param>
        /// <param name="y_coord">The y-coordinate in the complex plane (c_imaginary).</param>
        /// <param name="settings">The fractal settings.</param>
        /// <returns>The number of iterations before escaping, or -1 if it does not escape within the limit.</returns>
        public static int mandelbrot_iterations(double x_coord, double y_coord, SettingsTemplate settings)
        {
            double z_real = 0; 
            double z_imaginary = 0; 
            for (int i = 1; i <= settings.iteration; i++)
            {
                double xtemp = z_real;
                z_real = (z_real * z_real) - (z_imaginary * z_imaginary) + x_coord;
                z_imaginary = 2 * xtemp * z_imaginary + y_coord;    
                if (betrag(z_real, z_imaginary) > settings.radius)
                {
                    return i; // Escaped
                }
            }
            return -1; // Did not escape
        }

        /// <summary>
        /// Calculates the squared magnitude (or modulus) of a complex number represented by (x, y).
        /// This is equivalent to x^2 + y^2.
        /// </summary>
        /// <param name="x">The real part of the complex number.</param>
        /// <param name="y">The imaginary part of the complex number.</param>
        /// <returns>The squared magnitude of the complex number.</returns>
        public static double betrag(double x, double y)
        {
            return ((x * x) + (y * y));
        }

        /// <summary>
        /// Calculates the color of a pixel based on the iteration count.
        /// </summary>
        /// <param name="iterations">The iteration count. -1 indicates the point is inside the set.</param>
        /// <param name="settings">The fractal settings, including color scheme.</param>
        /// <returns>The color for the pixel.</returns>
        private static Color calculateColor(int iterations , SettingsTemplate settings)
        {
            // inside
            if (iterations == -1)
            {
                if (settings.innerColor == InnerColor.Black)
                {
                    return Color.FromArgb(0, 0, 0);
                }
                else
                {
                    return Color.FromArgb(255, 255, 255);
                }
            }
            //outside
            else
            {
                int PixelValue=0;
                switch (settings.colorResulution)
                {
                    case ColorResulution.Thin:
                        PixelValue = ((iterations % 230) * 3) + 50;
                        break;
                    case ColorResulution.Normal:
                        PixelValue = ((iterations % 105) * 7) + 20;
                        break;
                    case ColorResulution.Thick:
                        PixelValue = ((iterations % 20) * 37) + 20;
                        break;
                    default: // Should not happen with enum
                        PixelValue = ((iterations % 105) * 7) + 20; 
                        break;
                }

                switch (settings.fractalColor)
                {
                    case FractalColor.Total:
                        if (settings.innerColor == InnerColor.Black)
                        {
                            return Color.FromArgb(255, 255, 255);
                        }
                        else
                        {
                            return Color.FromArgb(0, 0, 0);
                        }

                    case FractalColor.Green:
                        
                        if (PixelValue > 510)
                        {
                            return Color.FromArgb(255, 255, PixelValue - 510);
                        }
                        else if (PixelValue > 255)
                        {
                            return Color.FromArgb(PixelValue - 255, 255, 0);
                        }
                        else
                        {
                            return Color.FromArgb(0, PixelValue, 0);
                        }

                    case FractalColor.Red:
                        if (PixelValue > 510)
                        {
                            return Color.FromArgb(255, 255, PixelValue - 510);
                        }
                        else if (PixelValue > 255)
                        {
                            return Color.FromArgb(255, PixelValue - 255, 0);
                        }
                        else
                        {
                            return Color.FromArgb(PixelValue, 0, 0);
                        }
                       
                     case FractalColor.Blue:
                        if (PixelValue > 510)
                        {
                            return Color.FromArgb(PixelValue - 510, 255, 255);
                        }
                        else if (PixelValue > 255)
                        {
                            return Color.FromArgb(0, PixelValue - 255, 255);
                        }
                        else
                        {
                            return Color.FromArgb(0, 0, PixelValue);
                        }
                    default:
                        // This case should ideally not be reached if all enum values are handled.
                        // Consider logging an error or throwing an exception for unexpected enum values.
                        throw new ArgumentOutOfRangeException(nameof(settings.fractalColor), $"Unsupported fractal color: {settings.fractalColor}");
                }
                //The following line should be unreachable due to the default case in the switch statement.
                //return Color.Black; 
            }
        }
    }
}
