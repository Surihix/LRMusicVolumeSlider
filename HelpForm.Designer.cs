namespace LRMusicVolumeSlider
{
    partial class HelpFormWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpFormWindow));
            this.PointLabel1 = new System.Windows.Forms.Label();
            this.PointLabel2 = new System.Windows.Forms.Label();
            this.PointLabel2contd = new System.Windows.Forms.Label();
            this.PointLabel3 = new System.Windows.Forms.Label();
            this.PointLabel4 = new System.Windows.Forms.Label();
            this.HelpOKbutton = new System.Windows.Forms.Button();
            this.PointLabel3contd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PointLabel1
            // 
            this.PointLabel1.AutoSize = true;
            this.PointLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointLabel1.Location = new System.Drawing.Point(13, 13);
            this.PointLabel1.Name = "PointLabel1";
            this.PointLabel1.Size = new System.Drawing.Size(512, 18);
            this.PointLabel1.TabIndex = 0;
            this.PointLabel1.Text = "- First set the LRFF13.exe file location in the text box with the Browse button. " +
    "";
            // 
            // PointLabel2
            // 
            this.PointLabel2.AutoSize = true;
            this.PointLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointLabel2.Location = new System.Drawing.Point(13, 45);
            this.PointLabel2.Name = "PointLabel2";
            this.PointLabel2.Size = new System.Drawing.Size(510, 54);
            this.PointLabel2.TabIndex = 1;
            this.PointLabel2.Text = "- Next set the File System depending on whether you are playing the game in \r\n   " +
    "Packed or Unpacked mode.\r\n ";
            // 
            // PointLabel2contd
            // 
            this.PointLabel2contd.AutoSize = true;
            this.PointLabel2contd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointLabel2contd.Location = new System.Drawing.Point(16, 87);
            this.PointLabel2contd.Name = "PointLabel2contd";
            this.PointLabel2contd.Size = new System.Drawing.Size(503, 108);
            this.PointLabel2contd.TabIndex = 2;
            this.PointLabel2contd.Text = resources.GetString("PointLabel2contd.Text");
            // 
            // PointLabel3
            // 
            this.PointLabel3.AutoSize = true;
            this.PointLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointLabel3.Location = new System.Drawing.Point(16, 209);
            this.PointLabel3.Name = "PointLabel3";
            this.PointLabel3.Size = new System.Drawing.Size(491, 18);
            this.PointLabel3.TabIndex = 3;
            this.PointLabel3.Text = "- Now click and drag the slider to a value and press the set volume button.";
            // 
            // PointLabel4
            // 
            this.PointLabel4.AutoSize = true;
            this.PointLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointLabel4.Location = new System.Drawing.Point(16, 283);
            this.PointLabel4.Name = "PointLabel4";
            this.PointLabel4.Size = new System.Drawing.Size(479, 36);
            this.PointLabel4.TabIndex = 4;
            this.PointLabel4.Text = "- On clicking the Set Volume button a command prompt window should \r\n  open and p" +
    "atch in the volume.\r\n";
            // 
            // HelpOKbutton
            // 
            this.HelpOKbutton.Location = new System.Drawing.Point(230, 362);
            this.HelpOKbutton.Name = "HelpOKbutton";
            this.HelpOKbutton.Size = new System.Drawing.Size(75, 23);
            this.HelpOKbutton.TabIndex = 5;
            this.HelpOKbutton.Text = "OK";
            this.HelpOKbutton.UseVisualStyleBackColor = true;
            this.HelpOKbutton.Click += new System.EventHandler(this.HelpOKbutton_Click);
            // 
            // PointLabel3contd
            // 
            this.PointLabel3contd.AutoSize = true;
            this.PointLabel3contd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointLabel3contd.Location = new System.Drawing.Point(16, 233);
            this.PointLabel3contd.Name = "PointLabel3contd";
            this.PointLabel3contd.Size = new System.Drawing.Size(491, 36);
            this.PointLabel3contd.TabIndex = 6;
            this.PointLabel3contd.Text = "  Value 5 is the default volume level of the music in the game while value 0 \r\n  " +
    "mutes the music entirely.\r\n";
            // 
            // HelpFormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 397);
            this.Controls.Add(this.PointLabel3contd);
            this.Controls.Add(this.HelpOKbutton);
            this.Controls.Add(this.PointLabel4);
            this.Controls.Add(this.PointLabel3);
            this.Controls.Add(this.PointLabel2contd);
            this.Controls.Add(this.PointLabel2);
            this.Controls.Add(this.PointLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpFormWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PointLabel1;
        private System.Windows.Forms.Label PointLabel2;
        private System.Windows.Forms.Label PointLabel2contd;
        private System.Windows.Forms.Label PointLabel3;
        private System.Windows.Forms.Label PointLabel4;
        private System.Windows.Forms.Button HelpOKbutton;
        private System.Windows.Forms.Label PointLabel3contd;
    }
}