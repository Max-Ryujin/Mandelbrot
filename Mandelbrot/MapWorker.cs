using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Mandelbrot
{
    class MapWorker : BackgroundWorker
    {
        int[,] map;
        int xmin;
        int xmax;
        int auflösung;
        int iteration;
        double vergrößerung;
        double xverschiebung;
        double yverschiebung;
        int konvergenzradius = 50;
        bool Fraktalwahl = true;
        public MapWorker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public MapWorker(int xmin,int xmax,int auflösung, int iteration, double vergrößerung,double xverschiebung,double yverschiebung) : this()
        {
            this.map = new int[auflösung,auflösung];
            this.xmax = xmax;
            this.xmin = xmin;
            this.auflösung = auflösung;
            this.iteration = iteration;
            this.vergrößerung = vergrößerung;
            this.xverschiebung = xverschiebung;
            this.yverschiebung = yverschiebung;


        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            ReportProgress(0);
            if (CancellationPending)
            {
                 e.Cancel = true;
                 return;
            }
            calculate();
            e.Result = map;
        }

        private void calculate()
        {
            for(int x = 0; x< auflösung; x++)
            {
                for(int y = 0; y < auflösung;y++)
                {
                    double xwert = ((x - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (xverschiebung);
                    double ywert = ((y - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (yverschiebung);
                    
                    if (Fraktalwahl)
                    {
                        map[x,y] = mandelbrot(xwert, ywert, konvergenzradius);
                    }
                    else
                    {

                      //  value = julia(xwert, ywert, cx, cy, konvergenzradius);
                    }
                }
            }
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

       


    }
}
