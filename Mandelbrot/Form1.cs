using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;




namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        #region fields

        private DirectBitmap _dBitmap;
        public DirectBitmap dBitmap
        {
            get { return _dBitmap; }
            set { _dBitmap = value; }
        }

        private int _iteration;
        public int iteration
        {
            get { return _iteration; }
            set { _iteration = value; }
        }

        private double _zoomValue;
        public double zoomValue
        {
            get { return _zoomValue; }
            set { _zoomValue = value; }
        }

        private double _xverschiebung = 0;
        public double xDifference
        {
            get { return _xverschiebung; }
            set { _xverschiebung = value; }
        }

        private double _yverschiebung = 0;
        public double yDifference
        {
            get { return _yverschiebung; }
            set { _yverschiebung = value; }
        }

        private int _auflösung;
        public int resulution
        {
            get { return _auflösung; }
            set
            {
                _auflösung = value;
                dBitmap.Dispose();
                dBitmap = new DirectBitmap(_auflösung, _auflösung);
            }
        }

 
        private int _konvergenzradius;
        public int convergenzRadius
        {
            get { return _konvergenzradius; }
            set { _konvergenzradius = value; }
        }

        fraktal _Fraktalwahl;
        public enum fraktal
        {
            Mandelbrot,
            Julia
        }
        public fraktal Fractal
        {
            get { return _Fraktalwahl; }
            set { _Fraktalwahl = value; }
        }

        
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion
      
        #region event handler

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ZoomTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int result;
                if (Int32.TryParse(ZoomTextbox.Text, out result))
                {
                    zoomValue = result;
                }
                else
                {
                    ZoomTextbox.Text = "Fehler";
                }
            }
            catch(Exception ex)
            {
                ZoomTextbox.Text = "Error";
            }
        }

        private void xValueTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int result;
                if (Int32.TryParse(xValueTextbox.Text, out result))
                {
                    xDifference = result;
                }
                else
                {
                    xValueTextbox.Text = "Fehler";
                }
            }
            catch (Exception ex)
            {
                xValueTextbox.Text = "Error";
            }
        }

        private void yValueTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int result;
                if (Int32.TryParse(yValueTextbox.Text, out result))
                {
                    yDifference = result;
                }
                else
                {
                    yValueTextbox.Text = "Fehler";
                }
            }
            catch (Exception ex)
            {
                yValueTextbox.Text = "Error";
            }
        }

        private void resulutionTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int result;
                if (Int32.TryParse(resulutionTextbox.Text, out result))
                {
                    resulution = result;
                }
                else
                {
                    resulutionTextbox.Text = "Fehler";
                }
            }
            catch (Exception ex)
            {
                resulutionTextbox.Text = "Error";
            }

        }

        private void RadioButtonSetting_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton12.Checked)
            {
                resulutionTextbox.Enabled = true;
                iterationTextbox.Enabled = true;
                ConvergenzRadiusTextbox.Enabled = true;

            }
            else
            {
                resulutionTextbox.Enabled = false;
                iterationTextbox.Enabled = false;
                ConvergenzRadiusTextbox.Enabled = false;
            }
        }

        #endregion

        #region helper

        private void paint(int[,] smap, int workernumber)
        {
            pictureBox1.Image = dBitmap.Bitmap;
            Refresh();
        }

        public void CalculateBitmap()
        {
            try
            {
                if (Fractal == fraktal.Mandelbrot)
                {

                }
                else
                {

                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion


    }

}
