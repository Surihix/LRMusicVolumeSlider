namespace LRMusicVolumeSlider
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.AboutOKbutton = new System.Windows.Forms.Button();
            this.CreditLabel1 = new System.Windows.Forms.Label();
            this.CreditLabel2 = new System.Windows.Forms.Label();
            this.AboutPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AboutPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AboutOKbutton
            // 
            this.AboutOKbutton.Location = new System.Drawing.Point(82, 159);
            this.AboutOKbutton.Name = "AboutOKbutton";
            this.AboutOKbutton.Size = new System.Drawing.Size(75, 23);
            this.AboutOKbutton.TabIndex = 0;
            this.AboutOKbutton.Text = "OK";
            this.AboutOKbutton.UseVisualStyleBackColor = true;
            this.AboutOKbutton.Click += new System.EventHandler(this.AboutOKbutton_Click);
            // 
            // CreditLabel1
            // 
            this.CreditLabel1.AutoSize = true;
            this.CreditLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.CreditLabel1.Location = new System.Drawing.Point(46, 105);
            this.CreditLabel1.Name = "CreditLabel1";
            this.CreditLabel1.Size = new System.Drawing.Size(154, 16);
            this.CreditLabel1.TabIndex = 1;
            this.CreditLabel1.Text = "App Progammer : Surihix";
            // 
            // CreditLabel2
            // 
            this.CreditLabel2.AutoSize = true;
            this.CreditLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.CreditLabel2.Location = new System.Drawing.Point(50, 127);
            this.CreditLabel2.Name = "CreditLabel2";
            this.CreditLabel2.Size = new System.Drawing.Size(145, 16);
            this.CreditLabel2.TabIndex = 1;
            this.CreditLabel2.Text = "FFXiiicrypt tool : Echelo";
            // 
            // AboutPictureBox
            // 
            this.AboutPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AboutPictureBox.Image")));
            this.AboutPictureBox.Location = new System.Drawing.Point(80, 20);
            this.AboutPictureBox.Name = "AboutPictureBox";
            this.AboutPictureBox.Size = new System.Drawing.Size(77, 66);
            this.AboutPictureBox.TabIndex = 2;
            this.AboutPictureBox.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 195);
            this.Controls.Add(this.AboutPictureBox);
            this.Controls.Add(this.CreditLabel2);
            this.Controls.Add(this.CreditLabel1);
            this.Controls.Add(this.AboutOKbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.AboutPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AboutOKbutton;
        private System.Windows.Forms.Label CreditLabel1;
        private System.Windows.Forms.Label CreditLabel2;
        private System.Windows.Forms.PictureBox AboutPictureBox;
    }
}