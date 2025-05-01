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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.BackColor = System.Drawing.Color.Transparent;
            this.labelCity.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCity.ForeColor = System.Drawing.Color.White;
            this.labelCity.Location = new System.Drawing.Point(84, 39);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(66, 28);
            this.labelCity.TabIndex = 0;
            this.labelCity.Text = "Oras: ";
            // 
            // textBoxCity
            // 
            this.textBoxCity.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCity.Location = new System.Drawing.Point(173, 36);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(266, 36);
            this.textBoxCity.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Transparent;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(474, 34);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(94, 39);
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
            this.labelCondition.Location = new System.Drawing.Point(84, 201);
            this.labelCondition.Name = "labelCondition";
            this.labelCondition.Size = new System.Drawing.Size(107, 28);
            this.labelCondition.TabIndex = 3;
            this.labelCondition.Text = "Conditie:  ";
            // 
            // labelDetails
            // 
            this.labelDetails.AutoSize = true;
            this.labelDetails.BackColor = System.Drawing.Color.Transparent;
            this.labelDetails.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetails.ForeColor = System.Drawing.Color.White;
            this.labelDetails.Location = new System.Drawing.Point(84, 229);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(97, 28);
            this.labelDetails.TabIndex = 4;
            this.labelDetails.Text = "Detalii:   ";
            // 
            // valueSunrise
            // 
            this.valueSunrise.AutoSize = true;
            this.valueSunrise.BackColor = System.Drawing.Color.Transparent;
            this.valueSunrise.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueSunrise.ForeColor = System.Drawing.Color.White;
            this.valueSunrise.Location = new System.Drawing.Point(187, 280);
            this.valueSunrise.Name = "valueSunrise";
            this.valueSunrise.Size = new System.Drawing.Size(50, 28);
            this.valueSunrise.TabIndex = 6;
            this.valueSunrise.Text = "N/A";
            // 
            // labelSunrise
            // 
            this.labelSunrise.AutoSize = true;
            this.labelSunrise.BackColor = System.Drawing.Color.Transparent;
            this.labelSunrise.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSunrise.ForeColor = System.Drawing.Color.White;
            this.labelSunrise.Location = new System.Drawing.Point(82, 280);
            this.labelSunrise.Name = "labelSunrise";
            this.labelSunrise.Size = new System.Drawing.Size(99, 28);
            this.labelSunrise.TabIndex = 7;
            this.labelSunrise.Text = "Rasarit:   ";
            // 
            // labelSunset
            // 
            this.labelSunset.AutoSize = true;
            this.labelSunset.BackColor = System.Drawing.Color.Transparent;
            this.labelSunset.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSunset.ForeColor = System.Drawing.Color.White;
            this.labelSunset.Location = new System.Drawing.Point(84, 308);
            this.labelSunset.Name = "labelSunset";
            this.labelSunset.Size = new System.Drawing.Size(80, 28);
            this.labelSunset.TabIndex = 9;
            this.labelSunset.Text = "Apus:   ";
            // 
            // valueSunset
            // 
            this.valueSunset.AutoSize = true;
            this.valueSunset.BackColor = System.Drawing.Color.Transparent;
            this.valueSunset.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueSunset.ForeColor = System.Drawing.Color.White;
            this.valueSunset.Location = new System.Drawing.Point(168, 308);
            this.valueSunset.Name = "valueSunset";
            this.valueSunset.Size = new System.Drawing.Size(50, 28);
            this.valueSunset.TabIndex = 8;
            this.valueSunset.Text = "N/A";
            // 
            // labelWind
            // 
            this.labelWind.AutoSize = true;
            this.labelWind.BackColor = System.Drawing.Color.Transparent;
            this.labelWind.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWind.ForeColor = System.Drawing.Color.White;
            this.labelWind.Location = new System.Drawing.Point(469, 201);
            this.labelWind.Name = "labelWind";
            this.labelWind.Size = new System.Drawing.Size(77, 28);
            this.labelWind.TabIndex = 11;
            this.labelWind.Text = "Vant:   ";
            // 
            // valueWind
            // 
            this.valueWind.AutoSize = true;
            this.valueWind.BackColor = System.Drawing.Color.Transparent;
            this.valueWind.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueWind.ForeColor = System.Drawing.Color.White;
            this.valueWind.Location = new System.Drawing.Point(552, 201);
            this.valueWind.Name = "valueWind";
            this.valueWind.Size = new System.Drawing.Size(50, 28);
            this.valueWind.TabIndex = 10;
            this.valueWind.Text = "N/A";
            // 
            // labelPressure
            // 
            this.labelPressure.AutoSize = true;
            this.labelPressure.BackColor = System.Drawing.Color.Transparent;
            this.labelPressure.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPressure.ForeColor = System.Drawing.Color.White;
            this.labelPressure.Location = new System.Drawing.Point(469, 229);
            this.labelPressure.Name = "labelPressure";
            this.labelPressure.Size = new System.Drawing.Size(101, 28);
            this.labelPressure.TabIndex = 13;
            this.labelPressure.Text = "Presiune:";
            // 
            // valuePressure
            // 
            this.valuePressure.AutoSize = true;
            this.valuePressure.BackColor = System.Drawing.Color.Transparent;
            this.valuePressure.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valuePressure.ForeColor = System.Drawing.Color.White;
            this.valuePressure.Location = new System.Drawing.Point(581, 229);
            this.valuePressure.Name = "valuePressure";
            this.valuePressure.Size = new System.Drawing.Size(50, 28);
            this.valuePressure.TabIndex = 12;
            this.valuePressure.Text = "N/A";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIcon.Location = new System.Drawing.Point(89, 95);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(94, 81);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 14;
            this.pictureBoxIcon.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(87, 377);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(544, 152);
            this.flowLayoutPanel.TabIndex = 15;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(716, 567);
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
    }
}

