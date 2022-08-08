using System;
using System.IO;
using System.Windows.Forms;

namespace LRMusicVolumeSlider
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string CmnError = "\nPlease re download and extract all of the app's files correctly.";
            goto FoldersCheck;


            FoldersCheck:
            bool PatchToolsDir = Directory.Exists("PatchTools");
            bool ScriptsDir = Directory.Exists("Scripts");

            if (PatchToolsDir && ScriptsDir)
            {
                goto FilesCheck;
            }
            else
            {           
                string PatchToolsDirError = "PatchTools folder is missing.";
                string ScriptsDirError = "Scripts folder is missing.";
                string FolderErrorCap = "Missing a Folder";
                MessageBox.Show((!PatchToolsDir ? PatchToolsDirError : ScriptsDirError)+CmnError, FolderErrorCap, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            FilesCheck:         
            bool PatchToolsFiles = Directory.GetFiles("PatchTools", "*.exe").Length == 4;
            bool ScriptsFiles = Directory.GetFiles("Scripts", "*.bat").Length == 4;

            if (PatchToolsFiles && ScriptsFiles)
            {
                Application.Run(new MainFormWindow());
            }
            else
            {
                string PatchToolsFilesError = "One or more files missing in the PatchTools folder";
                string ScriptFilesError = "One or more files missing in the Scripts folder";
                string FileErrorCap = "Missing files";
                MessageBox.Show((!PatchToolsFiles ? PatchToolsFilesError : ScriptFilesError), FileErrorCap, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }              
        }
    }
}
