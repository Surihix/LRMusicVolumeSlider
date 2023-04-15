using System;
using System.IO;
using System.Windows.Forms;

namespace LRMusicVolumeSlider
{
    internal class PatchPrep
    {
        public static void PackedMode(string zoneFilelistPathsFile, string zoneWhiteBinFile, int sliderValueVar)
        {
            uint totalFileCount = 0;
            CmnMethods.FileCountReader(zoneFilelistPathsFile, ref totalFileCount);

            using (var zonePathsReader = new StreamReader(zoneFilelistPathsFile))
            {
                using (var zoneBin = new FileStream(zoneWhiteBinFile, FileMode.Open, FileAccess.Write))
                {
                    using (var zoneBinWriter = new BinaryWriter(zoneBin))
                    {

                        for (int m = 0; m < totalFileCount; m++)
                        {
                            string[] parsedFileLine = zonePathsReader.ReadLine().Split(':');
                            var fPos = Convert.ToUInt32(parsedFileLine[0], 16) * 2048;
                            var fPath = parsedFileLine[3];

                            var fDir = Path.GetDirectoryName(fPath);

                            if (fDir.Contains("sound\\pack\\8000"))
                            {
                                var fname = Path.GetFileName(fPath);

                                AdjustVolume.SCD(zoneBinWriter, fPos + 296, fname, sliderValueVar);
                            }
                        }
                    }
                }
            }

            PatchSucess(sliderValueVar);
        }


        public static void NovaMode(string unpackedMusicDirVar, int sliderValueVar)
        {
            string[] musicDir = Directory.GetFiles(unpackedMusicDirVar, "*.scd", SearchOption.AllDirectories);
            
            if (musicDir.Length.Equals(0))
            {
                CmnMethods.AppMsgBox("Unpacked music folder is empty\nPlease unpack the game data correctly with the Nova mod manager and then try setting the volume.", "Error", MessageBoxIcon.Error);
                return;
            }

            foreach (var musicFile in musicDir)
            {
                var musicFileInfo = new FileInfo(musicFile);
                var musicFileName = musicFileInfo.Name;

                using (var scdFile = new FileStream(musicFile, FileMode.Open, FileAccess.Write))
                {
                    using (var scdWriter = new BinaryWriter(scdFile))
                    {
                        AdjustVolume.SCD(scdWriter, 296, musicFileName, sliderValueVar);
                    }
                }
            }

            PatchSucess(sliderValueVar);
        }


        public static void PatchSucess(int sliderValueVar)
        {
            CmnMethods.AppMsgBox("Music volume is set to level " + sliderValueVar, "Success", MessageBoxIcon.Information);
        }
    }
}