namespace LRMusicVolumeSlider
{
    partial class CoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoreForm));
            this.Versionlabel = new System.Windows.Forms.Label();
            this.AppImg_pictureBox = new System.Windows.Forms.PictureBox();
            this.PathtextBox = new System.Windows.Forms.TextBox();
            this.Browsebutton = new System.Windows.Forms.Button();
            this.TxtAbovePathBoxlabel = new System.Windows.Forms.Label();
            this.VOgroupBox = new System.Windows.Forms.GroupBox();
            this.JpnUIVOradiobutton = new System.Windows.Forms.RadioButton();
            this.JpVOradiobutton = new System.Windows.Forms.RadioButton();
            this.EnVOradiobutton = new System.Windows.Forms.RadioButton();
            this.FileSystemgroupBox = new System.Windows.Forms.GroupBox();
            this.Novaradiobutton = new System.Windows.Forms.RadioButton();
            this.Packedradiobutton = new System.Windows.Forms.RadioButton();
            this.AboutlinkLabel = new System.Windows.Forms.LinkLabel();
            this.HelplinkLabel = new System.Windows.Forms.LinkLabel();
            this.SlidertrackBar = new System.Windows.Forms.TrackBar();
            this.TxtAboveSliderlabel = new System.Windows.Forms.Label();
            this.SliderValueslabel = new System.Windows.Forms.Label();
            this.SetVolumebutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AppImg_pictureBox)).BeginInit();
            this.VOgroupBox.SuspendLayout();
            this.FileSystemgroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlidertrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Versionlabel
            // 
            this.Versionlabel.AutoSize = true;
            this.Versionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Versionlabel.Location = new System.Drawing.Point(266, 615);
            this.Versionlabel.Name = "Versionlabel";
            this.Versionlabel.Size = new System.Drawing.Size(29, 15);
            this.Versionlabel.TabIndex = 10;
            this.Versionlabel.Text = "v2.5";
            // 
            // AppImg_pictureBox
            // 
            this.AppImg_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AppImg_pictureBox.Image")));
            this.AppImg_pictureBox.Location = new System.Drawing.Point(13, 13);
            this.AppImg_pictureBox.Name = "AppImg_pictureBox";
            this.AppImg_pictureBox.Size = new System.Drawing.Size(535, 211);
            this.AppImg_pictureBox.TabIndex = 1;
            this.AppImg_pictureBox.TabStop = false;
            // 
            // PathtextBox
            // 
            this.PathtextBox.Location = new System.Drawing.Point(13, 265);
            this.PathtextBox.Name = "PathtextBox";
            this.PathtextBox.Size = new System.Drawing.Size(466, 20);
            this.PathtextBox.TabIndex = 1;
            // 
            // Browsebutton
            // 
            this.Browsebutton.Location = new System.Drawing.Point(486, 264);
            this.Browsebutton.Name = "Browsebutton";
            this.Browsebutton.Size = new System.Drawing.Size(62, 23);
            this.Browsebutton.TabIndex = 2;
            this.Browsebutton.Text = "Browse...";
            this.Browsebutton.UseVisualStyleBackColor = true;
            this.Browsebutton.Click += new System.EventHandler(this.Browsebutton_Click);
            // 
            // TxtAbovePathBoxlabel
            // 
            this.TxtAbovePathBoxlabel.AutoSize = true;
            this.TxtAbovePathBoxlabel.Location = new System.Drawing.Point(13, 248);
            this.TxtAbovePathBoxlabel.Name = "TxtAbovePathBoxlabel";
            this.TxtAbovePathBoxlabel.Size = new System.Drawing.Size(292, 13);
            this.TxtAbovePathBoxlabel.TabIndex = 0;
            this.TxtAbovePathBoxlabel.Text = "LIGHTNING RETURNS FINAL FANTASY XIII exe location :";
            // 
            // VOgroupBox
            // 
            this.VOgroupBox.Controls.Add(this.JpnUIVOradiobutton);
            this.VOgroupBox.Controls.Add(this.JpVOradiobutton);
            this.VOgroupBox.Controls.Add(this.EnVOradiobutton);
            this.VOgroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VOgroupBox.Location = new System.Drawing.Point(13, 326);
            this.VOgroupBox.Name = "VOgroupBox";
            this.VOgroupBox.Size = new System.Drawing.Size(200, 111);
            this.VOgroupBox.TabIndex = 3;
            this.VOgroupBox.TabStop = false;
            this.VOgroupBox.Text = "Voice Over Settings :";
            // 
            // JpnUIVOradiobutton
            // 
            this.JpnUIVOradiobutton.AutoSize = true;
            this.JpnUIVOradiobutton.Location = new System.Drawing.Point(7, 68);
            this.JpnUIVOradiobutton.Name = "JpnUIVOradiobutton";
            this.JpnUIVOradiobutton.Size = new System.Drawing.Size(169, 19);
            this.JpnUIVOradiobutton.TabIndex = 2;
            this.JpnUIVOradiobutton.TabStop = true;
            this.JpnUIVOradiobutton.Text = "日本語版 UI と ボイスオーバー";
            this.JpnUIVOradiobutton.UseVisualStyleBackColor = true;
            // 
            // JpVOradiobutton
            // 
            this.JpVOradiobutton.AutoSize = true;
            this.JpVOradiobutton.Location = new System.Drawing.Point(7, 44);
            this.JpVOradiobutton.Name = "JpVOradiobutton";
            this.JpVOradiobutton.Size = new System.Drawing.Size(98, 19);
            this.JpVOradiobutton.TabIndex = 1;
            this.JpVOradiobutton.TabStop = true;
            this.JpVOradiobutton.Text = "Japanese VO";
            this.JpVOradiobutton.UseVisualStyleBackColor = true;
            // 
            // EnVOradiobutton
            // 
            this.EnVOradiobutton.AutoSize = true;
            this.EnVOradiobutton.Location = new System.Drawing.Point(7, 20);
            this.EnVOradiobutton.Name = "EnVOradiobutton";
            this.EnVOradiobutton.Size = new System.Drawing.Size(85, 19);
            this.EnVOradiobutton.TabIndex = 0;
            this.EnVOradiobutton.TabStop = true;
            this.EnVOradiobutton.Text = "English VO";
            this.EnVOradiobutton.UseVisualStyleBackColor = true;
            // 
            // FileSystemgroupBox
            // 
            this.FileSystemgroupBox.Controls.Add(this.Novaradiobutton);
            this.FileSystemgroupBox.Controls.Add(this.Packedradiobutton);
            this.FileSystemgroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSystemgroupBox.Location = new System.Drawing.Point(348, 326);
            this.FileSystemgroupBox.Name = "FileSystemgroupBox";
            this.FileSystemgroupBox.Size = new System.Drawing.Size(200, 111);
            this.FileSystemgroupBox.TabIndex = 4;
            this.FileSystemgroupBox.TabStop = false;
            this.FileSystemgroupBox.Text = "File System Settings :";
            // 
            // Novaradiobutton
            // 
            this.Novaradiobutton.AutoSize = true;
            this.Novaradiobutton.Location = new System.Drawing.Point(7, 44);
            this.Novaradiobutton.Name = "Novaradiobutton";
            this.Novaradiobutton.Size = new System.Drawing.Size(118, 19);
            this.Novaradiobutton.TabIndex = 1;
            this.Novaradiobutton.TabStop = true;
            this.Novaradiobutton.Text = "Nova / Unpacked";
            this.Novaradiobutton.UseVisualStyleBackColor = true;
            // 
            // Packedradiobutton
            // 
            this.Packedradiobutton.AutoSize = true;
            this.Packedradiobutton.Location = new System.Drawing.Point(7, 22);
            this.Packedradiobutton.Name = "Packedradiobutton";
            this.Packedradiobutton.Size = new System.Drawing.Size(114, 19);
            this.Packedradiobutton.TabIndex = 0;
            this.Packedradiobutton.TabStop = true;
            this.Packedradiobutton.Text = "Default / Packed";
            this.Packedradiobutton.UseVisualStyleBackColor = true;
            // 
            // AboutlinkLabel
            // 
            this.AboutlinkLabel.AutoSize = true;
            this.AboutlinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.AboutlinkLabel.Location = new System.Drawing.Point(10, 615);
            this.AboutlinkLabel.Name = "AboutlinkLabel";
            this.AboutlinkLabel.Size = new System.Drawing.Size(42, 16);
            this.AboutlinkLabel.TabIndex = 9;
            this.AboutlinkLabel.TabStop = true;
            this.AboutlinkLabel.Text = "About";
            this.AboutlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AboutlinkLabel_LinkClicked);
            // 
            // HelplinkLabel
            // 
            this.HelplinkLabel.AutoSize = true;
            this.HelplinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.HelplinkLabel.Location = new System.Drawing.Point(512, 615);
            this.HelplinkLabel.Name = "HelplinkLabel";
            this.HelplinkLabel.Size = new System.Drawing.Size(36, 16);
            this.HelplinkLabel.TabIndex = 11;
            this.HelplinkLabel.TabStop = true;
            this.HelplinkLabel.Text = "Help";
            this.HelplinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HelplinkLabel_LinkClicked);
            // 
            // SlidertrackBar
            // 
            this.SlidertrackBar.LargeChange = 1;
            this.SlidertrackBar.Location = new System.Drawing.Point(143, 490);
            this.SlidertrackBar.Name = "SlidertrackBar";
            this.SlidertrackBar.Size = new System.Drawing.Size(265, 45);
            this.SlidertrackBar.TabIndex = 6;
            // 
            // TxtAboveSliderlabel
            // 
            this.TxtAboveSliderlabel.AutoSize = true;
            this.TxtAboveSliderlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.TxtAboveSliderlabel.Location = new System.Drawing.Point(214, 461);
            this.TxtAboveSliderlabel.Name = "TxtAboveSliderlabel";
            this.TxtAboveSliderlabel.Size = new System.Drawing.Size(129, 16);
            this.TxtAboveSliderlabel.TabIndex = 5;
            this.TxtAboveSliderlabel.Text = "Music Volume Slider";
            // 
            // SliderValueslabel
            // 
            this.SliderValueslabel.AutoSize = true;
            this.SliderValueslabel.Location = new System.Drawing.Point(150, 521);
            this.SliderValueslabel.Name = "SliderValueslabel";
            this.SliderValueslabel.Size = new System.Drawing.Size(256, 13);
            this.SliderValueslabel.TabIndex = 7;
            this.SliderValueslabel.Text = "0      1      2      3      4      5      6      7      8      9     10";
            // 
            // SetVolumebutton
            // 
            this.SetVolumebutton.Location = new System.Drawing.Point(234, 560);
            this.SetVolumebutton.Name = "SetVolumebutton";
            this.SetVolumebutton.Size = new System.Drawing.Size(90, 37);
            this.SetVolumebutton.TabIndex = 8;
            this.SetVolumebutton.Text = "Set Volume";
            this.SetVolumebutton.UseVisualStyleBackColor = true;
            this.SetVolumebutton.Click += new System.EventHandler(this.SetVolumebutton_Click);
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 638);
            this.Controls.Add(this.SetVolumebutton);
            this.Controls.Add(this.SliderValueslabel);
            this.Controls.Add(this.TxtAboveSliderlabel);
            this.Controls.Add(this.SlidertrackBar);
            this.Controls.Add(this.HelplinkLabel);
            this.Controls.Add(this.AboutlinkLabel);
            this.Controls.Add(this.FileSystemgroupBox);
            this.Controls.Add(this.VOgroupBox);
            this.Controls.Add(this.TxtAbovePathBoxlabel);
            this.Controls.Add(this.Browsebutton);
            this.Controls.Add(this.PathtextBox);
            this.Controls.Add(this.AppImg_pictureBox);
            this.Controls.Add(this.Versionlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CoreForm";
            this.Text = "Lightning Returns - Music Volume Slider";
            ((System.ComponentModel.ISupportInitialize)(this.AppImg_pictureBox)).EndInit();
            this.VOgroupBox.ResumeLayout(false);
            this.VOgroupBox.PerformLayout();
            this.FileSystemgroupBox.ResumeLayout(false);
            this.FileSystemgroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlidertrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Versionlabel;
        private System.Windows.Forms.PictureBox AppImg_pictureBox;
        private System.Windows.Forms.TextBox PathtextBox;
        private System.Windows.Forms.Button Browsebutton;
        private System.Windows.Forms.Label TxtAbovePathBoxlabel;
        private System.Windows.Forms.GroupBox VOgroupBox;
        private System.Windows.Forms.RadioButton JpVOradiobutton;
        private System.Windows.Forms.RadioButton EnVOradiobutton;
        private System.Windows.Forms.GroupBox FileSystemgroupBox;
        private System.Windows.Forms.RadioButton Novaradiobutton;
        private System.Windows.Forms.RadioButton Packedradiobutton;
        private System.Windows.Forms.LinkLabel AboutlinkLabel;
        private System.Windows.Forms.LinkLabel HelplinkLabel;
        private System.Windows.Forms.TrackBar SlidertrackBar;
        private System.Windows.Forms.Label TxtAboveSliderlabel;
        private System.Windows.Forms.Label SliderValueslabel;
        private System.Windows.Forms.Button SetVolumebutton;
        private System.Windows.Forms.RadioButton JpnUIVOradiobutton;
    }
}

