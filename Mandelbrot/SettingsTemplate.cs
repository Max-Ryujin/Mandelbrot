using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    public class SettingsTemplate
    {
        #region fields

        public fraktal fractal
        {
            get;
            set;
        }

        private int _zoom;
        public int zoom
        {
            get               
            {
                return _zoom;
            }
            set 
            {
                if(value >= 1)
                {
                    _zoom = value;
                }
            }
        }

        public double xDifference
        {
            get;
            set;
        }

        public double yDifference
        {
            get;
            set;
        }

        public int resulution
        {
            get;
            set;
        }

        private int _iteration;
        public int iteration
        {
            get
            {
                return _iteration;
            }
            set
            {
                if(value>2)
                {
                    _iteration = value;
                }
            }
        }

        public int radius
        {
            get;
            set;
        }

        public FractalColor fractalColor
        {
            get;
            set;
        }

        public double juliaX
        {
            get;
            set;
        }

        public double juliaY
        {
            get;
            set;
        }

        public ColorResulution colorResulution
        {
            get;
            set;
        }

        public InnerColor innerColor
        {
            get;
            set;
        }

        #endregion

        #region Konstruktor

        public SettingsTemplate(fraktal fractal, int zoom, double xDifference, double yDifference, int resulution, int iteration, int radius, FractalColor fractalColor, double juliaX, double juliaY, ColorResulution colorResulution)
        {
            this.fractal = fractal;
            this.zoom = zoom;
            this.xDifference = xDifference;
            this.yDifference = yDifference;
            this.resulution = resulution;
            this.iteration = iteration;
            this.radius = radius;
            this.fractalColor = fractalColor;
            this.juliaX = juliaX;
            this.juliaY = juliaY;
            this.colorResulution = colorResulution;
        }

        public SettingsTemplate()
        {
            fractal = fraktal.Mandelbrot;
            xDifference = -0.4;
            yDifference = 0;
            zoom = 2;
            resulution = 1000;
            iteration = 200;
            radius = 50;
            fractalColor = FractalColor.Blue;
            colorResulution = ColorResulution.Normal;
        }

        #endregion
    }
}
