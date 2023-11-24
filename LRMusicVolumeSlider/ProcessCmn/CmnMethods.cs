using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LRMusicVolumeSlider
{
    internal class CmnMethods
    {
        public static void AppMsgBox(string msg, string msgHeader, MessageBoxIcon msgType)
        {
            MessageBox.Show(msg, msgHeader, MessageBoxButtons.OK, msgType);
        }

        public static void IfFileExistsDel(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void IfDirExistsDel(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
        }

        public static void FFXiiiCryptTool(string cryptDir, string action, string fileListName, ref string actionType)
        {
            using (Process xiiiCrypt = new Process())
            {
                xiiiCrypt.StartInfo.WorkingDirectory = cryptDir;
                xiiiCrypt.StartInfo.FileName = "ffxiiicrypt.exe";
                xiiiCrypt.StartInfo.Arguments = action + fileListName + actionType;
                xiiiCrypt.StartInfo.UseShellExecute = true;
                xiiiCrypt.Start();
                xiiiCrypt.WaitForExit();
            }
        }

        public static void FileCountReader(string filelistPathsFileVar, ref uint totalFileCountVar)
        {
            totalFileCountVar = (uint)File.ReadAllLines(filelistPathsFileVar).Count();
            totalFileCountVar --;
        }
    }
}