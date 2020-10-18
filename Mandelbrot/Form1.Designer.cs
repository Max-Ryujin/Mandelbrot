namespace Mandelbrot
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ZoomTextbox = new System.Windows.Forms.TextBox();
            this.xValueTextbox = new System.Windows.Forms.TextBox();
            this.yValueTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.resulutionTextbox = new System.Windows.Forms.TextBox();
            this.iterationTextbox = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelJuliaX = new System.Windows.Forms.Label();
            this.labelJuliaY = new System.Windows.Forms.Label();
            this.ConvergenzRadiusTextbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.redColorButton = new System.Windows.Forms.RadioButton();
            this.blueColorButton = new System.Windows.Forms.RadioButton();
            this.greenColorButton = new System.Windows.Forms.RadioButton();
            this.totalColorButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.thickColorButton = new System.Windows.Forms.RadioButton();
            this.normalColorButton = new System.Windows.Forms.RadioButton();
            this.thinColorButton = new System.Windows.Forms.RadioButton();
            this.InnerColor = new System.Windows.Forms.GroupBox();
            this.innerColorWhiteButton = new System.Windows.Forms.RadioButton();
            this.innerColorBlackButton = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.InnerColor.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2048, 1969);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2198, 1031);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(660, 242);
            this.button1.TabIndex = 1;
            this.button1.Text = "Paint";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ZoomTextbox
            // 
            this.ZoomTextbox.Location = new System.Drawing.Point(2252, 37);
            this.ZoomTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.ZoomTextbox.Name = "ZoomTextbox";
            this.ZoomTextbox.Size = new System.Drawing.Size(114, 31);
            this.ZoomTextbox.TabIndex = 2;
            this.ZoomTextbox.Text = "2";
            this.ZoomTextbox.TextChanged += new System.EventHandler(this.ZoomTextbox_TextChanged);
            // 
            // xValueTextbox
            // 
            this.xValueTextbox.Location = new System.Drawing.Point(2252, 117);
            this.xValueTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.xValueTextbox.Name = "xValueTextbox";
            this.xValueTextbox.Size = new System.Drawing.Size(114, 31);
            this.xValueTextbox.TabIndex = 3;
            this.xValueTextbox.Text = "-0,4";
            this.xValueTextbox.TextChanged += new System.EventHandler(this.xValueTextbox_TextChanged);
            // 
            // yValueTextbox
            // 
            this.yValueTextbox.Location = new System.Drawing.Point(2252, 167);
            this.yValueTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.yValueTextbox.Name = "yValueTextbox";
            this.yValueTextbox.Size = new System.Drawing.Size(114, 31);
            this.yValueTextbox.TabIndex = 4;
            this.yValueTextbox.Text = "0";
            this.yValueTextbox.TextChanged += new System.EventHandler(this.yValueTextbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2072, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "vergrößerung";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2112, 335);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "iterationen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2104, 265);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Auflösung";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2072, 181);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "y Verschiebung";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2072, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "x Verschiebung";
            // 
            // resulutionTextbox
            // 
            this.resulutionTextbox.Enabled = false;
            this.resulutionTextbox.Location = new System.Drawing.Point(2252, 252);
            this.resulutionTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.resulutionTextbox.Name = "resulutionTextbox";
            this.resulutionTextbox.Size = new System.Drawing.Size(100, 31);
            this.resulutionTextbox.TabIndex = 10;
            this.resulutionTextbox.Text = "1024";
            this.resulutionTextbox.TextChanged += new System.EventHandler(this.resulutionTextbox_TextChanged);
            // 
            // iterationTextbox
            // 
            this.iterationTextbox.Enabled = false;
            this.iterationTextbox.Location = new System.Drawing.Point(2252, 321);
            this.iterationTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.iterationTextbox.Name = "iterationTextbox";
            this.iterationTextbox.Size = new System.Drawing.Size(100, 31);
            this.iterationTextbox.TabIndex = 11;
            this.iterationTextbox.Text = "200";
            this.iterationTextbox.TextChanged += new System.EventHandler(this.iterationTextbox_TextChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.AllowDrop = true;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(2584, 696);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = -100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(328, 90);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.AllowDrop = true;
            this.trackBar2.LargeChange = 1;
            this.trackBar2.Location = new System.Drawing.Point(2584, 746);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Minimum = -100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(328, 90);
            this.trackBar2.TabIndex = 16;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(2464, 867);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(492, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fraktal";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(302, 38);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(88, 29);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Julia";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(100, 40);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(151, 29);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Mandelbrot";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2398, 696);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Julia C X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2398, 769);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "Julia C Y";
            // 
            // labelJuliaX
            // 
            this.labelJuliaX.AutoSize = true;
            this.labelJuliaX.Location = new System.Drawing.Point(2552, 696);
            this.labelJuliaX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelJuliaX.Name = "labelJuliaX";
            this.labelJuliaX.Size = new System.Drawing.Size(24, 25);
            this.labelJuliaX.TabIndex = 20;
            this.labelJuliaX.Text = "0";
            // 
            // labelJuliaY
            // 
            this.labelJuliaY.AutoSize = true;
            this.labelJuliaY.Location = new System.Drawing.Point(2552, 769);
            this.labelJuliaY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelJuliaY.Name = "labelJuliaY";
            this.labelJuliaY.Size = new System.Drawing.Size(24, 25);
            this.labelJuliaY.TabIndex = 21;
            this.labelJuliaY.Text = "0";
            // 
            // ConvergenzRadiusTextbox
            // 
            this.ConvergenzRadiusTextbox.Enabled = false;
            this.ConvergenzRadiusTextbox.Location = new System.Drawing.Point(2272, 384);
            this.ConvergenzRadiusTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.ConvergenzRadiusTextbox.Name = "ConvergenzRadiusTextbox";
            this.ConvergenzRadiusTextbox.Size = new System.Drawing.Size(80, 31);
            this.ConvergenzRadiusTextbox.TabIndex = 22;
            this.ConvergenzRadiusTextbox.Text = "50";
            this.ConvergenzRadiusTextbox.TextChanged += new System.EventHandler(this.ConvergenzRadiusTextbox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2072, 384);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 25);
            this.label10.TabIndex = 23;
            this.label10.Text = "Konvergenzradius";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.InnerColor);
            this.groupBox2.Location = new System.Drawing.Point(2386, 144);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(620, 510);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.redColorButton);
            this.groupBox4.Controls.Add(this.blueColorButton);
            this.groupBox4.Controls.Add(this.greenColorButton);
            this.groupBox4.Controls.Add(this.totalColorButton);
            this.groupBox4.Location = new System.Drawing.Point(38, 375);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox4.Size = new System.Drawing.Size(508, 104);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Farbe";
            // 
            // redColorButton
            // 
            this.redColorButton.AutoSize = true;
            this.redColorButton.Location = new System.Drawing.Point(384, 35);
            this.redColorButton.Margin = new System.Windows.Forms.Padding(6);
            this.redColorButton.Name = "redColorButton";
            this.redColorButton.Size = new System.Drawing.Size(76, 29);
            this.redColorButton.TabIndex = 3;
            this.redColorButton.TabStop = true;
            this.redColorButton.Text = "Rot";
            this.redColorButton.UseVisualStyleBackColor = true;
            // 
            // blueColorButton
            // 
            this.blueColorButton.AutoSize = true;
            this.blueColorButton.Checked = true;
            this.blueColorButton.Location = new System.Drawing.Point(280, 35);
            this.blueColorButton.Margin = new System.Windows.Forms.Padding(6);
            this.blueColorButton.Name = "blueColorButton";
            this.blueColorButton.Size = new System.Drawing.Size(86, 29);
            this.blueColorButton.TabIndex = 2;
            this.blueColorButton.TabStop = true;
            this.blueColorButton.Text = "Blau";
            this.blueColorButton.UseVisualStyleBackColor = true;
            this.blueColorButton.CheckedChanged += new System.EventHandler(this.ColorManagement_PropertyChanged_Event);
            // 
            // greenColorButton
            // 
            this.greenColorButton.AutoSize = true;
            this.greenColorButton.Location = new System.Drawing.Point(160, 35);
            this.greenColorButton.Margin = new System.Windows.Forms.Padding(6);
            this.greenColorButton.Name = "greenColorButton";
            this.greenColorButton.Size = new System.Drawing.Size(90, 29);
            this.greenColorButton.TabIndex = 1;
            this.greenColorButton.TabStop = true;
            this.greenColorButton.Text = "Grün";
            this.greenColorButton.UseVisualStyleBackColor = true;
            this.greenColorButton.CheckedChanged += new System.EventHandler(this.ColorManagement_PropertyChanged_Event);
            // 
            // totalColorButton
            // 
            this.totalColorButton.AutoSize = true;
            this.totalColorButton.Location = new System.Drawing.Point(28, 37);
            this.totalColorButton.Margin = new System.Windows.Forms.Padding(6);
            this.totalColorButton.Name = "totalColorButton";
            this.totalColorButton.Size = new System.Drawing.Size(115, 29);
            this.totalColorButton.TabIndex = 0;
            this.totalColorButton.Text = "Absolut";
            this.totalColorButton.UseVisualStyleBackColor = true;
            this.totalColorButton.CheckedChanged += new System.EventHandler(this.ColorManagement_PropertyChanged_Event);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.thickColorButton);
            this.groupBox3.Controls.Add(this.normalColorButton);
            this.groupBox3.Controls.Add(this.thinColorButton);
            this.groupBox3.Location = new System.Drawing.Point(38, 229);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(508, 121);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Abstufung";
            // 
            // thickColorButton
            // 
            this.thickColorButton.AutoSize = true;
            this.thickColorButton.Location = new System.Drawing.Point(240, 46);
            this.thickColorButton.Margin = new System.Windows.Forms.Padding(4);
            this.thickColorButton.Name = "thickColorButton";
            this.thickColorButton.Size = new System.Drawing.Size(90, 29);
            this.thickColorButton.TabIndex = 2;
            this.thickColorButton.Text = "Grob";
            this.thickColorButton.UseVisualStyleBackColor = true;
            // 
            // normalColorButton
            // 
            this.normalColorButton.AutoSize = true;
            this.normalColorButton.Checked = true;
            this.normalColorButton.Location = new System.Drawing.Point(116, 44);
            this.normalColorButton.Margin = new System.Windows.Forms.Padding(4);
            this.normalColorButton.Name = "normalColorButton";
            this.normalColorButton.Size = new System.Drawing.Size(119, 29);
            this.normalColorButton.TabIndex = 1;
            this.normalColorButton.TabStop = true;
            this.normalColorButton.Text = "Medium";
            this.normalColorButton.UseVisualStyleBackColor = true;
            this.normalColorButton.CheckedChanged += new System.EventHandler(this.ColorManagement_PropertyChanged_Event);
            // 
            // thinColorButton
            // 
            this.thinColorButton.AutoSize = true;
            this.thinColorButton.Location = new System.Drawing.Point(20, 44);
            this.thinColorButton.Margin = new System.Windows.Forms.Padding(4);
            this.thinColorButton.Name = "thinColorButton";
            this.thinColorButton.Size = new System.Drawing.Size(85, 29);
            this.thinColorButton.TabIndex = 0;
            this.thinColorButton.Text = "Fein";
            this.thinColorButton.UseVisualStyleBackColor = true;
            this.thinColorButton.CheckedChanged += new System.EventHandler(this.ColorManagement_PropertyChanged_Event);
            // 
            // InnerColor
            // 
            this.InnerColor.Controls.Add(this.innerColorWhiteButton);
            this.InnerColor.Controls.Add(this.innerColorBlackButton);
            this.InnerColor.Location = new System.Drawing.Point(38, 63);
            this.InnerColor.Margin = new System.Windows.Forms.Padding(4);
            this.InnerColor.Name = "InnerColor";
            this.InnerColor.Padding = new System.Windows.Forms.Padding(4);
            this.InnerColor.Size = new System.Drawing.Size(508, 129);
            this.InnerColor.TabIndex = 0;
            this.InnerColor.TabStop = false;
            this.InnerColor.Text = "InnereFarbe";
            // 
            // innerColorWhiteButton
            // 
            this.innerColorWhiteButton.AutoSize = true;
            this.innerColorWhiteButton.Checked = true;
            this.innerColorWhiteButton.Location = new System.Drawing.Point(220, 40);
            this.innerColorWhiteButton.Margin = new System.Windows.Forms.Padding(4);
            this.innerColorWhiteButton.Name = "innerColorWhiteButton";
            this.innerColorWhiteButton.Size = new System.Drawing.Size(98, 29);
            this.innerColorWhiteButton.TabIndex = 1;
            this.innerColorWhiteButton.TabStop = true;
            this.innerColorWhiteButton.Text = "White";
            this.innerColorWhiteButton.UseVisualStyleBackColor = true;
            // 
            // innerColorBlackButton
            // 
            this.innerColorBlackButton.AutoSize = true;
            this.innerColorBlackButton.Location = new System.Drawing.Point(40, 40);
            this.innerColorBlackButton.Margin = new System.Windows.Forms.Padding(4);
            this.innerColorBlackButton.Name = "innerColorBlackButton";
            this.innerColorBlackButton.Size = new System.Drawing.Size(96, 29);
            this.innerColorBlackButton.TabIndex = 0;
            this.innerColorBlackButton.TabStop = true;
            this.innerColorBlackButton.Text = "Black";
            this.innerColorBlackButton.UseVisualStyleBackColor = true;
            this.innerColorBlackButton.CheckedChanged += new System.EventHandler(this.ColorManagement_PropertyChanged_Event);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton13);
            this.groupBox5.Controls.Add(this.radioButton12);
            this.groupBox5.Location = new System.Drawing.Point(2386, 37);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(620, 100);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Settings";
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(216, 44);
            this.radioButton13.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(134, 29);
            this.radioButton13.TabIndex = 1;
            this.radioButton13.Text = "Extended";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Checked = true;
            this.radioButton12.Location = new System.Drawing.Point(38, 44);
            this.radioButton12.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(130, 29);
            this.radioButton12.TabIndex = 0;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "Standard";
            this.radioButton12.UseVisualStyleBackColor = true;
            this.radioButton12.CheckedChanged += new System.EventHandler(this.RadioButtonSetting_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3028, 1465);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ConvergenzRadiusTextbox);
            this.Controls.Add(this.labelJuliaY);
            this.Controls.Add(this.labelJuliaX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.iterationTextbox);
            this.Controls.Add(this.resulutionTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yValueTextbox);
            this.Controls.Add(this.xValueTextbox);
            this.Controls.Add(this.ZoomTextbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Mandelbrot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.InnerColor.ResumeLayout(false);
            this.InnerColor.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ZoomTextbox;
        private System.Windows.Forms.TextBox xValueTextbox;
        private System.Windows.Forms.TextBox yValueTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox resulutionTextbox;
        private System.Windows.Forms.TextBox iterationTextbox;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelJuliaX;
        private System.Windows.Forms.Label labelJuliaY;
        private System.Windows.Forms.TextBox ConvergenzRadiusTextbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox InnerColor;
        private System.Windows.Forms.RadioButton innerColorWhiteButton;
        private System.Windows.Forms.RadioButton innerColorBlackButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton thinColorButton;
        private System.Windows.Forms.RadioButton thickColorButton;
        private System.Windows.Forms.RadioButton normalColorButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton blueColorButton;
        private System.Windows.Forms.RadioButton greenColorButton;
        private System.Windows.Forms.RadioButton totalColorButton;
        private System.Windows.Forms.RadioButton redColorButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton12;
    }
}

