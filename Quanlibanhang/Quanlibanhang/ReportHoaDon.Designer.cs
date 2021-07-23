namespace Quanlibanhang
{
    partial class ReportHoaDon
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
            this.label1 = new System.Windows.Forms.Label();
            this.chonMaKH = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.report = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Khách Hàng";
            // 
            // chonMaKH
            // 
            this.chonMaKH.FormattingEnabled = true;
            this.chonMaKH.Location = new System.Drawing.Point(196, 24);
            this.chonMaKH.Name = "chonMaKH";
            this.chonMaKH.Size = new System.Drawing.Size(187, 24);
            this.chonMaKH.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 92);
            this.button1.TabIndex = 2;
            this.button1.Text = "Báo Cáo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // report
            // 
            this.report.Location = new System.Drawing.Point(12, 157);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(720, 320);
            this.report.TabIndex = 3;
            // 
            // ReportHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 489);
            this.Controls.Add(this.report);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chonMaKH);
            this.Controls.Add(this.label1);
            this.Name = "ReportHoaDon";
            this.Text = "ReportHoaDon";
            this.Load += new System.EventHandler(this.ReportHoaDon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox chonMaKH;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer report;
    }
}