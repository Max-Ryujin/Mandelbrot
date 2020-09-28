using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        #region fields

        private DirectBitmap _dBitmap = new DirectBitmap(1000,1000);
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
            try
            {
                StreamReader sr = File.OpenText("settings.txt");
                settings = JsonSerializer.Deserialize<SettingsTemplate>(sr.ReadToEnd());
                sr.Close();
                CalculateUI();
                Logic.CalculateBitmap(dBitmap, settings);
                paint();
            }
            catch(Exception ex)
            {
                settings = new SettingsTemplate();
                StreamWriter streamWriter = File.CreateText("settings.txt");
                streamWriter.Write(JsonSerializer.Serialize(_settings));
                streamWriter.Close();
                CalculateUI();
                Logic.CalculateBitmap(dBitmap, settings);
                paint();
            }
        }
        #endregion
      
        #region event handler

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private async void ZoomTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int result;
                if (Int32.TryParse(ZoomTextbox.Text, out result))
                {
                    settings.zoom = result;                  
                }
            }
            catch(Exception ex)
            {
                ZoomTextbox.Text = "Error";
            }
        }

        private async void xValueTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int result;
                if (Int32.TryParse(xValueTextbox.Text, out result))
                {
                    settings.xDifference = result;
                }
                
            }
            catch (Exception ex)
            {
                xValueTextbox.Text = "Error";
            }
        }

        private async void yValueTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int result;
                if (Int32.TryParse(yValueTextbox.Text, out result))
                {
                    settings.yDifference = result;
                }
            }
            catch (Exception ex)
            {
                yValueTextbox.Text = "Error";
            }
        }

        private async void resulutionTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int result;
                if (Int32.TryParse(resulutionTextbox.Text, out result))
                {
                    settings.resulution = result;
                }
            }
            catch (Exception ex)
            {
                resulutionTextbox.Text = "Error";
            }

        }

        private void iterationTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int result;
                if (Int32.TryParse(iterationTextbox.Text, out result))
                {
                    if(result < 100)
                    {
                     iterationTextbox.Text = ""+100;
                    }
                    settings.iteration = result;
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

        public async void ColorManagement_PropertyChanged_Event(object sender, EventArgs e)
        {
            if (innerColorBlackButton.Checked)
            {
                settings.innerColor = Mandelbrot.InnerColor.Black;
            }
            else
            {
                settings.innerColor = Mandelbrot.InnerColor.White;
            }

            if(thickColorButton.Checked)
            {
                settings.colorResulution = ColorResulution.Thick;
            }
            else if(thinColorButton.Checked)
            {
                settings.colorResulution = ColorResulution.Thin;
            }
            else
            {
                settings.colorResulution = ColorResulution.Normal;
            }

            if(totalColorButton.Checked)
            {
                settings.fractalColor = FractalColor.Total;
            }
            else if(greenColorButton.Checked)
            {
                settings.fractalColor = FractalColor.Green;
            }
            else if(blueColorButton.Checked)
            {
                settings.fractalColor = FractalColor.Blue;
            }
            else
            {
                settings.fractalColor = FractalColor.Red;
            }
            await Task.Run(() => { Logic.CalculateBitmap(dBitmap, settings); });
            paint();
            Task.Run(() => serializeSettings());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { Logic.CalculateBitmap(dBitmap, settings); });
            paint();
            CalculateUI();
        }

        private async void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                double locationY = e.Location.Y * (settings.resulution / 1000.0);
                double locationX = e.Location.X * (settings.resulution / 1000.0);

                settings.xDifference = ((locationX - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.xDifference);
                settings.yDifference = ((locationY - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.yDifference);
                settings.zoom = settings.zoom * 2;
                settings.iteration += 100;
                CalculateUI();
                await Task.Run(() => { Logic.CalculateBitmap(dBitmap, settings); });
                paint();
                Task.Run(() => serializeSettings());
            }
            else if(e.Button == MouseButtons.Right)
            {
                double locationY = e.Location.Y * (settings.resulution / 1000.0);
                double locationX = e.Location.X * (settings.resulution / 1000.0);

                settings.xDifference = ((locationX - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.xDifference);
                settings.yDifference = ((locationY - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.yDifference);
                settings.zoom = (int)(settings.zoom * 0.5);
                settings.iteration -= 100;
                CalculateUI();
                await Task.Run(() => { Logic.CalculateBitmap(dBitmap, settings); });
                paint();
                Task.Run(() => serializeSettings());
            }
        }

        #endregion

        #region helper


        private void paint()
        {
            pictureBox1.Image = dBitmap.Bitmap;
            Refresh();
        }

        private void serializeSettings()
        {
            StreamWriter streamWriter = new StreamWriter("settings.txt");
            streamWriter.Write(JsonSerializer.Serialize<SettingsTemplate>(settings));
            streamWriter.Close();
        }

        private void CalculateUI()
        {
            ZoomTextbox.Text = settings.zoom.ToString();
            xValueTextbox.Text = settings.xDifference.ToString();
            yValueTextbox.Text = settings.yDifference.ToString();
            resulutionTextbox.Text = settings.resulution.ToString();
            ConvergenzRadiusTextbox.Text = settings.radius.ToString();
            iterationTextbox.Text = settings.iteration.ToString();
            if(settings.innerColor == Mandelbrot.InnerColor.Black)
            {
                innerColorBlackButton.Checked = true;
                innerColorWhiteButton.Checked = false;
            }
            else
            {
                innerColorWhiteButton.Checked = true;
                innerColorBlackButton.Checked = false;
            }
            switch(settings.fractalColor)
            {
                case FractalColor.Total:
                    totalColorButton.Checked = true;
                    break;
                case FractalColor.Red:
                    redColorButton.Checked = true;
                    break;
                case FractalColor.Blue:
                    blueColorButton.Checked = true;
                    break;
                case FractalColor.Green:
                    greenColorButton.Checked = true;
                    break;
            }
            if(settings.colorResulution == ColorResulution.Normal)
            {
                normalColorButton.Checked = true;
            }
            else if(settings.colorResulution == ColorResulution.Thin)
            {
                thinColorButton.Checked = true;
            }
            else
            {
                thickColorButton.Checked = true;
            }

        }

        #endregion

    }

}
