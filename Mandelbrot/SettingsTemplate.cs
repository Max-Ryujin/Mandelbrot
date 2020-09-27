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

        public int zoom
        {
            get;
            set;
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

        public int iteration
        {
            get;
            set;
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
