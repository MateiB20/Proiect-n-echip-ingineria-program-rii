namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            labelCity = new Label();
            textBoxCity = new TextBox();
            buttonSearch = new Button();
            labelCondition = new Label();
            labelDetails = new Label();
            valueSunrise = new Label();
            labelSunrise = new Label();
            labelSunset = new Label();
            valueSunset = new Label();
            labelWind = new Label();
            valueWind = new Label();
            labelPressure = new Label();
            valuePressure = new Label();
            pictureBoxIcon = new PictureBox();
            flowLayoutPanel = new FlowLayoutPanel();
            buttonChangeTheme = new Button();
            comboBoxChangeLanguage = new ComboBox();
            comboBoxChangeWeatherProvider = new ComboBox();
            groupBox1 = new GroupBox();
            labelLocationTime = new Label();
            valueTemperature = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            valueHumidity = new Label();
            labelHumidity = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // labelCity
            // 
            labelCity.AutoSize = true;
            labelCity.BackColor = Color.Transparent;
            labelCity.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCity.ForeColor = Color.White;
            labelCity.Location = new Point(65, 47);
            labelCity.Name = "labelCity";
            labelCity.Size = new Size(66, 28);
            labelCity.TabIndex = 0;
            labelCity.Text = "Oras: ";
            // 
            // textBoxCity
            // 
            textBoxCity.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCity.Location = new Point(126, 43);
            textBoxCity.Margin = new Padding(3, 4, 3, 4);
            textBoxCity.Name = "textBoxCity";
            textBoxCity.Size = new Size(266, 36);
            textBoxCity.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.Transparent;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSearch.ForeColor = Color.White;
            buttonSearch.Location = new Point(398, 43);
            buttonSearch.Margin = new Padding(3, 4, 3, 4);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(129, 39);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Cauta";
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // labelCondition
            // 
            labelCondition.AutoSize = true;
            labelCondition.BackColor = Color.Transparent;
            labelCondition.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCondition.ForeColor = Color.White;
            labelCondition.Location = new Point(8, 433);
            labelCondition.Name = "labelCondition";
            labelCondition.Size = new Size(105, 28);
            labelCondition.TabIndex = 3;
            labelCondition.Text = "Conditie:  ";
            // 
            // labelDetails
            // 
            labelDetails.AutoSize = true;
            labelDetails.BackColor = Color.Transparent;
            labelDetails.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDetails.ForeColor = Color.White;
            labelDetails.Location = new Point(9, 468);
            labelDetails.Name = "labelDetails";
            labelDetails.Size = new Size(92, 28);
            labelDetails.TabIndex = 4;
            labelDetails.Text = "Detalii:   ";
            // 
            // valueSunrise
            // 
            valueSunrise.AutoSize = true;
            valueSunrise.BackColor = Color.Transparent;
            valueSunrise.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valueSunrise.ForeColor = Color.White;
            valueSunrise.Location = new Point(150, 38);
            valueSunrise.Name = "valueSunrise";
            valueSunrise.Size = new Size(48, 28);
            valueSunrise.TabIndex = 6;
            valueSunrise.Text = "N/A";
            // 
            // labelSunrise
            // 
            labelSunrise.AutoSize = true;
            labelSunrise.BackColor = Color.Transparent;
            labelSunrise.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSunrise.ForeColor = Color.White;
            labelSunrise.Location = new Point(21, 38);
            labelSunrise.Name = "labelSunrise";
            labelSunrise.Size = new Size(97, 28);
            labelSunrise.TabIndex = 7;
            labelSunrise.Text = "Rasarit:   ";
            // 
            // labelSunset
            // 
            labelSunset.AutoSize = true;
            labelSunset.BackColor = Color.Transparent;
            labelSunset.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSunset.ForeColor = Color.White;
            labelSunset.Location = new Point(21, 73);
            labelSunset.Name = "labelSunset";
            labelSunset.Size = new Size(79, 28);
            labelSunset.TabIndex = 9;
            labelSunset.Text = "Apus:   ";
            // 
            // valueSunset
            // 
            valueSunset.AutoSize = true;
            valueSunset.BackColor = Color.Transparent;
            valueSunset.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valueSunset.ForeColor = Color.White;
            valueSunset.Location = new Point(150, 73);
            valueSunset.Name = "valueSunset";
            valueSunset.Size = new Size(48, 28);
            valueSunset.TabIndex = 8;
            valueSunset.Text = "N/A";
            // 
            // labelWind
            // 
            labelWind.AutoSize = true;
            labelWind.BackColor = Color.Transparent;
            labelWind.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelWind.ForeColor = Color.White;
            labelWind.Location = new Point(21, 52);
            labelWind.Name = "labelWind";
            labelWind.Size = new Size(76, 28);
            labelWind.TabIndex = 11;
            labelWind.Text = "Vant:   ";
            // 
            // valueWind
            // 
            valueWind.AutoSize = true;
            valueWind.BackColor = Color.Transparent;
            valueWind.Font = new Font("Calibri", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valueWind.ForeColor = Color.White;
            valueWind.Location = new Point(104, 52);
            valueWind.Name = "valueWind";
            valueWind.Size = new Size(59, 35);
            valueWind.TabIndex = 10;
            valueWind.Text = "N/A";
            // 
            // labelPressure
            // 
            labelPressure.AutoSize = true;
            labelPressure.BackColor = Color.Transparent;
            labelPressure.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPressure.ForeColor = Color.White;
            labelPressure.Location = new Point(24, 58);
            labelPressure.Name = "labelPressure";
            labelPressure.Size = new Size(98, 28);
            labelPressure.TabIndex = 13;
            labelPressure.Text = "Presiune:";
            // 
            // valuePressure
            // 
            valuePressure.AutoSize = true;
            valuePressure.BackColor = Color.Transparent;
            valuePressure.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valuePressure.ForeColor = Color.White;
            valuePressure.Location = new Point(136, 58);
            valuePressure.Name = "valuePressure";
            valuePressure.Size = new Size(48, 28);
            valuePressure.TabIndex = 12;
            valuePressure.Text = "N/A";
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.BackColor = Color.Transparent;
            pictureBoxIcon.Location = new Point(35, 47);
            pictureBoxIcon.Margin = new Padding(3, 4, 3, 4);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(118, 122);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 14;
            pictureBoxIcon.TabStop = false;
            pictureBoxIcon.Click += pictureBoxIcon_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = Color.Transparent;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flowLayoutPanel.ForeColor = Color.Transparent;
            flowLayoutPanel.Location = new Point(323, 117);
            flowLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(539, 220);
            flowLayoutPanel.TabIndex = 15;
            flowLayoutPanel.WrapContents = false;
            // 
            // buttonChangeTheme
            // 
            buttonChangeTheme.BackColor = SystemColors.InactiveCaptionText;
            buttonChangeTheme.BackgroundImageLayout = ImageLayout.None;
            buttonChangeTheme.ForeColor = Color.Snow;
            buttonChangeTheme.Location = new Point(769, 35);
            buttonChangeTheme.Margin = new Padding(3, 4, 3, 4);
            buttonChangeTheme.Name = "buttonChangeTheme";
            buttonChangeTheme.Size = new Size(93, 58);
            buttonChangeTheme.TabIndex = 16;
            buttonChangeTheme.Text = "Change Theme";
            buttonChangeTheme.UseVisualStyleBackColor = false;
            buttonChangeTheme.Click += buttonChangeTheme_Click;
            // 
            // comboBoxChangeLanguage
            // 
            comboBoxChangeLanguage.BackColor = Color.White;
            comboBoxChangeLanguage.FormattingEnabled = true;
            comboBoxChangeLanguage.Items.AddRange(new object[] { "en", "ro", "fr", "de" });
            comboBoxChangeLanguage.Location = new Point(576, 29);
            comboBoxChangeLanguage.Margin = new Padding(3, 4, 3, 4);
            comboBoxChangeLanguage.Name = "comboBoxChangeLanguage";
            comboBoxChangeLanguage.Size = new Size(171, 28);
            comboBoxChangeLanguage.TabIndex = 17;
            comboBoxChangeLanguage.Tag = "";
            comboBoxChangeLanguage.Text = "Select language..";
            comboBoxChangeLanguage.SelectedIndexChanged += comboBoxChangeLanguage_SelectedIndexChanged;
            // 
            // comboBoxChangeWeatherProvider
            // 
            comboBoxChangeWeatherProvider.BackColor = Color.White;
            comboBoxChangeWeatherProvider.Enabled = false;
            comboBoxChangeWeatherProvider.FormattingEnabled = true;
            comboBoxChangeWeatherProvider.Items.AddRange(new object[] { "OpenWeather", "WeatherStack", "Wttr" });
            comboBoxChangeWeatherProvider.Location = new Point(576, 63);
            comboBoxChangeWeatherProvider.Margin = new Padding(3, 4, 3, 4);
            comboBoxChangeWeatherProvider.Name = "comboBoxChangeWeatherProvider";
            comboBoxChangeWeatherProvider.Size = new Size(171, 28);
            comboBoxChangeWeatherProvider.TabIndex = 19;
            comboBoxChangeWeatherProvider.Tag = "";
            comboBoxChangeWeatherProvider.Text = "Select API provider...";
            comboBoxChangeWeatherProvider.SelectedIndexChanged += comboBoxChangeWeatherProvider_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(labelLocationTime);
            groupBox1.Controls.Add(valueTemperature);
            groupBox1.Controls.Add(pictureBoxIcon);
            groupBox1.Controls.Add(labelCondition);
            groupBox1.Controls.Add(labelDetails);
            groupBox1.Location = new Point(65, 117);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(219, 559);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            // 
            // labelLocationTime
            // 
            labelLocationTime.AutoSize = true;
            labelLocationTime.BackColor = Color.Transparent;
            labelLocationTime.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLocationTime.ForeColor = Color.White;
            labelLocationTime.Location = new Point(9, 355);
            labelLocationTime.Name = "labelLocationTime";
            labelLocationTime.Size = new Size(181, 41);
            labelLocationTime.TabIndex = 16;
            labelLocationTime.Text = "Locatie, ora";
            // 
            // valueTemperature
            // 
            valueTemperature.AutoSize = true;
            valueTemperature.BackColor = Color.Transparent;
            valueTemperature.Font = new Font("Calibri", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valueTemperature.ForeColor = Color.White;
            valueTemperature.Location = new Point(35, 245);
            valueTemperature.Name = "valueTemperature";
            valueTemperature.Size = new Size(78, 45);
            valueTemperature.TabIndex = 15;
            valueTemperature.Text = "N/A";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(labelSunrise);
            groupBox2.Controls.Add(valueSunrise);
            groupBox2.Controls.Add(valueSunset);
            groupBox2.Controls.Add(labelSunset);
            groupBox2.Location = new Point(612, 362);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 125);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(labelWind);
            groupBox3.Controls.Add(valueWind);
            groupBox3.Location = new Point(323, 362);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(250, 125);
            groupBox3.TabIndex = 22;
            groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.Transparent;
            groupBox4.Controls.Add(valuePressure);
            groupBox4.Controls.Add(labelPressure);
            groupBox4.Location = new Point(323, 521);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(250, 125);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.Transparent;
            groupBox5.Controls.Add(valueHumidity);
            groupBox5.Controls.Add(labelHumidity);
            groupBox5.Location = new Point(612, 521);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(250, 125);
            groupBox5.TabIndex = 24;
            groupBox5.TabStop = false;
            // 
            // valueHumidity
            // 
            valueHumidity.AutoSize = true;
            valueHumidity.BackColor = Color.Transparent;
            valueHumidity.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valueHumidity.ForeColor = Color.White;
            valueHumidity.Location = new Point(150, 58);
            valueHumidity.Name = "valueHumidity";
            valueHumidity.Size = new Size(48, 28);
            valueHumidity.TabIndex = 12;
            valueHumidity.Text = "N/A";
            // 
            // labelHumidity
            // 
            labelHumidity.AutoSize = true;
            labelHumidity.BackColor = Color.Transparent;
            labelHumidity.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelHumidity.ForeColor = Color.White;
            labelHumidity.Location = new Point(24, 58);
            labelHumidity.Name = "labelHumidity";
            labelHumidity.Size = new Size(111, 28);
            labelHumidity.TabIndex = 13;
            labelHumidity.Text = "Umiditate:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(907, 709);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(comboBoxChangeWeatherProvider);
            Controls.Add(comboBoxChangeLanguage);
            Controls.Add(buttonChangeTheme);
            Controls.Add(flowLayoutPanel);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxCity);
            Controls.Add(labelCity);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelCondition;
        private System.Windows.Forms.Label labelDetails;
        private System.Windows.Forms.Label valueSunrise;
        private System.Windows.Forms.Label labelSunrise;
        private System.Windows.Forms.Label labelSunset;
        private System.Windows.Forms.Label valueSunset;
        private System.Windows.Forms.Label labelWind;
        private System.Windows.Forms.Label valueWind;
        private System.Windows.Forms.Label labelPressure;
        private System.Windows.Forms.Label valuePressure;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button buttonChangeTheme;
        private System.Windows.Forms.ComboBox comboBoxChangeLanguage;
        private System.Windows.Forms.ComboBox comboBoxChangeWeatherProvider;
        private GroupBox groupBox1;
        private Label valueTemperature;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Label valueHumidity;
        private Label labelHumidity;
        private Label labelLocationTime;
    }
}

