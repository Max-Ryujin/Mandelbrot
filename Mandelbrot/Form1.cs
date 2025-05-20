using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Drawing; // Required for System.Drawing.Size

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        #region fields

        private DirectBitmap _dBitmap; // Initialized in constructor or InitializeBitmap()
        public DirectBitmap dBitmap
        {
            get { return _dBitmap; }
            set
            {
                // This setter should be used carefully. If the new bitmap has a different resolution,
                // the PictureBox might need resizing. For now, resolution changes are handled
                // primarily through resulutionTextbox_TextChanged and Apply button.
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
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Loads settings, initializes the UI and bitmap, and performs the initial fractal calculation.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            try
            {
                // It's better to initialize settings object first.
                _settings = new SettingsTemplate(); // Initialize with defaults first

                if (File.Exists("settings.txt")) // Check if file exists before trying to open
                {
                    StreamReader sr = File.OpenText("settings.txt");
                    string settingsJson = sr.ReadToEnd();
                    sr.Close();
                    if (!string.IsNullOrWhiteSpace(settingsJson))
                    {
                        // It's good practice to catch JsonException specifically if parsing fails
                        _settings = JsonSerializer.Deserialize<SettingsTemplate>(settingsJson);
                    }
                }
                // Initialize bitmap AFTER settings are loaded/defaulted
                InitializeBitmap(); 
                CalculateUI(); // Update UI from settings
                
                // Initial calculation
                Logic.CalculateBitmap(dBitmap, settings); // No Task.Run here, constructor can do initial work
                paint(); 
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show($"Error reading settings file: {jsonEx.Message}. Using default settings.", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _settings = new SettingsTemplate(); // Ensure settings is reset to default
                InitializeBitmap(); // Re-initialize bitmap with default resolution
                CalculateUI();
                // Optionally, try to save the default settings now
                try { serializeSettings(); } catch (Exception exSave) { /* Log or ignore saving error */ }
                // Recalculate with default settings
                try { Logic.CalculateBitmap(dBitmap, settings); paint(); } catch (Exception exCalc) { MessageBox.Show($"Error calculating fractal during startup: {exCalc.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (Exception ex) // Catch other potential startup errors
            {
                MessageBox.Show($"An error occurred during startup: {ex.Message}. Using default settings.", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _settings = new SettingsTemplate(); // Ensure settings is reset to default
                InitializeBitmap(); // Re-initialize bitmap with default resolution
                CalculateUI();
                try { serializeSettings(); } catch (Exception exSave) { /* Log or ignore saving error */ }
                try { Logic.CalculateBitmap(dBitmap, settings); paint(); } catch (Exception exCalc) { MessageBox.Show($"Error calculating fractal during startup: {exCalc.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        #endregion
      
        #region event handler
        // No Form1_Load logic needed for now.
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// Handles the CheckedChanged event for the fractal type radio buttons.
        /// Updates the fractal type in settings and triggers a recalculation.
        /// </summary>
        private async void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                settings.fractal = fraktal.Mandelbrot;
            }
            else
            {
                settings.fractal = fraktal.Julia;
            }
            try
            {
                await Task.Run(() => { Logic.CalculateBitmap(dBitmap, settings); });
                paint(); // paint only on success
            }
            catch (Exception calcEx)
            {
                MessageBox.Show($"Error calculating fractal: {calcEx.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Task.Run(() => serializeSettings()); // This can remain as is or also get a try-catch
        }

        /// <summary>
        /// Handles the TextChanged event for the Zoom textbox.
        /// Updates the zoom setting, ensuring it's at least 1.
        /// Shows an error message for invalid input.
        /// </summary>
        private void ZoomTextbox_TextChanged(object sender, EventArgs e)
        {
            string previousValue = settings.zoom.ToString();
            if (int.TryParse(ZoomTextbox.Text, out int result))
            {
                if (result < 1) result = 1; // Apply correction
                settings.zoom = result;
                if (settings.zoom.ToString() != ZoomTextbox.Text) // Update textbox if value was corrected
                {
                    ZoomTextbox.Text = settings.zoom.ToString();
                }
            }
            else if (!string.IsNullOrEmpty(ZoomTextbox.Text)) // Avoid error message on initial empty field or programmatic clear
            {
                MessageBox.Show("Invalid input for Zoom. Please enter a valid integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ZoomTextbox.Text = previousValue; // Revert
            }
        }

        /// <summary>
        /// Handles the TextChanged event for the X Value textbox.
        /// Updates the xDifference setting.
        /// Shows an error message for invalid input.
        /// </summary>
        private void xValueTextbox_TextChanged(object sender, EventArgs e)
        {
            string previousValue = settings.xDifference.ToString();
            if (double.TryParse(xValueTextbox.Text, out double result))
            {
                settings.xDifference = result;
            }
            else if (!string.IsNullOrEmpty(xValueTextbox.Text))
            {
                MessageBox.Show("Invalid input for X value. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xValueTextbox.Text = previousValue; // Revert
            }
        }

        /// <summary>
        /// Handles the TextChanged event for the Y Value textbox.
        /// Updates the yDifference setting.
        /// Shows an error message for invalid input.
        /// </summary>
        private void yValueTextbox_TextChanged(object sender, EventArgs e)
        {
            string previousValue = settings.yDifference.ToString();
            if (double.TryParse(yValueTextbox.Text, out double result))
            {
                settings.yDifference = result;
            }
            else if (!string.IsNullOrEmpty(yValueTextbox.Text))
            {
                MessageBox.Show("Invalid input for Y value. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                yValueTextbox.Text = previousValue; // Revert
            }
        }

        /// <summary>
        /// Handles the TextChanged event for the Resolution textbox.
        /// Updates the resolution setting. Shows an error for invalid input.
        /// Actual bitmap re-initialization happens on "Apply" button click.
        /// </summary>
        private void resulutionTextbox_TextChanged(object sender, EventArgs e)
        {
            string previousValue = settings.resulution.ToString();
            if (int.TryParse(resulutionTextbox.Text, out int newResolution))
            {
                if (newResolution > 0) 
                {
                    settings.resulution = newResolution;
                }
                else
                {
                    MessageBox.Show("Resolution must be a positive integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resulutionTextbox.Text = previousValue;
                }
            }
            else if (!string.IsNullOrEmpty(resulutionTextbox.Text))
            {
                MessageBox.Show("Invalid input for Resolution. Please enter a valid integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resulutionTextbox.Text = previousValue;
            }
        }

        /// <summary>
        /// Handles the TextChanged event for the Iteration textbox.
        /// Updates the iteration setting, ensuring it's at least 100.
        /// Shows an error message for invalid input.
        /// </summary>
        private void iterationTextbox_TextChanged(object sender, EventArgs e)
        {
            string previousValue = settings.iteration.ToString();
            if (int.TryParse(iterationTextbox.Text, out int result))
            {
                if (result < 100)
                {
                    result = 100; // Correct the value
                }
                settings.iteration = result;
                if (settings.iteration.ToString() != iterationTextbox.Text) // Update textbox if value was corrected
                {
                    iterationTextbox.Text = settings.iteration.ToString();
                }
            }
            else if (!string.IsNullOrEmpty(iterationTextbox.Text))
            {
                MessageBox.Show("Invalid input for Iterations. Please enter a valid integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iterationTextbox.Text = previousValue; // Revert
            }
        }

        /// <summary>
        /// Handles the TextChanged event for the Convergence Radius textbox.
        /// Updates the radius setting, ensuring it's at least 4.
        /// Shows an error message for invalid input.
        /// </summary>
        private void ConvergenzRadiusTextbox_TextChanged(object sender, EventArgs e)
        {
            string previousValue = settings.radius.ToString();
            if (int.TryParse(ConvergenzRadiusTextbox.Text, out int result))
            {
                if (result < 4)
                {
                    result = 4; // Correct the value
                }
                settings.radius = result;
                if (settings.radius.ToString() != ConvergenzRadiusTextbox.Text) // Update textbox if value was corrected
                {
                    ConvergenzRadiusTextbox.Text = settings.radius.ToString();
                }
            }
            else if (!string.IsNullOrEmpty(ConvergenzRadiusTextbox.Text))
            {
                MessageBox.Show("Invalid input for Convergence Radius. Please enter a valid integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConvergenzRadiusTextbox.Text = previousValue; // Revert
            }
        }
        /// <summary>
        /// Handles CheckedChanged event for radio buttons that toggle expert settings visibility.
        /// </summary>
        private void RadioButtonSetting_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton12.Checked) // Assuming radioButton12 is "Expert Settings"
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

        /// <summary>
        /// Handles property changed events from color selection controls.
        /// Updates color settings and triggers a fractal recalculation.
        /// </summary>
        public async void ColorManagement_PropertyChanged_Event(object sender, EventArgs e)
        {
            // This method handles changes from any of the color radio buttons.
            if (innerColorBlackButton.Checked) settings.innerColor = Mandelbrot.InnerColor.Black;
            else settings.innerColor = Mandelbrot.InnerColor.White;

            if (thickColorButton.Checked) settings.colorResulution = ColorResulution.Thick;
            else if (thinColorButton.Checked) settings.colorResulution = ColorResulution.Thin;
            else settings.colorResulution = ColorResulution.Normal;

            if (totalColorButton.Checked) settings.fractalColor = FractalColor.Total;
            else if (greenColorButton.Checked) settings.fractalColor = FractalColor.Green;
            else if (blueColorButton.Checked) settings.fractalColor = FractalColor.Blue;
            else settings.fractalColor = FractalColor.Red; // Default or last option

            try
            {
                await Task.Run(() => { Logic.CalculateBitmap(dBitmap, settings); });
                paint();
            }
            catch (Exception calcEx)
            {
                MessageBox.Show($"Error calculating fractal: {calcEx.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Task.Run(() => serializeSettings());
        }

        /// <summary>
        /// Handles the Click event for the "Apply" button.
        /// Updates UI from settings, re-initializes bitmap if resolution changed,
        /// and triggers fractal recalculation.
        /// </summary>
        private async void button1_Click(object sender, EventArgs e)
        {
            CalculateUI(); // Syncs settings from textboxes one last time if user typed and didn't tab out.
                           // Also ensures settings object is the source of truth for below checks.

            // Check if bitmap dimensions match current settings resolution
            if (_dBitmap == null || _dBitmap.Width != settings.resulution || _dBitmap.Height != settings.resulution)
            {
                InitializeBitmap(); // Re-create bitmap with new resolution
            }
            
            try
            {
                await Task.Run(() => { Logic.CalculateBitmap(dBitmap, settings); });
                paint();
            }
            catch (Exception calcEx)
            {
                MessageBox.Show($"Error calculating fractal: {calcEx.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Task.Run(() => serializeSettings());
        }

        /// <summary>
        /// Handles mouse clicks on the PictureBox for zooming and repositioning.
        /// Corrects mouse coordinates and triggers fractal recalculation.
        /// </summary>
        private async void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Direct pixel coordinates, assuming PictureBoxSizeMode.Normal and PictureBox size matches bitmap size.
            double locationY = e.Location.Y;
            double locationX = e.Location.X;

            if (e.Button == MouseButtons.Left) // Zoom In
            {
                settings.xDifference = ((locationX - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.xDifference);
                settings.yDifference = ((locationY - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.yDifference);
                settings.zoom = settings.zoom * 2;
                if (settings.zoom < 1) settings.zoom = 1; // Ensure zoom doesn't become too small (though *2 should not do this unless initial is <1)
                settings.iteration += 100;
            }
            else if (e.Button == MouseButtons.Right) // Zoom Out
            {
                settings.xDifference = ((locationX - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.xDifference);
                settings.yDifference = ((locationY - (settings.resulution / 2.0)) / (settings.zoom * 100.0)) + (settings.yDifference);
                settings.zoom = (int)(settings.zoom * 0.5);
                if (settings.zoom < 1) settings.zoom = 1; // Prevent zoom from becoming zero or negative
                settings.iteration -= 100;
                if (settings.iteration < 100) settings.iteration = 100; // Prevent iterations from becoming too low
            }

            CalculateUI(); // Update UI elements with new settings values

            try
            {
                await Task.Run(() => { Logic.CalculateBitmap(dBitmap, settings); });
                paint();
            }
            catch (Exception calcEx)
            {
                MessageBox.Show($"Error calculating fractal: {calcEx.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Task.Run(() => serializeSettings());
        }

        /// <summary>
        /// Handles scroll event for Julia X trackbar. Updates setting.
        /// Note: Recalculation for Julia parameters might need an "Apply" or happen on MouseUp.
        /// For now, just updates setting. UI will reflect change. Apply button will use it.
        /// </summary>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            settings.juliaX = trackBar1.Value / 100.0;
            labelJuliaX.Text = settings.juliaX.ToString("F2"); // Format for better display          
        }

        /// <summary>
        /// Handles scroll event for Julia Y trackbar. Updates setting.
        /// </summary>
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            settings.juliaY = trackBar2.Value / 100.0;
            labelJuliaY.Text = settings.juliaY.ToString("F2"); // Format for better display       
        }

        #endregion

        #region helper

        /// <summary>
        /// Initializes or re-initializes the DirectBitmap object based on current settings resolution.
        /// Disposes the old bitmap if it exists and resizes the PictureBox.
        /// </summary>
        private void InitializeBitmap()
        {
            _dBitmap?.Dispose(); // Dispose if already exists
            _dBitmap = new DirectBitmap(settings.resulution, settings.resulution);
            pictureBox1.Width = settings.resulution;
            pictureBox1.Height = settings.resulution;
            // Assuming PictureBox is not docked/anchored in a way that prevents this sizing.
            // Form size might need adjustment if PictureBox size exceeds Form client area.
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal; // Ensures 1:1 pixel mapping
        }

        /// <summary>
        /// Updates the PictureBox with the current bitmap and refreshes the display.
        /// </summary>
        private void paint()
        {
            if (dBitmap != null && dBitmap.Bitmap != null)
            {
                pictureBox1.Image = dBitmap.Bitmap;
                // Refresh might not be necessary if PictureBox updates automatically.
                // However, it ensures the changes are drawn.
                pictureBox1.Refresh(); // Use pictureBox1.Refresh() for targeted refresh.
            }
        }

        /// <summary>
        /// Serializes the current settings to a "settings.txt" file.
        /// Includes basic error handling for file operations.
        /// </summary>
        private void serializeSettings()
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter("settings.txt"); // Overwrites if exists, creates if not
                streamWriter.Write(JsonSerializer.Serialize<SettingsTemplate>(settings));
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                // Log or inform user about saving error, but don't crash.
                Console.WriteLine($"Error saving settings: {ex.Message}"); // Example: Log to console
                // Optionally: MessageBox.Show($"Could not save settings: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Updates the UI elements (textboxes, radio buttons, etc.) to reflect the current values in the `settings` object.
        /// </summary>
        private void CalculateUI()
        {
            // Update textboxes
            ZoomTextbox.Text = settings.zoom.ToString();
            xValueTextbox.Text = settings.xDifference.ToString("F5"); // Use format specifier for doubles if desired
            yValueTextbox.Text = settings.yDifference.ToString("F5");
            resulutionTextbox.Text = settings.resulution.ToString();
            ConvergenzRadiusTextbox.Text = settings.radius.ToString();
            iterationTextbox.Text = settings.iteration.ToString();

            // Update inner color radio buttons
            if (settings.innerColor == Mandelbrot.InnerColor.Black) innerColorBlackButton.Checked = true;
            else innerColorWhiteButton.Checked = true;
            
            // Update fractal color radio buttons
            switch (settings.fractalColor)
            {
                case FractalColor.Total: totalColorButton.Checked = true; break;
                case FractalColor.Red: redColorButton.Checked = true; break;
                case FractalColor.Blue: blueColorButton.Checked = true; break;
                case FractalColor.Green: greenColorButton.Checked = true; break;
                default: totalColorButton.Checked = true; break; // Default case
            }

            // Update color resolution radio buttons
            switch (settings.colorResulution)
            {
                case ColorResulution.Normal: normalColorButton.Checked = true; break;
                case ColorResulution.Thin: thinColorButton.Checked = true; break;
                case ColorResulution.Thick: thickColorButton.Checked = true; break;
                default: normalColorButton.Checked = true; break; // Default case
            }

            // Update fractal type radio buttons
            if (settings.fractal == fraktal.Mandelbrot) radioButton1.Checked = true;
            else radioButton2.Checked = true;
            
            // Update Julia trackbars and labels
            // Ensure value is within trackbar Min/Max
            int juliaXVal = (int)(settings.juliaX * 100.0);
            trackBar1.Value = Math.Max(trackBar1.Minimum, Math.Min(trackBar1.Maximum, juliaXVal));
            labelJuliaX.Text = (trackBar1.Value / 100.0).ToString("F2");

            int juliaYVal = (int)(settings.juliaY * 100.0);
            trackBar2.Value = Math.Max(trackBar2.Minimum, Math.Min(trackBar2.Maximum, juliaYVal));
            labelJuliaY.Text = (trackBar2.Value / 100.0).ToString("F2");
        }


        #endregion

       
    }

}
