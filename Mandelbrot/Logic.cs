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
        static void calculateMandelbrot(int resulution)
        {        
                for (int x = 0; x < resulution; x++)
                {
                    for (int y = 0; y < resulution; y++)
                    {
                        double xwert = ((x - (resulution / 2.0)) / (vergrößerung * 100.0)) + (xverschiebung);
                        double ywert = ((y - (resulution / 2.0)) / (vergrößerung * 100.0)) + (yverschiebung);

                        map[x, y] = mandelbrot(xwert, ywert, konvergenzradius);


                    }
                    double xx = x;

                }          
            else
            {
                for (int x = identifier; x < resulution; x += 3)
                {
                    for (int y = 0; y < resulution; y++)
                    {
                        double xwert = ((x - (resulution / 2.0)) / (vergrößerung * 100.0)) + (xverschiebung);
                        double ywert = ((y - (resulution / 2.0)) / (vergrößerung * 100.0)) + (yverschiebung);

                        map[x, y] = mandelbrot(xwert, ywert, konvergenzradius);


                    }
                    double xx = x;
                    ReportProgress((int)(((xx) / (resulution)) * 100.0), identifier);
                }
                ReportProgress(100, identifier);
            }
        }

        private void calculateJulia()
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

        public int julia(double x, double y, double x2, double y2, double m)
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

        public int mandelbrot(double x, double y, double m)
        {
            double xx = 0;
            double yy = 0;
            for (int i = 1; i <= iteration; i++)
            {
                double xtemp = xx;
                xx = (xx * xx) - (yy * yy) + x;

                yy = 2 * xtemp * yy + y;
                if (betrag(xx, yy) > m)
                {
                    return i;


                }
            }

            return -1;
        }

        public double betrag(double x, double y)
        {
            return ((x * x) + (y * y));
        }

        private Color calculateColor(int i)
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
