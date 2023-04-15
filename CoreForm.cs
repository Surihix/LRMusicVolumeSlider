using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRMusicVolumeSlider
{
    public partial class CoreForm : Form
    {
        public CoreForm()
        {
            InitializeComponent();

            if (!File.Exists("AppHelp.txt"))
            {
                CmnMethods.AppMsgBox("The 'AppHelp.txt' file is missing\nPlease ensure that this file is present next to the app to use the Help option.", "Warning", MessageBoxIcon.Warning);
            }

            if (!File.Exists("ffxiiicrypt.exe"))
            {
                CmnMethods.AppMsgBox("The 'ffxiiicrypt.exe' tool is missing\nPlease ensure that this tool is present next to this app's executable file.", "Error", MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            if (!File.Exists("UserSettings.xml"))
            {
                DisableComponents();
                EnVOradiobutton.Checked = true;
                Packedradiobutton.Checked = true;
                SlidertrackBar.Value = 5;
                SlidertrackBar.Select();

                CmnMethods.AppMsgBox("Please set the path of the LIGHTNING RETURNS FINAL FANTASY XIII executable file", "Information", MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    UserSettings loadFromXml = UserSettings.LoadSettings();
                    PathtextBox.Text = loadFromXml.ExePath;
                    if (!File.Exists(PathtextBox.Text + "LRFF13.exe"))
                    {
                        CmnMethods.AppMsgBox("Main executable file is not present in the file path that was set before\nPlease set the correct path and then Set the volume", "Warning", MessageBoxIcon.Warning);
                        PathtextBox.Text = "";
                    }

                    switch (loadFromXml.VoiceOver)
                    {
                        case "en":
                            EnVOradiobutton.Checked = true;
                            break;
                        case "jp":
                            JpVOradiobutton.Checked = true;
                            break;
                        case "jpn":
                            JpnUIVOradiobutton.Checked = true;
                            break;
                        default:
                            CmnMethods.AppMsgBox("Voiceover setting set in xml file was invalid", "Warning", MessageBoxIcon.Warning);
                            EnVOradiobutton.Checked = true;
                            break;
                    }

                    switch (loadFromXml.FileSystem)
                    {
                        case "packed":
                            Packedradiobutton.Checked = true;
                            break;
                        case "nova":
                            Novaradiobutton.Checked = true;
                            break;
                        default:
                            CmnMethods.AppMsgBox("FileSystem setting set in xml file was invalid", "Warning", MessageBoxIcon.Warning);
                            Packedradiobutton.Checked = true;
                            break;
                    }

                    switch (loadFromXml.SliderValue)
                    {
                        case 0:
                            SlidertrackBar.Value = 0;
                            break;
                        case 1:
                            SlidertrackBar.Value = 1;
                            break;
                        case 2:
                            SlidertrackBar.Value = 2;
                            break;
                        case 3:
                            SlidertrackBar.Value = 3;
                            break;
                        case 4:
                            SlidertrackBar.Value = 4;
                            break;
                        case 5:
                            SlidertrackBar.Value = 5;
                            break;
                        case 6:
                            SlidertrackBar.Value = 6;
                            break;
                        case 7:
                            SlidertrackBar.Value = 7;
                            break;
                        case 8:
                            SlidertrackBar.Value = 8;
                            break;
                        case 9:
                            SlidertrackBar.Value = 9;
                            break;
                        case 10:
                            SlidertrackBar.Value = 10;
                            break;
                        default:
                            CmnMethods.AppMsgBox("Slider value set in xml file was invalid", "Warning", MessageBoxIcon.Warning);
                            SlidertrackBar.Value = 5;
                            break;
                    }

                    SlidertrackBar.Select();
                }
                catch (Exception)
                {
                    CmnMethods.AppMsgBox("Data entered in UserSettings file is corrupt\nPlease re configure the settings again", "Warning", MessageBoxIcon.Warning);
                    CmnMethods.IfFileExistsDel("UserSettings.xml");
                    DisableComponents();
                    EnVOradiobutton.Checked = true;
                    Packedradiobutton.Checked = true;
                    SlidertrackBar.Value = 5;
                    SlidertrackBar.Select();
                }
            }
        }

        private void Browsebutton_Click(object sender, System.EventArgs e)
        {
            var lrExe = "LRFF13.exe";
            OpenFileDialog pathSelect = new OpenFileDialog
            {
                FileName = lrExe,
                Filter = lrExe + $"|{lrExe}",
                RestoreDirectory = true
            };

            if (pathSelect.ShowDialog() == DialogResult.OK)
            {
                EnableComponents();

                var lrFilePath = pathSelect.FileName;
                var lrfolder = Path.GetDirectoryName(lrFilePath);

                PathtextBox.Text = lrfolder + "\\";
                SlidertrackBar.Select();
            }
        }


        public void EnableComponents()
        {
            EnVOradiobutton.Enabled = true;
            JpVOradiobutton.Enabled = true;
            JpnUIVOradiobutton.Enabled = true;
            Packedradiobutton.Enabled = true;
            Novaradiobutton.Enabled = true;
            SlidertrackBar.Enabled = true;
            SetVolumebutton.Enabled = true;
        }


        public void DisableComponents()
        {
            EnVOradiobutton.Enabled = false;
            JpVOradiobutton.Enabled = false;
            JpnUIVOradiobutton.Enabled = false;
            Packedradiobutton.Enabled = false;
            Novaradiobutton.Enabled = false;
            SlidertrackBar.Enabled = false;
            SetVolumebutton.Enabled = false;
        }


        private void SetVolumebutton_Click(object sender, EventArgs e)
        {
            DisableComponents();

            var weissPath = PathtextBox.Text;

            PathtextBox.ReadOnly = true;

            SetVolumebutton.Text = "Setting...";
            int SliderVal = SlidertrackBar.Value;

            SaveValuesToXml();

            if (Packedradiobutton.Checked.Equals(true))
            {
                var langCode = "";
                if (EnVOradiobutton.Checked.Equals(true))
                {
                    langCode = "a";
                }
                if (JpVOradiobutton.Checked.Equals(true))
                {
                    langCode = "v";
                }

                Task.Run(() =>
                {
                    try
                    {
                        var filelist2file = weissPath + "weiss_data\\sys\\filelist2" + langCode + ".win32.bin";
                        var whiteBin2File = weissPath + "weiss_data\\sys\\white_img2" + langCode + ".win32.bin";
                        var whiteBinZoneFile = weissPath + "weiss_data\\zone\\white_z0120" + langCode + "_img.win32.bin";

                        if (File.Exists(filelist2file) && File.Exists(whiteBin2File) && File.Exists(whiteBinZoneFile))
                        {
                            try
                            {
                                InitatePatching.PrePatch(weissPath, langCode, SliderVal);
                            }
                            catch (Exception ex)
                            {
                                CmnMethods.AppMsgBox("Error: " + ex, "Error", MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            if (!JpnUIVOradiobutton.Checked.Equals(true))
                            {
                                CmnMethods.AppMsgBox("Required game files are missing\nPlease check if the voice over option that you have set in this app is available for your game.", "Error", MessageBoxIcon.Error);
                            }
                            else
                            {
                                CmnMethods.AppMsgBox("必要な ゲームファイル が 不足しています。\n\nこの アプリで 設定した ボイスオーバーオプション が、お使い の ゲーム で 利用可能 か どうか 確認してください。", "Error", MessageBoxIcon.Error);
                            }
                        }
                    }
                    finally
                    {
                        if (!File.Exists(weissPath + "weiss_data\\sys\\LRMusicVolumeSlider.exe") 
                        && File.Exists(weissPath + "weiss_data\\sys\\ffxiiicrypt.exe"))
                        {
                            CmnMethods.IfFileExistsDel(weissPath + "weiss_data\\sys\\ffxiiicrypt.exe");
                        }

                        CmnMethods.IfFileExistsDel(weissPath + "weiss_data\\sys\\filelist2" + langCode + ".win32.txt");
                        CmnMethods.IfDirExistsDel(weissPath + "weiss_data\\sys\\white_img2" + langCode + "_win32");
                        CmnMethods.IfDirExistsDel(weissPath + "zone");

                        BeginInvoke(new Action(() => { EnableComponents(); }));
                        SetVolumebutton.BeginInvoke(new Action(() => SetVolumebutton.Text = "Set Volume"));
                        BeginInvoke(new Action(() => { PathtextBox.ReadOnly = false; }));
                        BeginInvoke(new Action(() => { SlidertrackBar.Select(); }));
                    }
                });
            }

            if (Novaradiobutton.Checked.Equals(true))
            {
                var unpackedMusicDir = PathtextBox.Text + "weiss_data\\sound\\pack\\8000";

                if (Directory.Exists(unpackedMusicDir))
                {
                    try
                    {
                        PatchPrep.NovaMode(unpackedMusicDir, SliderVal);
                    }
                    catch (Exception ex)
                    {
                        CmnMethods.AppMsgBox("Error: " + ex, "Error", MessageBoxIcon.Error);
                    }
                }
                else
                {
                    CmnMethods.AppMsgBox("Unable to locate the unpacked music folder\nPlease unpack the game data correctly with the Nova mod manager and then try setting the volume.", "Error", MessageBoxIcon.Error);
                }

                EnableComponents();
                SetVolumebutton.Text = "Set Volume";
                PathtextBox.ReadOnly = false;
                SlidertrackBar.Select();
            }
        }


        public void SaveValuesToXml()
        {
            if (!File.Exists(PathtextBox.Text + "LRFF13.exe"))
            {
                CmnMethods.AppMsgBox("Unable to locate main executable file.\nPlease set the correct game path", "Error", MessageBoxIcon.Error);
            }
            else
            {
                UserSettings saveXml = new UserSettings
                {
                    ExePath = PathtextBox.Text
                };

                if (EnVOradiobutton.Checked.Equals(true))
                {
                    saveXml.VoiceOver = "en";
                }

                if (JpVOradiobutton.Checked.Equals(true))
                {
                    saveXml.VoiceOver = "jp";
                }

                if (JpnUIVOradiobutton.Checked.Equals(true))
                {
                    saveXml.VoiceOver = "jpn";
                }

                if (Packedradiobutton.Checked.Equals(true))
                {
                    saveXml.FileSystem = "packed";
                }

                if (Novaradiobutton.Checked.Equals(true))
                {
                    saveXml.FileSystem = "nova";
                }

                int SliderVal = SlidertrackBar.Value;
                switch (SliderVal)
                {
                    case 0:
                        saveXml.SliderValue = 0;
                        break;
                    case 1:
                        saveXml.SliderValue = 1;
                        break;
                    case 2:
                        saveXml.SliderValue = 2;
                        break;
                    case 3:
                        saveXml.SliderValue = 3;
                        break;
                    case 4:
                        saveXml.SliderValue = 4;
                        break;
                    case 5:
                        saveXml.SliderValue = 5;
                        break;
                    case 6:
                        saveXml.SliderValue = 6;
                        break;
                    case 7:
                        saveXml.SliderValue = 7;
                        break;
                    case 8:
                        saveXml.SliderValue = 8;
                        break;
                    case 9:
                        saveXml.SliderValue = 9;
                        break;
                    case 10:
                        saveXml.SliderValue = 10;
                        break;
                }

                saveXml.SaveSettings();
            }
        }

        private void AboutlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutForm appAbout = new AboutForm();
            System.Media.SystemSounds.Asterisk.Play();
            appAbout.ShowDialog();
        }

        private void HelplinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (File.Exists("AppHelp.txt"))
            {
                try
                {
                    Process.Start("AppHelp.txt");
                }
                catch (Exception ex)
                {
                    CmnMethods.AppMsgBox("Error: " + ex, "Error", MessageBoxIcon.Error);
                }
            }
            else
            {
                CmnMethods.AppMsgBox("Unable to locate the help text file\nPlease ensure that this text file is present next to the app before using this option.", "Error", MessageBoxIcon.Error);
            }
        }
    }
}