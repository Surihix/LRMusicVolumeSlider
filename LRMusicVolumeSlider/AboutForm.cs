﻿using System;
using System.Windows.Forms;

namespace LRMusicVolumeSlider
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutOKbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}