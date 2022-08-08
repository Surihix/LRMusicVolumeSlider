namespace LRMusicVolumeSlider
{
    partial class AboutFormWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutFormWindow));
            this.AboutIconPicture = new System.Windows.Forms.PictureBox();
            this.ProgrammerLabel = new System.Windows.Forms.Label();
            this.ff13toolLabel = new System.Windows.Forms.Label();
            this.ffxiiicryptLabel = new System.Windows.Forms.Label();
            this.WPDPackLabel = new System.Windows.Forms.Label();
            this.OKbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AboutIconPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // AboutIconPicture
            // 
            this.AboutIconPicture.Image = ((System.Drawing.Image)(resources.GetObject("AboutIconPicture.Image")));
            this.AboutIconPicture.Location = new System.Drawing.Point(12, 22);
            this.AboutIconPicture.Name = "AboutIconPicture";
            this.AboutIconPicture.Size = new System.Drawing.Size(77, 66);
            this.AboutIconPicture.TabIndex = 0;
            this.AboutIconPicture.TabStop = false;
            // 
            // ProgrammerLabel
            // 
            this.ProgrammerLabel.AutoSize = true;
            this.ProgrammerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgrammerLabel.Location = new System.Drawing.Point(107, 22);
            this.ProgrammerLabel.Name = "ProgrammerLabel";
            this.ProgrammerLabel.Size = new System.Drawing.Size(158, 16);
            this.ProgrammerLabel.TabIndex = 1;
            this.ProgrammerLabel.Text = "App Programmer : Surihix";
            // 
            // ff13toolLabel
            // 
            this.ff13toolLabel.AutoSize = true;
            this.ff13toolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ff13toolLabel.Location = new System.Drawing.Point(107, 56);
            this.ff13toolLabel.Name = "ff13toolLabel";
            this.ff13toolLabel.Size = new System.Drawing.Size(144, 16);
            this.ff13toolLabel.TabIndex = 2;
            this.ff13toolLabel.Text = "FF13tool :   FluffyQuack";
            // 
            // ffxiiicryptLabel
            // 
            this.ffxiiicryptLabel.AutoSize = true;
            this.ffxiiicryptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ffxiiicryptLabel.Location = new System.Drawing.Point(107, 76);
            this.ffxiiicryptLabel.Name = "ffxiiicryptLabel";
            this.ffxiiicryptLabel.Size = new System.Drawing.Size(151, 16);
            this.ffxiiicryptLabel.TabIndex = 3;
            this.ffxiiicryptLabel.Text = "FFXiiicrypt tool :   Echelo";
            // 
            // WPDPackLabel
            // 
            this.WPDPackLabel.AutoSize = true;
            this.WPDPackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WPDPackLabel.Location = new System.Drawing.Point(107, 96);
            this.WPDPackLabel.Name = "WPDPackLabel";
            this.WPDPackLabel.Size = new System.Drawing.Size(196, 16);
            this.WPDPackLabel.TabIndex = 4;
            this.WPDPackLabel.Text = "WPDPack tool :   GreenThumb2";
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(133, 145);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 5;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // AboutFormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 180);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.WPDPackLabel);
            this.Controls.Add(this.ffxiiicryptLabel);
            this.Controls.Add(this.ff13toolLabel);
            this.Controls.Add(this.ProgrammerLabel);
            this.Controls.Add(this.AboutIconPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutFormWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.AboutIconPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AboutIconPicture;
        private System.Windows.Forms.Label ProgrammerLabel;
        private System.Windows.Forms.Label ff13toolLabel;
        private System.Windows.Forms.Label ffxiiicryptLabel;
        private System.Windows.Forms.Label WPDPackLabel;
        private System.Windows.Forms.Button OKbutton;
    }
}