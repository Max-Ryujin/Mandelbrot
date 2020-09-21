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
        /// Calulates the entire Bitmap
        /// </summary>
        /// <param name="dBitmap"></param>
        /// <param name="resulution"></param>
        /// <param name="zoom"></param>
        /// <param name="xMovement"></param>
        /// <param name="yMovement"></param>
        /// <param name="radius"></param>
        /// <param name="_fractal"></param>
        public static async void CalculateBitmap(DirectBitmap dBitmap, int resulution, int zoom, double xMovement, double yMovement, int radius, fraktal _fractal, int iteration)
        {
            try
            {
                if (_fractal == fraktal.Mandelbrot)
                {
                    //Calulate MandelBrot
                    calculateMandelbrot(resulution, dBitmap, radius, zoom, xMovement, yMovement, iteration);
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

        static async void calculateMandelbrot(int resulution, DirectBitmap dMap, int radius, int zoom, double xMovement, double yMovement, int iteration)
        {
            List<Task<Pixel>> PixelTasks = new List<Task<Pixel>>();
            for (int x = 0; x < resulution; x++)
            {
                for (int y = 0; y < resulution; y++)
                {
                    // Calulate PixelPosition
                    double xwert = ((x - (resulution / 2.0)) / (zoom * 100.0)) + (xMovement);
                    double ywert = ((y - (resulution / 2.0)) / (zoom * 100.0)) + (yMovement);
                    //Calculate Pixel Color 
                    PixelTasks.Add(mandelbrot(xwert, ywert, radius, iteration));
                }
                double xx = x;
            }
            while(PixelTasks.Count > 0)
            {
                Task<Pixel> finishedTask = await Task.WhenAny(PixelTasks);
                Pixel pixel = finishedTask.Result;
                dMap.SetPixel(pixel.x, pixel.y, pixel.color);
            }
           
        }

        private static void calculateJulia()
        {

            for (int x = identifier; x < resulution; x += 3)
            {
                for (int y = 0; y < resulution; y++)
                {
                    double xwert = ((x - (resulution / 2.0)) / (vergrößerung * 100.0)) + (xverschiebung);
                    double ywert = ((y - (resulution / 2.0)) / (vergrößerung * 100.0)) + (yverschiebung);

                    map[x, y] = julia(xwert, ywert, cx, cy, konvergenzradius);

                }
                double xx = x;
                ReportProgress((int)(((xx) / (resulution)) * 100.0), identifier);
            }
            ReportProgress(100, identifier);
        }

        public static int julia(double x, double y, double x2, double y2, double m)
        {
            for (int i = 1; i <= iteration; i++)
            {
                double xtemp = x;
                x = (x * x) - (y * y) + x2;

                y = 2 * xtemp * y + y2;
                if (betrag(x, x) > m)
                {
                    return i;


                }
            }
            return -1;
        }

        public static async Task<Pixel> mandelbrot(double x, double y, double radius, int iteration)
        {
            double xx = 0;
            double yy = 0;
            for (int i = 1; i <= iteration; i++)
            {
                double xtemp = xx;
                xx = (xx * xx) - (yy * yy) + x;

                yy = 2 * xtemp * yy + y;
                if (betrag(xx, yy) > radius)
                {
                    return i;


                }
            }

            return -1;
        }

        public static double betrag(double x, double y)
        {
            return ((x * x) + (y * y));
        }

        private static Color calculateColor(int i)
        {
            // inside
            if (i == -1)
            {
                if (radioButton3.Checked)
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
                // Absolut
                if (radioButton8.Checked)
                {
                    if (radioButton3.Checked)
                    {
                        return Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        return Color.FromArgb(0, 0, 0);
                    }
                }
                // Grün
                else if (radioButton9.Checked)
                {
                    int newi;
                    // Fein
                    if (radioButton5.Checked)
                    {
                        newi = ((i % 230) * 3) + 50;
                    }
                    // Medium
                    else if (radioButton6.Checked)
                    {
                        newi = ((i % 105) * 7) + 20;
                    }
                    //Grob
                    else
                    {
                        newi = ((i % 20) * 37) + 20;
                    }

                    if (newi > 510)
                    {
                        return Color.FromArgb(255, 255, newi - 510);
                    }
                    else if (newi > 255)
                    {
                        return Color.FromArgb(newi - 255, 255, 0);
                    }
                    else
                    {
                        return Color.FromArgb(0, newi, 0);
                    }
                }
                // Rot
                else if (radioButton11.Checked)
                {
                    int newi;
                    // Fein
                    if (radioButton5.Checked)
                    {
                        newi = ((i % 230) * 3) + 50;
                    }
                    // Medium
                    else if (radioButton6.Checked)
                    {
                        newi = ((i % 105) * 7) + 20;
                    }
                    //Grob
                    else
                    {
                        newi = ((i % 20) * 37) + 20;
                    }

                    if (newi > 510)
                    {
                        return Color.FromArgb(255, 255, newi - 510);
                    }
                    else if (newi > 255)
                    {
                        return Color.FromArgb(255, newi - 255, 0);
                    }
                    else
                    {
                        return Color.FromArgb(newi, 0, 0);
                    }
                }
                //blau
                else if (radioButton10.Checked)
                {
                    int newi;
                    // Fein
                    if (radioButton5.Checked)
                    {
                        newi = ((i % 230) * 3) + 50;
                    }
                    // Medium
                    else if (radioButton6.Checked)
                    {
                        newi = ((i % 105) * 7) + 20;
                    }
                    //Grob
                    else
                    {
                        newi = ((i % 20) * 37) + 20;
                    }

                    if (newi > 510)
                    {
                        return Color.FromArgb(newi - 510, 255, 255);
                    }
                    else if (newi > 255)
                    {
                        return Color.FromArgb(0, newi - 255, 255);
                    }
                    else
                    {
                        return Color.FromArgb(0, 0, newi);
                    }
                }
                else
                {
                    return Color.Black;
                }
            }
        }

    }
}
