namespace LRMusicVolumeSlider
{
    partial class MainFormWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormWindow));
            this.VOGroupBox = new System.Windows.Forms.GroupBox();
            this.JpVORadiobutton = new System.Windows.Forms.RadioButton();
            this.EnVORadiobutton = new System.Windows.Forms.RadioButton();
            this.FileSystemGroupBox = new System.Windows.Forms.GroupBox();
            this.NovaRadiobutton = new System.Windows.Forms.RadioButton();
            this.PackedRadiobutton = new System.Windows.Forms.RadioButton();
            this.slider = new System.Windows.Forms.TrackBar();
            this.sliderValuesLabel = new System.Windows.Forms.Label();
            this.SetVolume_button = new System.Windows.Forms.Button();
            this.AboutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.HelpLinkLabel = new System.Windows.Forms.LinkLabel();
            this.GamePathTxtBox = new System.Windows.Forms.TextBox();
            this.Browse_button = new System.Windows.Forms.Button();
            this.GamePathLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AppVersionLabel = new System.Windows.Forms.Label();
            this.VOGroupBox.SuspendLayout();
            this.FileSystemGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // VOGroupBox
            // 
            this.VOGroupBox.Controls.Add(this.JpVORadiobutton);
            this.VOGroupBox.Controls.Add(this.EnVORadiobutton);
            this.VOGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VOGroupBox.Location = new System.Drawing.Point(13, 326);
            this.VOGroupBox.Name = "VOGroupBox";
            this.VOGroupBox.Size = new System.Drawing.Size(200, 82);
            this.VOGroupBox.TabIndex = 3;
            this.VOGroupBox.TabStop = false;
            this.VOGroupBox.Text = "Voice Over Settings :";
            // 
            // JpVORadiobutton
            // 
            this.JpVORadiobutton.AutoSize = true;
            this.JpVORadiobutton.Location = new System.Drawing.Point(7, 44);
            this.JpVORadiobutton.Name = "JpVORadiobutton";
            this.JpVORadiobutton.Size = new System.Drawing.Size(98, 19);
            this.JpVORadiobutton.TabIndex = 1;
            this.JpVORadiobutton.TabStop = true;
            this.JpVORadiobutton.Text = "Japanese VO";
            this.JpVORadiobutton.UseVisualStyleBackColor = true;
            this.JpVORadiobutton.CheckedChanged += new System.EventHandler(this.JpVORadiobutton_CheckedChanged);
            // 
            // EnVORadiobutton
            // 
            this.EnVORadiobutton.AutoSize = true;
            this.EnVORadiobutton.Location = new System.Drawing.Point(7, 20);
            this.EnVORadiobutton.Name = "EnVORadiobutton";
            this.EnVORadiobutton.Size = new System.Drawing.Size(85, 19);
            this.EnVORadiobutton.TabIndex = 0;
            this.EnVORadiobutton.TabStop = true;
            this.EnVORadiobutton.Text = "English VO";
            this.EnVORadiobutton.UseVisualStyleBackColor = true;
            this.EnVORadiobutton.CheckedChanged += new System.EventHandler(this.EnVORadiobutton_CheckedChanged);
            // 
            // FileSystemGroupBox
            // 
            this.FileSystemGroupBox.Controls.Add(this.NovaRadiobutton);
            this.FileSystemGroupBox.Controls.Add(this.PackedRadiobutton);
            this.FileSystemGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSystemGroupBox.Location = new System.Drawing.Point(348, 326);
            this.FileSystemGroupBox.Name = "FileSystemGroupBox";
            this.FileSystemGroupBox.Size = new System.Drawing.Size(200, 82);
            this.FileSystemGroupBox.TabIndex = 4;
            this.FileSystemGroupBox.TabStop = false;
            this.FileSystemGroupBox.Text = "File System Settings :";
            // 
            // NovaRadiobutton
            // 
            this.NovaRadiobutton.AutoSize = true;
            this.NovaRadiobutton.Location = new System.Drawing.Point(7, 44);
            this.NovaRadiobutton.Name = "NovaRadiobutton";
            this.NovaRadiobutton.Size = new System.Drawing.Size(118, 19);
            this.NovaRadiobutton.TabIndex = 1;
            this.NovaRadiobutton.TabStop = true;
            this.NovaRadiobutton.Text = "Nova / Unpacked";
            this.NovaRadiobutton.UseVisualStyleBackColor = true;
            this.NovaRadiobutton.CheckedChanged += new System.EventHandler(this.NovaRadiobutton_CheckedChanged);
            // 
            // PackedRadiobutton
            // 
            this.PackedRadiobutton.AutoSize = true;
            this.PackedRadiobutton.Location = new System.Drawing.Point(7, 22);
            this.PackedRadiobutton.Name = "PackedRadiobutton";
            this.PackedRadiobutton.Size = new System.Drawing.Size(114, 19);
            this.PackedRadiobutton.TabIndex = 0;
            this.PackedRadiobutton.TabStop = true;
            this.PackedRadiobutton.Text = "Default / Packed";
            this.PackedRadiobutton.UseVisualStyleBackColor = true;
            this.PackedRadiobutton.CheckedChanged += new System.EventHandler(this.PackedRadiobutton_CheckedChanged);
            // 
            // slider
            // 
            this.slider.LargeChange = 1;
            this.slider.Location = new System.Drawing.Point(143, 462);
            this.slider.Maximum = 5;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(265, 45);
            this.slider.TabIndex = 6;
            // 
            // sliderValuesLabel
            // 
            this.sliderValuesLabel.AutoSize = true;
            this.sliderValuesLabel.Location = new System.Drawing.Point(150, 494);
            this.sliderValuesLabel.Name = "sliderValuesLabel";
            this.sliderValuesLabel.Size = new System.Drawing.Size(250, 13);
            this.sliderValuesLabel.TabIndex = 7;
            this.sliderValuesLabel.Text = "0              1              2              3             4              5";
            // 
            // SetVolume_button
            // 
            this.SetVolume_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetVolume_button.Location = new System.Drawing.Point(233, 533);
            this.SetVolume_button.Name = "SetVolume_button";
            this.SetVolume_button.Size = new System.Drawing.Size(90, 37);
            this.SetVolume_button.TabIndex = 8;
            this.SetVolume_button.Text = "Set Volume";
            this.SetVolume_button.UseVisualStyleBackColor = true;
            this.SetVolume_button.Click += new System.EventHandler(this.SetVolume_button_Click);
            // 
            // AboutLinkLabel
            // 
            this.AboutLinkLabel.AutoSize = true;
            this.AboutLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutLinkLabel.Location = new System.Drawing.Point(13, 572);
            this.AboutLinkLabel.Name = "AboutLinkLabel";
            this.AboutLinkLabel.Size = new System.Drawing.Size(42, 16);
            this.AboutLinkLabel.TabIndex = 9;
            this.AboutLinkLabel.TabStop = true;
            this.AboutLinkLabel.Text = "About";
            this.AboutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AboutLinkLabel_LinkClicked);
            // 
            // HelpLinkLabel
            // 
            this.HelpLinkLabel.AutoSize = true;
            this.HelpLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpLinkLabel.Location = new System.Drawing.Point(515, 572);
            this.HelpLinkLabel.Name = "HelpLinkLabel";
            this.HelpLinkLabel.Size = new System.Drawing.Size(36, 16);
            this.HelpLinkLabel.TabIndex = 10;
            this.HelpLinkLabel.TabStop = true;
            this.HelpLinkLabel.Text = "Help";
            this.HelpLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HelpLinkLabel_LinkClicked);
            // 
            // GamePathTxtBox
            // 
            this.GamePathTxtBox.Location = new System.Drawing.Point(13, 265);
            this.GamePathTxtBox.Multiline = true;
            this.GamePathTxtBox.Name = "GamePathTxtBox";
            this.GamePathTxtBox.Size = new System.Drawing.Size(466, 23);
            this.GamePathTxtBox.TabIndex = 1;
            // 
            // Browse_button
            // 
            this.Browse_button.Location = new System.Drawing.Point(486, 265);
            this.Browse_button.Name = "Browse_button";
            this.Browse_button.Size = new System.Drawing.Size(62, 23);
            this.Browse_button.TabIndex = 2;
            this.Browse_button.Text = "Browse...";
            this.Browse_button.UseVisualStyleBackColor = true;
            this.Browse_button.Click += new System.EventHandler(this.Browse_button_Click);
            // 
            // GamePathLabel
            // 
            this.GamePathLabel.AutoSize = true;
            this.GamePathLabel.Location = new System.Drawing.Point(13, 248);
            this.GamePathLabel.Name = "GamePathLabel";
            this.GamePathLabel.Size = new System.Drawing.Size(292, 13);
            this.GamePathLabel.TabIndex = 0;
            this.GamePathLabel.Text = "LIGHTNING RETURNS FINAL FANTASY XIII exe location :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LRMusicVolumeSlider.Properties.Resources.app_img;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(535, 211);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Music Volume Slider";
            // 
            // AppVersionLabel
            // 
            this.AppVersionLabel.AutoSize = true;
            this.AppVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppVersionLabel.Location = new System.Drawing.Point(257, 614);
            this.AppVersionLabel.Name = "AppVersionLabel";
            this.AppVersionLabel.Size = new System.Drawing.Size(29, 15);
            this.AppVersionLabel.TabIndex = 11;
            this.AppVersionLabel.Text = "v2.1";
            // 
            // MainFormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 638);
            this.Controls.Add(this.AppVersionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GamePathLabel);
            this.Controls.Add(this.Browse_button);
            this.Controls.Add(this.GamePathTxtBox);
            this.Controls.Add(this.HelpLinkLabel);
            this.Controls.Add(this.AboutLinkLabel);
            this.Controls.Add(this.SetVolume_button);
            this.Controls.Add(this.sliderValuesLabel);
            this.Controls.Add(this.slider);
            this.Controls.Add(this.FileSystemGroupBox);
            this.Controls.Add(this.VOGroupBox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainFormWindow";
            this.Text = "Lightning Returns - Music Volume Slider";
            this.VOGroupBox.ResumeLayout(false);
            this.VOGroupBox.PerformLayout();
            this.FileSystemGroupBox.ResumeLayout(false);
            this.FileSystemGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox VOGroupBox;
        private System.Windows.Forms.RadioButton JpVORadiobutton;
        private System.Windows.Forms.RadioButton EnVORadiobutton;
        private System.Windows.Forms.GroupBox FileSystemGroupBox;
        private System.Windows.Forms.RadioButton NovaRadiobutton;
        private System.Windows.Forms.RadioButton PackedRadiobutton;
        private System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.Label sliderValuesLabel;
        private System.Windows.Forms.Button SetVolume_button;
        private System.Windows.Forms.LinkLabel AboutLinkLabel;
        private System.Windows.Forms.LinkLabel HelpLinkLabel;
        private System.Windows.Forms.TextBox GamePathTxtBox;
        private System.Windows.Forms.Button Browse_button;
        private System.Windows.Forms.Label GamePathLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AppVersionLabel;
    }
}

