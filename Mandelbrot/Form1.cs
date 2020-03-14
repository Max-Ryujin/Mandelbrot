using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        int x, y;
        int iteration = 100;
        double vergrößerung = 1;
        double xverschiebung = 0;
        double yverschiebung = 0;
        int auflösung = 1000;
        Boolean Fraktalwahl = true;
        int xmin = 0;
        int xmax = 99;
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

        private void button1_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            xmin = 0;
            xmax = 99;
            vergrößerung = Double.Parse( textBox1.Text);
            xverschiebung = Double.Parse(textBox2.Text);
            yverschiebung = Double.Parse(textBox3.Text);
            auflösung = int.Parse(textBox4.Text);
            map = new Bitmap(auflösung, auflösung);
            iteration = int.Parse(textBox5.Text);
            Fraktalwahl = radioButton1.Checked;
            paint();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            x = 0;
            y = 0;
            xmin = 0;
            xmax = 99;

            if (map == null) { return; }

            double xposition = ((e.Location.X - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (xverschiebung);
            double yposition = ((e.Location.Y - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (yverschiebung);

            xverschiebung += (xposition - xverschiebung);
            yverschiebung += (yposition - yverschiebung);
            textBox2.Text = xverschiebung.ToString();
            textBox3.Text = yverschiebung.ToString();

            if (e.Button.ToString() == "Left")
            {


                iteration += 100;
                vergrößerung *= 2;
            }
            else
            {
                iteration -= 100;
                vergrößerung /= 2;
            }
            textBox5.Text = iteration.ToString();
            textBox1.Text = vergrößerung.ToString();

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
                    double xwert = ((x - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (xverschiebung);
                    double ywert = ((y - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (yverschiebung);
                    int value;
                    if (Fraktalwahl)
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
            if (xmax < auflösung) { paint(); }
            else
            {
                map.Save("file.png", ImageFormat.Png);
            }
        }

            
        
        
    }   
}
