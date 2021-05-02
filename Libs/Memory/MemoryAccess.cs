using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace KH_Editor.Libs.Memory
{
    class MemoryAccess
    {
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hProcess);

        //------------------------

        public static List<byte> readMemory(Process process, long address, long size)
        {
            var hProc = OpenProcess(ProcessAccessFlags.All, false, (int)process.Id);
            var val = new byte[size];

            int wtf = 0;
            ReadProcessMemory(hProc, new IntPtr(address), val, (UInt32)val.LongLength, out wtf);

            CloseHandle(hProc);

            return val.ToList();
        }

        public static void writeMemory(Process process, long address, byte[] input)
        {
            var hProc = OpenProcess(ProcessAccessFlags.All, false, (int)process.Id);

            int wtf = 0;
            WriteProcessMemory(hProc, new IntPtr(address), input, (UInt32)input.LongLength, out wtf);

            CloseHandle(hProc);
        }
        public static void writeMemory(Process process, long address, List<byte> input)
        {
            writeMemory(process, address, input.ToArray());
        }
    }
}
