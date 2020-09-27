using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
                   // calculateJulia(resulution, dBitmap, radius, zoom, xMovement, yMovement);
                }
            }
            catch (Exception ex)
            {

            }
        }

        static void calculateMandelbrot(DirectBitmap dMap, SettingsTemplate settings)
        {
            
            for (int x = 0; x < settings.resulution; x++)
            {

                    for (int y = 0; y < settings.resulution; y++)
                    {
                        // Calulate PixelPosition
                        double xwert = ((x - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.xDifference);
                        double ywert = ((y - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.yDifference);
                        //Calculate Pixel Color 
                        mandelbrot(dMap, xwert, ywert, settings, x, y);
                    }
                double xx = x;
            }
           
        }

        //private static void calculateJulia()
        //{

        //    for (int x = identifier; x < resulution; x += 3)
        //    {
        //        for (int y = 0; y < resulution; y++)
        //        {
        //            double xwert = ((x - (resulution / 2.0)) / (vergrößerung * 100.0)) + (xverschiebung);
        //            double ywert = ((y - (resulution / 2.0)) / (vergrößerung * 100.0)) + (yverschiebung);

        //            map[x, y] = julia(xwert, ywert, cx, cy, konvergenzradius);

        //        }
        //        double xx = x;   
        //    }
        //}

        //public static int julia(double x, double y, double x2, double y2, double m)
        //{
        //    for (int i = 1; i <= iteration; i++)
        //    {
        //        double xtemp = x;
        //        x = (x * x) - (y * y) + x2;

        //        y = 2 * xtemp * y + y2;
        //        if (betrag(x, x) > m)
        //        {
        //            return i;


        //        }
        //    }
        //    return -1;
        //}

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
