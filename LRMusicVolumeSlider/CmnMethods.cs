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

        public static void FileCountReader(string filelistPathsFileVar, ref uint totalFileCountVar)
        {
            totalFileCountVar = (uint)File.ReadAllLines(filelistPathsFileVar).Count();
            totalFileCountVar--;
        }
    }
}