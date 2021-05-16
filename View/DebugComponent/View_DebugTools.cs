using System;
using System.Collections.Generic;
using System.Diagnostics;
using KH_Editor.Enums;
using KH_Editor.Libs.Memory;
using System.Linq;
using KH_Editor.Libs.Utils;
using KH_Editor.View.Main;
using KH_Editor.Model.KH_DDD.DDD_btlparam;
using Xe.BinaryMapper;
using System.IO;

namespace KH_Editor.View.DebugComponent
{
    class View_DebugTools
    {
        public static void executeCode()
        {
            Debug.WriteLine("DEBUG > executeCode > IN");

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
        public static string readBytesInAddress(ProcessHandler procHandler, long address, long size)
        {
            List<byte> memoryDump = MemoryAccess.readMemory(procHandler.hookedProcess, address, size);
            return BinaryHelper.bytesAsHexString(memoryDump);
        }
    }
}
