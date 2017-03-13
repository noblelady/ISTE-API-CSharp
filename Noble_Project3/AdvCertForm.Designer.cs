namespace Noble_Project3
{
    partial class AdvCertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvCertForm));
            this.lblAC2 = new System.Windows.Forms.Label();
            this.lblAC1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAC2
            // 
            this.lblAC2.AutoSize = true;
            this.lblAC2.Location = new System.Drawing.Point(14, 110);
            this.lblAC2.Name = "lblAC2";
            this.lblAC2.Size = new System.Drawing.Size(35, 13);
            this.lblAC2.TabIndex = 5;
            this.lblAC2.Text = "label3";
            // 
            // lblAC1
            // 
            this.lblAC1.AutoSize = true;
            this.lblAC1.Location = new System.Drawing.Point(14, 62);
            this.lblAC1.Name = "lblAC1";
            this.lblAC1.Size = new System.Drawing.Size(35, 13);
            this.lblAC1.TabIndex = 4;
            this.lblAC1.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Advanced Certificates";
            // 
            // AdvCertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(284, 167);
            this.Controls.Add(this.lblAC2);
            this.Controls.Add(this.lblAC1);
            this.Controls.Add(this.label1);
            this.Name = "AdvCertForm";
            this.Text = "AdvCertForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAC2;
        private System.Windows.Forms.Label lblAC1;
        private System.Windows.Forms.Label label1;
    }
}