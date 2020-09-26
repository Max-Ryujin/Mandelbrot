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

        fraktal fractal;

        int zoom;

        double xDifference;

        double yDifference;

        int resulution;

        int iteration;

        int radius;

        FractalColor fractalColor;

        double juliaX;

        double juliaY;

        ColorResulution colorResulution;

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
