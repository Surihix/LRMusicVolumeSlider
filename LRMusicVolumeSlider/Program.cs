﻿using System;
using System.IO;
using System.Windows.Forms;

namespace LRMusicVolumeSlider
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CoreForm());

        }
    }
}