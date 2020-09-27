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

        public fraktal fractal;

        public int zoom;

        public double xDifference;

        public double yDifference;

        public int resulution;

        public int iteration;

        public int radius;

        public FractalColor fractalColor;

        public double juliaX;

        public double juliaY;

        public ColorResulution colorResulution;

        public InnerColor innerColor;

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

        #endregion
    }
}
