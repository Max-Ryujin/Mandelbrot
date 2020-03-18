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
        int auflösung;
        int iteration;
        double vergrößerung;
        double xverschiebung;
        double yverschiebung;
        double cx, cy;
        int konvergenzradius = 50;
        bool Fraktalwahl = true;
        int identifier;
        int xmin;
        int xmax;

        #region Constructor

        public MapWorker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public MapWorker(
            int auflösung,
            int iteration,
            double vergrößerung,
            double xverschiebung,
            double yverschiebung,
            bool Fraktalwahl,
            double cx,
            double cy,
            int identifier,
            int xmin,
            int xmax
            ) : this()
        {
            this.map = new int[auflösung,auflösung];
            this.Fraktalwahl = Fraktalwahl;
            this.auflösung = auflösung;
            this.iteration = iteration;
            this.vergrößerung = vergrößerung;
            this.xverschiebung = xverschiebung;
            this.yverschiebung = yverschiebung;
            this.cx = cx;
            this.cy = cy;
            this.identifier = identifier;
            this.xmin = xmin;
            this.xmax = xmax;


        }
        #endregion

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            ReportProgress(0);
            if (CancellationPending)
            {
                 e.Cancel = true;
                 return;
            }
            if (Fraktalwahl)
            {
                calculateMandelbrot();
            }
            else
            {
                calculateJulia();
            }
            e.Result = map;
        }

        #region HilfsMethoden

        private void calculateMandelbrot()
        {
            for(int x = xmin; x< xmax; x++)
            {
                for(int y = 0; y < auflösung;y++)
                {
                    double xwert = ((x - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (xverschiebung);
                    double ywert = ((y - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (yverschiebung);
                    
                    map[x,y] = mandelbrot(xwert, ywert, konvergenzradius);
                   
                  
                }
                double xx = x;
                ReportProgress((int)((xx/auflösung)*100.0),identifier);
            }
            ReportProgress(100,identifier);
        }

        private void calculateJulia()
        {
            for (int x = xmin; x < xmax; x++)
            {
                for (int y = 0; y < auflösung; y++)
                {
                    double xwert = ((x - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (xverschiebung);
                    double ywert = ((y - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (yverschiebung);

                    map[x, y] = julia(xwert, ywert, cx, cy, konvergenzradius);
                   
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

        #endregion


    }
}
