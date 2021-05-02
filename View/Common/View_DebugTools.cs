using System;
using System.Collections.Generic;
using System.Diagnostics;
using KH_Editor.Enums;
using KH_Editor.Libs.Memory;
using System.Linq;
using KH_Editor.Libs.Utils;

namespace KH_Editor.View.Common
{
    class View_DebugTools
    {
        public static void executeCode()
        {
            Debug.WriteLine("DEBUG > executeCode > IN");

            //Byte[] myByteArray = { 1,1,1,1,1,1,1,1 };
            //DDD_btlparam_Entry myEntry = BinaryMapping.ReadObject<DDD_btlparam_Entry>(new MemoryStream(myByteArray));

            //ProcessHandler procHandler = new ProcessHandler(ProcessType.DDD_EGS);
            //procHandler.hookProcessByType();
            //int munny = BinaryHelper.bytesAsInt(procHandler.readBytesFromProcessModule(0xA4A05C, 4));
            //Debug.WriteLine("DEBUG > munny: " + munny);
            //munny = 9876;
            //procHandler.writeBytesToProcessModule(0xA4A05C, BinaryHelper.intAsBytes(munny));

            Debug.WriteLine("DEBUG > executeCode > OUT");
        }

        public static void printRunningKHProcesses()
        {
            foreach (Process khProcess in ProcessHelper.getRunningKHProcesses()) Debug.WriteLine("KH Process found: " + khProcess.ProcessName);
        }
        public static void printRunningProcesses()
        {
            foreach (Process process in Process.GetProcesses()) Debug.WriteLine("Process: " + process.ProcessName);
        }
    }
}
