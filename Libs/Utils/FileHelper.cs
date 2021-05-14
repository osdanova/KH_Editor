using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

namespace KH_Editor.Libs.Utils
{
    class FileHelper
    {

        public static void saveFile(List<byte> byteFile)
        {
            if (byteFile == null || byteFile.Count == 0) return;

            SaveFileDialog sfd;
            sfd = new SaveFileDialog();
            sfd.Title = "Save file";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                File.WriteAllBytes(sfd.FileName, byteFile.ToArray());
            }
        }
    }
}
