namespace WindowsFormsApp1
{
    partial class ForecastUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxForecastIcon = new PictureBox();
            labelDate = new Label();
            labelTempMin = new Label();
            labelTempMax = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxForecastIcon).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxForecastIcon
            // 
            pictureBoxForecastIcon.Location = new Point(85, 18);
            pictureBoxForecastIcon.Margin = new Padding(3, 4, 3, 4);
            pictureBoxForecastIcon.Name = "pictureBoxForecastIcon";
            pictureBoxForecastIcon.Size = new Size(108, 74);
            pictureBoxForecastIcon.TabIndex = 0;
            pictureBoxForecastIcon.TabStop = false;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDate.Location = new Point(8, 30);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(49, 24);
            labelDate.TabIndex = 1;
            labelDate.Text = "Data";
            // 
            // labelTempMin
            // 
            labelTempMin.AutoSize = true;
            labelTempMin.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTempMin.ForeColor = Color.LightGray;
            labelTempMin.Location = new Point(237, 30);
            labelTempMin.Name = "labelTempMin";
            labelTempMin.Size = new Size(88, 24);
            labelTempMin.TabIndex = 2;
            labelTempMin.Text = "TempMin";
            // 
            // labelTempMax
            // 
            labelTempMax.AutoSize = true;
            labelTempMax.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTempMax.ForeColor = Color.White;
            labelTempMax.Location = new Point(350, 30);
            labelTempMax.Name = "labelTempMax";
            labelTempMax.Size = new Size(91, 24);
            labelTempMax.TabIndex = 3;
            labelTempMax.Text = "TempMax";
            // 
            // ForecastUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(labelTempMax);
            Controls.Add(labelTempMin);
            Controls.Add(labelDate);
            Controls.Add(pictureBoxForecastIcon);
            ForeColor = Color.Transparent;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ForecastUC";
            Size = new Size(444, 108);
            ((System.ComponentModel.ISupportInitialize)pictureBoxForecastIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBoxForecastIcon;
        public System.Windows.Forms.Label labelDate;
        public System.Windows.Forms.Label labelTempMin;
        public System.Windows.Forms.Label labelTempMax;
    }
}
