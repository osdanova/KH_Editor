using System;
using System.Collections.Generic;
using System.Diagnostics;
using KH_Editor.Enums;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.Structures;

namespace KH_Editor.Libs.Memory
{
    public class ProcessHandler
    {
        // COMPONENTS

        public Process hookedProcess;
        public ProcessType hookedProcessType;
        public long mainModuleAddress;

        // CONSTRUCTORS

        public ProcessHandler (ProcessType processType)
        {
            hookedProcessType = processType;
            hookProcessByType();
        }

        // FUNCTIONS

        public void hookProcessByType()
        {
            Process searchedProcess = ProcessHelper.searchProcessByType(hookedProcessType);
            hookedProcess = searchedProcess;
            if (searchedProcess == null) { Debug.WriteLine("ProcessHandler > Process hooking failed"); return; }
            mainModuleAddress = hookedProcess.MainModule.BaseAddress.ToInt64();
            Debug.WriteLine("ProcessHandler > Successfuly hooked to ["+hookedProcess.ProcessName+"]");
        }

        // READ

        public List<byte> readBytesFromProcessModule(MemoryData data) { return readBytesFromProcessModule(data.address, data.size); }
        public List<byte> readBytesFromProcessModule(long address, long size) { return readBytesFromProcess(mainModuleAddress + address, size); }
        public List<byte> readBytesFromProcess(MemoryData data) { return readBytesFromProcess(data.address, data.size); }
        public List<byte> readBytesFromProcess(long address, long size)
        {
            //Debug.WriteLine("Reading from: " + address + ", size: " + size);
            if (hookedProcess == null) { Debug.WriteLine("ProcessHandler > readBytesFromProcess > No process is hooked"); return new List<byte>(); }
            return MemoryAccess.readMemory(hookedProcess, address, size);
        }
        public List<byte> readBytesFromProcessModuleUntilHexString(long address, string text) { return readBytesFromProcessUntilHexString(mainModuleAddress + address, text); }
        public List<byte> readBytesFromProcessUntilHexString(long address, string hexString)
        {
            long stringAddress = findAddressOf(hexString, address, 100000);
            long lengthToRead = stringAddress - address;
            if (lengthToRead <= 0) return new List<byte>();

            return readBytesFromProcess(address, lengthToRead);
        }

        // WRITE

        public void writeBytesToProcessModule(long address, List<byte> input) { writeBytesToProcess(mainModuleAddress + address, input); }
        public void writeBytesToProcess(long address, List<byte> input)
        {
            //Debug.WriteLine("Writing to: " + address + ", size: " + input.Count);
            if (hookedProcess == null) { Debug.WriteLine("ProcessHandler > readBytesFromProcess > No process is hooked"); return; }
            MemoryAccess.writeMemory(hookedProcess, address, input);
        }

        // OTHER UTILS
        public long findAddressOf(String hexString, long address, int findRange)
        {
            if (hookedProcess == null) { Debug.WriteLine("ProcessHandler > readBytesFromProcess > No process is hooked"); return -1; }

            List<byte> memoryDump = MemoryAccess.readMemory(hookedProcess, address, findRange);
            String memoryDumpString = BinaryHelper.bytesAsHexString(memoryDump);
            long foundIndex = memoryDumpString.IndexOf(hexString);

            return address + (foundIndex / 2);
        }
    }
}
