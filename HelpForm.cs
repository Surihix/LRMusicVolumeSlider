using System;
using System.Windows.Forms;

namespace LRMusicVolumeSlider
{
    public partial class HelpFormWindow : Form
    {
        public HelpFormWindow()
        {
            InitializeComponent();
        }

        private void HelpOKbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
