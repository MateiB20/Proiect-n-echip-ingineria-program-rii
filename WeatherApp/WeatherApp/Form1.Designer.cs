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
            this.labelCity = new System.Windows.Forms.Label();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelCondition = new System.Windows.Forms.Label();
            this.labelDetails = new System.Windows.Forms.Label();
            this.valueSunrise = new System.Windows.Forms.Label();
            this.labelSunrise = new System.Windows.Forms.Label();
            this.labelSunset = new System.Windows.Forms.Label();
            this.valueSunset = new System.Windows.Forms.Label();
            this.labelWind = new System.Windows.Forms.Label();
            this.valueWind = new System.Windows.Forms.Label();
            this.labelPressure = new System.Windows.Forms.Label();
            this.valuePressure = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonChangeTheme = new System.Windows.Forms.Button();
            this.comboBoxChangeLanguage = new System.Windows.Forms.ComboBox();
            this.comboBoxChangeWeatherProvider = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.BackColor = System.Drawing.Color.Transparent;
            this.labelCity.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCity.ForeColor = System.Drawing.Color.White;
            this.labelCity.Location = new System.Drawing.Point(126, 61);
            this.labelCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(108, 45);
            this.labelCity.TabIndex = 0;
            this.labelCity.Text = "Oras: ";
            // 
            // textBoxCity
            // 
            this.textBoxCity.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCity.Location = new System.Drawing.Point(260, 56);
            this.textBoxCity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(397, 52);
            this.textBoxCity.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Transparent;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(668, 53);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(220, 59);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Cauta";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelCondition
            // 
            this.labelCondition.AutoSize = true;
            this.labelCondition.BackColor = System.Drawing.Color.Transparent;
            this.labelCondition.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCondition.ForeColor = System.Drawing.Color.White;
            this.labelCondition.Location = new System.Drawing.Point(104, 314);
            this.labelCondition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCondition.Name = "labelCondition";
            this.labelCondition.Size = new System.Drawing.Size(176, 45);
            this.labelCondition.TabIndex = 3;
            this.labelCondition.Text = "Conditie:  ";
            // 
            // labelDetails
            // 
            this.labelDetails.AutoSize = true;
            this.labelDetails.BackColor = System.Drawing.Color.Transparent;
            this.labelDetails.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetails.ForeColor = System.Drawing.Color.White;
            this.labelDetails.Location = new System.Drawing.Point(105, 358);
            this.labelDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(154, 45);
            this.labelDetails.TabIndex = 4;
            this.labelDetails.Text = "Detalii:   ";
            // 
            // valueSunrise
            // 
            this.valueSunrise.AutoSize = true;
            this.valueSunrise.BackColor = System.Drawing.Color.Transparent;
            this.valueSunrise.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueSunrise.ForeColor = System.Drawing.Color.White;
            this.valueSunrise.Location = new System.Drawing.Point(417, 436);
            this.valueSunrise.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.valueSunrise.Name = "valueSunrise";
            this.valueSunrise.Size = new System.Drawing.Size(80, 45);
            this.valueSunrise.TabIndex = 6;
            this.valueSunrise.Text = "N/A";
            // 
            // labelSunrise
            // 
            this.labelSunrise.AutoSize = true;
            this.labelSunrise.BackColor = System.Drawing.Color.Transparent;
            this.labelSunrise.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSunrise.ForeColor = System.Drawing.Color.White;
            this.labelSunrise.Location = new System.Drawing.Point(96, 438);
            this.labelSunrise.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSunrise.Name = "labelSunrise";
            this.labelSunrise.Size = new System.Drawing.Size(161, 45);
            this.labelSunrise.TabIndex = 7;
            this.labelSunrise.Text = "Rasarit:   ";
            // 
            // labelSunset
            // 
            this.labelSunset.AutoSize = true;
            this.labelSunset.BackColor = System.Drawing.Color.Transparent;
            this.labelSunset.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSunset.ForeColor = System.Drawing.Color.White;
            this.labelSunset.Location = new System.Drawing.Point(96, 481);
            this.labelSunset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSunset.Name = "labelSunset";
            this.labelSunset.Size = new System.Drawing.Size(131, 45);
            this.labelSunset.TabIndex = 9;
            this.labelSunset.Text = "Apus:   ";
            // 
            // valueSunset
            // 
            this.valueSunset.AutoSize = true;
            this.valueSunset.BackColor = System.Drawing.Color.Transparent;
            this.valueSunset.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueSunset.ForeColor = System.Drawing.Color.White;
            this.valueSunset.Location = new System.Drawing.Point(417, 481);
            this.valueSunset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.valueSunset.Name = "valueSunset";
            this.valueSunset.Size = new System.Drawing.Size(80, 45);
            this.valueSunset.TabIndex = 8;
            this.valueSunset.Text = "N/A";
            // 
            // labelWind
            // 
            this.labelWind.AutoSize = true;
            this.labelWind.BackColor = System.Drawing.Color.Transparent;
            this.labelWind.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWind.ForeColor = System.Drawing.Color.White;
            this.labelWind.Location = new System.Drawing.Point(704, 314);
            this.labelWind.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWind.Name = "labelWind";
            this.labelWind.Size = new System.Drawing.Size(125, 45);
            this.labelWind.TabIndex = 11;
            this.labelWind.Text = "Vant:   ";
            // 
            // valueWind
            // 
            this.valueWind.AutoSize = true;
            this.valueWind.BackColor = System.Drawing.Color.Transparent;
            this.valueWind.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueWind.ForeColor = System.Drawing.Color.White;
            this.valueWind.Location = new System.Drawing.Point(828, 314);
            this.valueWind.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.valueWind.Name = "valueWind";
            this.valueWind.Size = new System.Drawing.Size(80, 45);
            this.valueWind.TabIndex = 10;
            this.valueWind.Text = "N/A";
            // 
            // labelPressure
            // 
            this.labelPressure.AutoSize = true;
            this.labelPressure.BackColor = System.Drawing.Color.Transparent;
            this.labelPressure.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPressure.ForeColor = System.Drawing.Color.White;
            this.labelPressure.Location = new System.Drawing.Point(704, 358);
            this.labelPressure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPressure.Name = "labelPressure";
            this.labelPressure.Size = new System.Drawing.Size(165, 45);
            this.labelPressure.TabIndex = 13;
            this.labelPressure.Text = "Presiune:";
            // 
            // valuePressure
            // 
            this.valuePressure.AutoSize = true;
            this.valuePressure.BackColor = System.Drawing.Color.Transparent;
            this.valuePressure.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valuePressure.ForeColor = System.Drawing.Color.White;
            this.valuePressure.Location = new System.Drawing.Point(872, 358);
            this.valuePressure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.valuePressure.Name = "valuePressure";
            this.valuePressure.Size = new System.Drawing.Size(80, 45);
            this.valuePressure.TabIndex = 12;
            this.valuePressure.Text = "N/A";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIcon.Location = new System.Drawing.Point(134, 148);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(141, 127);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 14;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.Click += new System.EventHandler(this.pictureBoxIcon_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(130, 589);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(816, 238);
            this.flowLayoutPanel.TabIndex = 15;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // buttonChangeTheme
            // 
            this.buttonChangeTheme.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonChangeTheme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonChangeTheme.ForeColor = System.Drawing.Color.Snow;
            this.buttonChangeTheme.Location = new System.Drawing.Point(897, 52);
            this.buttonChangeTheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonChangeTheme.Name = "buttonChangeTheme";
            this.buttonChangeTheme.Size = new System.Drawing.Size(140, 72);
            this.buttonChangeTheme.TabIndex = 16;
            this.buttonChangeTheme.Text = "Change Theme";
            this.buttonChangeTheme.UseVisualStyleBackColor = false;
            this.buttonChangeTheme.Click += new System.EventHandler(this.buttonChangeTheme_Click);
            // 
            // comboBoxChangeLanguage
            // 
            this.comboBoxChangeLanguage.FormattingEnabled = true;
            this.comboBoxChangeLanguage.Items.AddRange(new object[] {
            "en",
            "ro",
            "fr",
            "de"});
            this.comboBoxChangeLanguage.Location = new System.Drawing.Point(909, 156);
            this.comboBoxChangeLanguage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxChangeLanguage.Name = "comboBoxChangeLanguage";
            this.comboBoxChangeLanguage.Size = new System.Drawing.Size(124, 33);
            this.comboBoxChangeLanguage.TabIndex = 17;
            this.comboBoxChangeLanguage.Tag = "";
            this.comboBoxChangeLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxChangeLanguage_SelectedIndexChanged);
            // 
            // comboBoxChangeWeatherProvider
            // 
            this.comboBoxChangeWeatherProvider.FormattingEnabled = true;
            this.comboBoxChangeWeatherProvider.Items.AddRange(new object[] {
            "OpenWeather",
            "WeatherStack",
            "Wttr"});
            this.comboBoxChangeWeatherProvider.Location = new System.Drawing.Point(909, 199);
            this.comboBoxChangeWeatherProvider.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxChangeWeatherProvider.Name = "comboBoxChangeWeatherProvider";
            this.comboBoxChangeWeatherProvider.Size = new System.Drawing.Size(124, 33);
            this.comboBoxChangeWeatherProvider.TabIndex = 19;
            this.comboBoxChangeWeatherProvider.Tag = "";
            this.comboBoxChangeWeatherProvider.SelectedIndexChanged += new System.EventHandler(this.comboBoxChangeWeatherProvider_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1074, 886);
            this.Controls.Add(this.comboBoxChangeWeatherProvider);
            this.Controls.Add(this.comboBoxChangeLanguage);
            this.Controls.Add(this.buttonChangeTheme);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.labelPressure);
            this.Controls.Add(this.valuePressure);
            this.Controls.Add(this.labelWind);
            this.Controls.Add(this.valueWind);
            this.Controls.Add(this.labelSunset);
            this.Controls.Add(this.valueSunset);
            this.Controls.Add(this.labelSunrise);
            this.Controls.Add(this.valueSunrise);
            this.Controls.Add(this.labelDetails);
            this.Controls.Add(this.labelCondition);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.labelCity);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

