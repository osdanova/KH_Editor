using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using KH_Editor.Enums;

namespace KH_Editor.Libs.Memory
{
    class ProcessHelper
    {
        public static Process searchProcessByType(ProcessType processType)
        {
            string processName = processTypeGetString(processType);
            if (processName == null) { Debug.WriteLine("ProcessHelper > ProcessType string not found [" + processType.ToString() + "]"); return null; }

            Process searchedProcess = Process.GetProcessesByName(processName).FirstOrDefault();
            if (searchedProcess == null) { Debug.WriteLine("ProcessHelper > Process not found [" + processName + "]"); return null; }

            return searchedProcess;
        }

        // Returns the String to search programs by
        public static string processTypeGetString(ProcessType processType)
        {
            switch (processType)
            {
                case ProcessType.DDD_EGS:
                    return "KINGDOM HEARTS Dream Drop Distance";
                default:
                    return null;
            }
        }

        public static List<Process> getRunningKHProcesses()
        {
            return Process.GetProcessesByName("KINGDOM HEARTS").ToList();
        }
    }
}
