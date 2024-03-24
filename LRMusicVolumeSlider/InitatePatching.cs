using LRMusicVolumeSlider.WhiteBinTools.SupportClasses;
using LRMusicVolumeSlider.WhiteBinTools.UnpackClasses;
using System.IO;
using System.Windows.Forms;

namespace LRMusicVolumeSlider
{
    internal class InitatePatching
    {
        public static void PrePatch(string weissPathVar, string langCodeVar, int sliderValueVar)
        {
            var filelist2file = weissPathVar + "weiss_data\\sys\\filelist2" + langCodeVar + ".win32.bin";
            UnpackTypeChunks.UnpackFilelistChunks(CmnEnums.GameCodes.ff132, filelist2file);

            var filelist2PathsFile = weissPathVar + "weiss_data\\sys\\filelist2" + langCodeVar + ".win32.bin.txt";
            var pathValid = false;
            CheckFilelistPaths(filelist2PathsFile, langCodeVar, ref pathValid);

            switch (pathValid)
            {
                case true:
                    var whiteBin2File = weissPathVar + "weiss_data\\sys\\white_img2" + langCodeVar + ".win32.bin";
                    UnpackTypeArchive.UnpackSingle(CmnEnums.GameCodes.ff132, filelist2file, whiteBin2File, "..\\..\\..\\zone\\filelist_z0120" + langCodeVar + ".win32.bin");

                    var zoneFileListFile = weissPathVar + "zone\\filelist_z0120" + langCodeVar + ".win32.bin";
                    UnpackTypeChunks.UnpackFilelistChunks(CmnEnums.GameCodes.ff132, zoneFileListFile);

                    var zoneFilelistPathsFile = weissPathVar + "zone\\filelist_z0120" + langCodeVar + ".win32.bin.txt";
                    var zoneWhiteBinFile = weissPathVar + "weiss_data\\zone\\white_z0120" + langCodeVar + "_img.win32.bin";
                    PatchPrep.PackedMode(zoneFilelistPathsFile, zoneWhiteBinFile, sliderValueVar);
                    break;

                case false:
                    CmnMethods.AppMsgBox("Zone filelist path is modified.\nPlease verify your game files with steam or unpack the game data with the Nova Mod Manager and use the Nova/Unpacked mode option from this app.", "Error", MessageBoxIcon.Error);
                    break;
            }
        }


        public static void CheckFilelistPaths(string filelist2PathsFile, string langCodeVar, ref bool pathValidVar)
        {
            uint totalFileCount = 0;
            CmnMethods.FileCountReader(filelist2PathsFile, ref totalFileCount);

            using (FileStream pathsFile = new FileStream(filelist2PathsFile, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader pathsReader = new StreamReader(pathsFile))
                {

                    for (int f = 0; f < totalFileCount; f++)
                    {
                        var currentLine = pathsReader.ReadLine();
                        string[] currentLineData = currentLine.Split(':');
                        var filePath = currentLineData[3];

                        if (filePath.Equals("../../../zone/filelist_z0120" + langCodeVar + ".win32.bin"))
                        {
                            pathValidVar = true;
                        }
                    }
                }
            }
        }
    }
}