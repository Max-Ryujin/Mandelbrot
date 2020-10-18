using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Mandelbrot
{
    public static class Logic
    {
        /// <summary>
        /// Calculate entire Bitmap
        /// </summary>
        /// <param name="dBitmap"></param>
        /// <param name="settings"></param>
        public static async void CalculateBitmap(DirectBitmap dBitmap, SettingsTemplate settings)
        {
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
            catch (Exception ex)
            {

            }
        }
        
        static void calculateMandelbrot(DirectBitmap dMap, SettingsTemplate settings)
        {
            int zoomValue = settings.zoom * 100;
            Parallel.For(1, 1048577, ((i) => calculateMandelbrotPixel(dMap, settings, i,zoomValue)));
        }
        static private void calculateMandelbrotPixel(DirectBitmap dMap,SettingsTemplate settings,int workerNumber,int zoom)
        {
            int x = workerNumber / 1024;  // TODO change res to 1024 to use shifts. calculate zoom outside.
            int y = workerNumber % 1024;
            // Calulate PixelPosition   
            double xwert = ((x - (settings.resulution / 2.0)) / zoom) + (settings.xDifference);
            double ywert = ((y - (settings.resulution / 2.0)) / zoom) + settings.yDifference;
                       
            mandelbrot(dMap, xwert, ywert, settings, x, y);
                    

 
        }

        private static void calculateJulia(DirectBitmap dMap, SettingsTemplate settings)
        {
            Parallel.For(1, 1048577, ((i) => calculatejuliaPixel(dMap, settings, i)));
        }

        public static void calculatejuliaPixel(DirectBitmap dmap, SettingsTemplate settings, int workernumber)
        {
            int x = workernumber / 1024;  // TODO change res to 1024 to use shifts. calculate zoom outside.
            int y = workernumber % 1024;

            double xwert = ((x - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.xDifference);
            double ywert = ((y - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.yDifference);

            julia(dmap, settings, x, y, xwert, ywert);
        }

        public static void julia(DirectBitmap dmap, SettingsTemplate settings, int xpixel, int ypixel, double x, double y)
        {
            for (int i = 1; i <= settings.iteration; i++)
            {          
                double xtemp = x;
                x = (x * x) - (y * y) + settings.juliaX;

                y = 2 * xtemp * y + settings.juliaY;
                if (betrag(x, x) > settings.radius)
                {
                    dmap.SetPixel(xpixel, ypixel, calculateColor(i, settings));
                    return;
                }
            }
            dmap.SetPixel(xpixel, ypixel, calculateColor(-1, settings));
        }

        public static void mandelbrot(DirectBitmap dmap, double x, double y, SettingsTemplate settings,int xpixel,int ypixel)
        {
            double xx = 0;
            double yy = 0;
            for (int i = 1; i <= settings.iteration; i++)
            {
                double xtemp = xx;
                xx = (xx * xx) - (yy * yy) + x;

                yy = 2 * xtemp * yy + y;
                if (betrag(xx, yy) > settings.radius)
                {
                    dmap.SetPixel(xpixel,ypixel,calculateColor(i,settings));
                    return;
                }
            }

            dmap.SetPixel(xpixel, ypixel, calculateColor(-1, settings));
        }

        public static double betrag(double x, double y)
        {
            return ((x * x) + (y * y));
        }

        private static Color calculateColor(int i , SettingsTemplate settings)
        {
            // inside
            if (i == -1)
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
                        PixelValue = ((i % 230) * 3) + 50;
                        break;
                    case ColorResulution.Normal:
                        PixelValue = ((i % 105) * 7) + 20;
                        break;
                    case ColorResulution.Thick:
                        PixelValue = ((i % 20) * 37) + 20;
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
                }
                return Color.Black;
            }
        }

    }
}
