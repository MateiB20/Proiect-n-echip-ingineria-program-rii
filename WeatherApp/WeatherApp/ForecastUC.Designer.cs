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
            this.pictureBoxForecastIcon = new System.Windows.Forms.PictureBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTempMin = new System.Windows.Forms.Label();
            this.labelTempMax = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForecastIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxForecastIcon
            // 
            this.pictureBoxForecastIcon.Location = new System.Drawing.Point(85, 14);
            this.pictureBoxForecastIcon.Name = "pictureBoxForecastIcon";
            this.pictureBoxForecastIcon.Size = new System.Drawing.Size(108, 59);
            this.pictureBoxForecastIcon.TabIndex = 0;
            this.pictureBoxForecastIcon.TabStop = false;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(8, 24);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(49, 24);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Data";
            // 
            // labelTempMin
            // 
            this.labelTempMin.AutoSize = true;
            this.labelTempMin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTempMin.ForeColor = System.Drawing.Color.Blue;
            this.labelTempMin.Location = new System.Drawing.Point(237, 24);
            this.labelTempMin.Name = "labelTempMin";
            this.labelTempMin.Size = new System.Drawing.Size(88, 24);
            this.labelTempMin.TabIndex = 2;
            this.labelTempMin.Text = "TempMin";
            // 
            // labelTempMax
            // 
            this.labelTempMax.AutoSize = true;
            this.labelTempMax.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTempMax.ForeColor = System.Drawing.Color.Red;
            this.labelTempMax.Location = new System.Drawing.Point(350, 24);
            this.labelTempMax.Name = "labelTempMax";
            this.labelTempMax.Size = new System.Drawing.Size(91, 24);
            this.labelTempMax.TabIndex = 3;
            this.labelTempMax.Text = "TempMax";
            // 
            // ForecastUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTempMax);
            this.Controls.Add(this.labelTempMin);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.pictureBoxForecastIcon);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ForecastUC";
            this.Size = new System.Drawing.Size(444, 86);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForecastIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBoxForecastIcon;
        public System.Windows.Forms.Label labelDate;
        public System.Windows.Forms.Label labelTempMin;
        public System.Windows.Forms.Label labelTempMax;
    }
}
