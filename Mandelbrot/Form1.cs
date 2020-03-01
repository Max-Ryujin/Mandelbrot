using System;
using System.Drawing;

using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        int x, y;
        int iteration = 100;
        int vergrößerung = 2000;
        double xverschiebung = -1000;
        double yverschiebung = -1000;
        int auflösung = 1000;
        Boolean Fraktal = true;
        Bitmap map;
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public int julia(double x, double y, double x2,double y2,double m)
        {
            for (int i = 1; i <= iteration; i++)
            {
                double xtemp = x;
                x = (x * x) - (y * y) + x2;

                y = 2 * xtemp * y +y2;
                if (betrag(x, x) > m)
                {
                    return (i % 19) * 40;


                }
            }
            return 765;
        }

        public int mandelbrot(double x, double y, double m)
        {
            double xx = 0;
            double yy = 0;
            for (int i = 1; i <= iteration; i++)
            {
                double xtemp = xx;
                xx = (xx * xx) - (yy* yy) + x;          
                
                yy = 2 * xtemp * yy + y;
                if (betrag(xx, yy) > m)
                {
                    return (i%19)*40;
                    
                  
                }
            }
           
            return 765;
        }

        public double betrag(double x, double y)
        {
            return ((x* x) + (y* y));           
        }
        int xmin = 0;
        int xmax = 99;
        private void button1_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            xmin = 0;
            xmax = 99;
            vergrößerung = int.Parse( textBox1.Text);
            xverschiebung = Double.Parse(textBox2.Text);
            yverschiebung = Double.Parse(textBox3.Text);
            auflösung = int.Parse(textBox4.Text);
            map = new Bitmap(auflösung, auflösung);
            iteration = int.Parse(textBox5.Text);
            Fraktal = true;
            paint();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            xmin = 0;
            xmax = 99;
            vergrößerung = int.Parse(textBox1.Text);
            xverschiebung = Double.Parse(textBox2.Text);
            yverschiebung = Double.Parse(textBox3.Text);
            auflösung = int.Parse(textBox4.Text);
            map = new Bitmap(auflösung, auflösung);
            iteration = int.Parse(textBox5.Text);
            Fraktal = false;
            paint();
        }

      

        public void paint()
        {
            double cx, cy;
            cx = (trackBar1.Value/100.0);
            cy = (trackBar2.Value / 100.0);
          
           
            for (x = xmin; x <= xmax; x++)
            {
                for (y = 0; y < map.Height; y++)
                {
                    Color newColor;
                    double xwert = ((x - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (xverschiebung / 10.0);
                    double ywert = ((y - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (yverschiebung / 10.0);
                    int value;
                    if (Fraktal)
                    {
                        value = mandelbrot(xwert, ywert, 50);
                    }
                    else
                    {

                        value = julia(xwert, ywert, cx, cy, 50);
                    }
                    if (value > 510)
                    {
                        newColor = Color.FromArgb(255, 255, value - 510);
                    }
                    else if (value > 255)
                    {
                        newColor = Color.FromArgb(255, value - 255, 0);
                    }
                    else
                    {
                        newColor = Color.FromArgb(value, 0, 0);
                    }



                    map.SetPixel(x, y, newColor);
                }


            }
            xmin += 100;
            xmax += 100;

            pictureBox1.Image = map;
            Refresh();
            if (xmax < auflösung) paint();
        }

            
        
        
    }   
}
