using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LRMusicVolumeSlider
{
    public partial class MainFormWindow : Form
    {
        public MainFormWindow()
        {
            InitializeComponent();


            if (!Directory.Exists("UserSettings"))
            {
                Directory.CreateDirectory("UserSettings");
            }


            if (!File.Exists("UserSettings/LRPath.txt"))
            {
                EnVORadiobutton.Enabled = false;
                JpVORadiobutton.Enabled = false;
                slider.Enabled = false;
                SetVolume_button.Enabled = false;
                PackedRadiobutton.Enabled = false;
                NovaRadiobutton.Enabled = false;
            }

            if (File.Exists("UserSettings/LRPath.txt"))
            {
                GamePathTxtBox.Text = File.ReadAllText("UserSettings/LRPath.txt");
                slider.Enabled = true;
                SetVolume_button.Enabled = true;
            }

            if (File.Exists("UserSettings/SliderValue.txt"))
            {
                string slidervalstr = File.ReadAllText("UserSettings/SliderValue.txt");
                int slidervalint = Convert.ToInt16(slidervalstr);
                slider.Value = slidervalint;
            }

            if (!File.Exists("UserSettings/SliderValue.txt"))
            {
                slider.Value = 5;
            }

            if (File.Exists("UserSettings/language.txt"))
            {
                string lang_val = File.ReadAllText("UserSettings/language.txt").Trim();
                string lang_val_EN = "English";
                string lang_val_JP = "Japanese";

                if (lang_val.Equals(lang_val_EN))
                {
                    EnVORadiobutton.Checked = true;
                }

                if (lang_val.Equals(lang_val_JP))
                {
                    JpVORadiobutton.Checked = true;
                }
            }

            if (File.Exists("UserSettings/mode.txt"))
            {
                string mode = File.ReadAllText("UserSettings/mode.txt").Trim();
                string mode_packed = "Packed";
                string mode_nova = "Nova";

                if (mode.Equals(mode_packed))
                {
                    PackedRadiobutton.Checked = true;
                }

                if (mode.Equals(mode_nova))
                {
                    NovaRadiobutton.Checked = true; 
                }
            }
        }

        private void Browse_button_Click(object sender, EventArgs e)
        {
            string LR_exe = "LRFF13.exe";

            OpenFileDialog path_select = new OpenFileDialog();
            path_select.FileName = LR_exe;
            path_select.Filter = LR_exe + $"|{LR_exe}";
            path_select.RestoreDirectory = true;


            if (path_select.ShowDialog() == DialogResult.OK)
            {
                string LRfilePath = path_select.FileName;
                string LRfolder = Path.GetDirectoryName(LRfilePath);

                StreamWriter DirRecord = new StreamWriter("UserSettings/LRPath.txt");
                DirRecord.Write(LRfolder);
                DirRecord.WriteLine("\\");
                DirRecord.Close();


                string ToWeissFolder = File.ReadAllText("UserSettings/LRPath.txt").Trim();
                string JPVerFileList = ToWeissFolder + "weiss_data/sys/filelist2.win32.bin";

                if (File.Exists(JPVerFileList))
                {
                    MessageBox.Show("Japanese only version filelist detected\nThis app cannot be used " +
                        "to patch this version of the game.", 
                        "Unsupported version", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    File.Delete("UserSettings/LRPath.txt");
                    return;
                }


                GamePathTxtBox.Text = File.ReadAllText("UserSettings/LRPath.txt");
                EnVORadiobutton.Enabled = true;
                JpVORadiobutton.Enabled = true;
                slider.Enabled = true;
                slider.Value = 5;
                SetVolume_button.Enabled = true;
                PackedRadiobutton.Enabled = true;
                NovaRadiobutton.Enabled = true;
                slider.Focus();
            }           
        }

        private void PackedRadiobutton_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter filesystem = new StreamWriter("UserSettings/mode.txt");
            filesystem.WriteLine("Packed");
            filesystem.Close();
            slider.Focus();
            EnVORadiobutton.Enabled = true;
            JpVORadiobutton.Enabled = true;
            filesystem.Close();
        }

        private void NovaRadiobutton_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter filesystem = new StreamWriter("UserSettings/mode.txt");
            filesystem.WriteLine("Nova");
            filesystem.Close();
            slider.Focus();
            EnVORadiobutton.Enabled = false;
            JpVORadiobutton.Enabled = false;
            filesystem.Close();
        }


        private void SetVolume_button_Click(object sender, EventArgs e)
        {
            if (slider.Value == 0)
            {
                StreamWriter sliderRecord = new StreamWriter("UserSettings/SliderValue.txt");
                sliderRecord.Write("0");
                sliderRecord.Close();
                Process bat = new Process();
                bat.StartInfo.WorkingDirectory = "Scripts";
                bat.StartInfo.FileName = "VolumePatcher.bat";
                bat.StartInfo.UseShellExecute = true;
                bat.Start();
                bat.WaitForExit();
                slider.Focus();
            }

            if (slider.Value == 1)
            {
                StreamWriter sliderRecord = new StreamWriter("UserSettings/SliderValue.txt");
                sliderRecord.Write("1");
                sliderRecord.Close();
                Process bat = new Process();
                bat.StartInfo.WorkingDirectory = "Scripts";
                bat.StartInfo.FileName = "VolumePatcher.bat";
                bat.StartInfo.UseShellExecute = true;
                bat.Start();
                bat.WaitForExit();
                slider.Focus();
            }

            if (slider.Value == 2)
            {
                StreamWriter sliderRecord = new StreamWriter("UserSettings/SliderValue.txt");
                sliderRecord.Write("2");
                sliderRecord.Close();
                Process bat = new Process();
                bat.StartInfo.WorkingDirectory = "Scripts";
                bat.StartInfo.FileName = "VolumePatcher.bat";
                bat.StartInfo.UseShellExecute = true;
                bat.Start();
                bat.WaitForExit();
                slider.Focus();
            }

            if (slider.Value == 3)
            {
                StreamWriter sliderRecord = new StreamWriter("UserSettings/SliderValue.txt");
                sliderRecord.Write("3");
                sliderRecord.Close();
                Process bat = new Process();
                bat.StartInfo.WorkingDirectory = "Scripts";
                bat.StartInfo.FileName = "VolumePatcher.bat";
                bat.StartInfo.UseShellExecute = true;
                bat.Start();
                bat.WaitForExit();
                slider.Focus();
            }

            if (slider.Value == 4)
            {
                StreamWriter sliderRecord = new StreamWriter("UserSettings/SliderValue.txt");
                sliderRecord.Write("4");
                sliderRecord.Close();
                Process bat = new Process();
                bat.StartInfo.WorkingDirectory = "Scripts";
                bat.StartInfo.FileName = "VolumePatcher.bat";
                bat.StartInfo.UseShellExecute = true;
                bat.Start();
                bat.WaitForExit();
                slider.Focus();
            }

            if (slider.Value == 5)
            {
                StreamWriter sliderRecord = new StreamWriter("UserSettings/SliderValue.txt");
                sliderRecord.Write("5");
                sliderRecord.Close();
                Process bat = new Process();
                bat.StartInfo.WorkingDirectory = "Scripts";
                bat.StartInfo.FileName = "VolumePatcher.bat";
                bat.StartInfo.UseShellExecute = true;
                bat.Start();
                bat.WaitForExit();
                slider.Focus();
            }
        }

        private void EnVORadiobutton_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter lang = new StreamWriter("UserSettings/language.txt");
            lang.WriteLine("English");
            lang.Close();
            slider.Focus();
            lang.Close();
        }

        private void JpVORadiobutton_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter lang = new StreamWriter("UserSettings/language.txt");
            lang.WriteLine("Japanese");
            lang.Close();
            slider.Focus();
            lang.Close();
        }

        private void AboutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutFormWindow AboutBox = new AboutFormWindow();
            System.Media.SystemSounds.Asterisk.Play();
            AboutBox.ShowDialog();
            slider.Focus();
        }

        private void HelpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HelpFormWindow HelpBox = new HelpFormWindow();
            System.Media.SystemSounds.Asterisk.Play();
            HelpBox.ShowDialog();
            slider.Focus();
        }
    }
}
