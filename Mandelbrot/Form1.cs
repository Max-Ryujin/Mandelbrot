using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;





namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        #region fields

        private DirectBitmap _dBitmap;
        public DirectBitmap dBitmap
        {
            get { return _dBitmap; }
            set
            {
                _dBitmap = value;
                paint();
            }
        }

        private SettingsTemplate _settings;
        public SettingsTemplate settings
        {
            get { return _settings; }
            set { _settings = value; }
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

        public void ColorManagement_PropertyChanged_Event(object sender, EventArgs e)
        {
            Logic.CalculateBitmap()
            paint();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Task t1 = Task.Run(() => { Logic.CalculateBitmap(dBitmap, resulution, zoom, xDifference, yDifference, convergenzRadius, Fractal, iteration); });
        }

        #endregion

        #region helper

        private void paint()
        {
            pictureBox1.Image = dBitmap.Bitmap;
            Refresh();
        }


        #endregion

       
    }

}
