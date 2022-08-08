using System;
using System.Windows.Forms;

namespace LRMusicVolumeSlider
{
    public partial class AboutFormWindow : Form
    {
        public AboutFormWindow()
        {
            InitializeComponent();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
