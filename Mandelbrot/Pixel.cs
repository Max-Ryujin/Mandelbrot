using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    public class Pixel
    {
        public Pixel(int x, int y ,Color color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public int x;
        public int y;
        public Color color;
    }
}
