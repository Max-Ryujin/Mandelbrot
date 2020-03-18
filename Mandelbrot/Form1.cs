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
        int x, y;
        int iteration = 100;
        double vergrößerung = 2;
        double xverschiebung = 0;
        double yverschiebung = 0;
        int auflösung = 1000;
        Thread th;
        Boolean isCalculating = false;
        Boolean Fraktalwahl = true;
        int xmin = 0;
        int xmax = 99;
        int konvergenzradius = 50;

        Bitmap map;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void setValues()
        {
            x = 0;
            y = 0;
            xmin = 0;
            xmax = 99;
            konvergenzradius = Int32.Parse(textBox6.Text);
            vergrößerung = Double.Parse(textBox1.Text);
            xverschiebung = Double.Parse(textBox2.Text);
            yverschiebung = Double.Parse(textBox3.Text);
            auflösung = int.Parse(textBox4.Text);
            map = new Bitmap(auflösung, auflösung);
            iteration = int.Parse(textBox5.Text);
            Fraktalwahl = radioButton1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            setValues();
            MapWorker worker = new MapWorker(xmin, xmax, auflösung, iteration, vergrößerung, xverschiebung, yverschiebung);
            worker.RunWorkerCompleted += mapWorkerCompleted;
            worker.RunWorkerAsync();

        }
        /*
                private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
                {
                    if (!isCalculating)
                    {
                        isCalculating = true;
                        x = 0;
                        y = 0;
                        xmin = 0;
                        xmax = 99;

                        if (map == null) { return; }
                        double locationY = e.Location.Y * (auflösung / 1000.0);
                        double locationX = e.Location.X * (auflösung / 1000.0);

                        double xposition = ((locationX - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (xverschiebung);
                        double yposition = ((locationY - (auflösung / 2.0)) / (vergrößerung * 100.0)) + (yverschiebung);
                        Console.WriteLine(e.Location.X);
                        Console.WriteLine(e.Location.Y);
                        Console.WriteLine(xposition);
                        Console.WriteLine(yposition);
                        xverschiebung = (xposition);
                        yverschiebung = (yposition);
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
                        isCalculating = false;
                    }
                }
                */
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label8.Text = trackBar1.Value / 100.0 + "";
            label9.Text = trackBar2.Value / 100.0 + "";
        }
        /*
                private void Form1_KeyDown(object sender, KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        setValues();
                        paint();
                    }
                }
        */
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PNG Image|*.png|Bitmap Image|*.bmp|Gif Image|*.gif|Jpg Image|*.jpg";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        map.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Png);
                        break;

                    case 2:
                        map.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        map.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case 4:
                        map.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                }

                fs.Close();
            }

        }

        private Color calculateColor(int i)
        {
            // inside
            if (i == -1)
            {
                if (radioButton3.Checked)
                {
                    return Color.FromArgb(0, 0, 0);
                }
                else
                {
                    return Color.FromArgb(255, 255, 255);
                }
            }
            //outside
            else
            {
                // Absolut
                if (radioButton8.Checked)
                {
                    if (radioButton3.Checked)
                    {
                        return Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        return Color.FromArgb(0, 0, 0);
                    }
                }
                // Grün
                else if (radioButton9.Checked)
                {
                    int newi;
                    // Fein
                    if (radioButton5.Checked)
                    {
                        newi = ((i % 230) * 3) + 50;
                    }
                    // Medium
                    else if (radioButton6.Checked)
                    {
                        newi = ((i % 105) * 7) + 20;
                    }
                    //Grob
                    else
                    {
                        newi = ((i % 20) * 37) + 20;
                    }

                    if (newi > 510)
                    {
                        return Color.FromArgb(255, 255, newi - 510);
                    }
                    else if (newi > 255)
                    {
                        return Color.FromArgb(newi - 255, 255, 0);
                    }
                    else
                    {
                        return Color.FromArgb(0, newi, 0);
                    }
                }
                // Rot
                else if (radioButton11.Checked)
                {
                    int newi;
                    // Fein
                    if (radioButton5.Checked)
                    {
                        newi = ((i % 230) * 3) + 50;
                    }
                    // Medium
                    else if (radioButton6.Checked)
                    {
                        newi = ((i % 105) * 7) + 20;
                    }
                    //Grob
                    else
                    {
                        newi = ((i % 20) * 37) + 20;
                    }

                    if (newi > 510)
                    {
                        return Color.FromArgb(255, 255, newi - 510);
                    }
                    else if (newi > 255)
                    {
                        return Color.FromArgb(255, newi - 255, 0);
                    }
                    else
                    {
                        return Color.FromArgb(newi, 0, 0);
                    }
                }
                //blau
                else if (radioButton10.Checked)
                {
                    int newi;
                    // Fein
                    if (radioButton5.Checked)
                    {
                        newi = ((i % 230) * 3) + 50;
                    }
                    // Medium
                    else if (radioButton6.Checked)
                    {
                        newi = ((i % 105) * 7) + 20;
                    }
                    //Grob
                    else
                    {
                        newi = ((i % 20) * 37) + 20;
                    }

                    if (newi > 510)
                    {
                        return Color.FromArgb(newi - 510, 255, 255);
                    }
                    else if (newi > 255)
                    {
                        return Color.FromArgb(0, newi - 255, 255);
                    }
                    else
                    {
                        return Color.FromArgb(0, 0, newi);
                    }
                }
                else
                {
                    return Color.Black;
                }
            }
        }

        public void paint(int[,] smap)
        {
            double cx, cy;
            cx = (trackBar1.Value / 100.0);
            cy = (trackBar2.Value / 100.0);


            for (int i = 0; i < smap.GetLength(0); i++)
            {

                for (int j = 0; j < smap.GetLength(1); j++)
                {
                    Color newColor;

                    newColor = calculateColor(smap[i, j]);




                    map.SetPixel(i, j, newColor);
                }
            }
            pictureBox1.Image = map;
            
            Refresh();


        }

        void mapWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Cancelled)
                {

                }
                else if (e.Error != null)
                {

                }
                else
                {

                    paint((int[,])e.Result);
                }
            }


        }
    
}
