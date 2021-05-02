using System.Collections.Generic;
using System.Diagnostics;
using KH_Editor.Enums;

namespace KH_Editor.Libs.Memory
{
    class ProcessHandler
    {
        public Process hookedProcess;
        public ProcessType hookedProcessType;
        public long mainModuleAddress;

        public ProcessHandler (ProcessType processType)
        {
            hookedProcessType = processType;
        }

        public void hookProcessByType()
        {
            Process searchedProcess = ProcessHelper.searchProcessByType(hookedProcessType);
            if (searchedProcess == null) { Debug.WriteLine("ProcessHandler > Process hooking failed"); return; }

            hookedProcess = searchedProcess;
            mainModuleAddress = hookedProcess.MainModule.BaseAddress.ToInt64();
            Debug.WriteLine("ProcessHandler > Successfuly hooked to ["+hookedProcess.ProcessName+"]");
        }

        public List<byte> readBytesFromProcess(long address, long size)
        {
            //Debug.WriteLine("Reading from: " + address + ", size: " + size);
            if (hookedProcess == null) { Debug.WriteLine("ProcessHandler > readBytesFromProcess > No process is hooked"); return null; }
            return MemoryAccess.readMemory(hookedProcess, address, size);
        }
        public List<byte> readBytesFromProcessModule(long address, long size)
        {
            return readBytesFromProcess(mainModuleAddress + address, size);
        }
        public void writeBytesToProcess(long address, List<byte> input)
        {
            //Debug.WriteLine("Writing to: " + address + ", size: " + input.Count);
            if (hookedProcess == null) { Debug.WriteLine("ProcessHandler > readBytesFromProcess > No process is hooked"); return; }
            MemoryAccess.writeMemory(hookedProcess, address, input);
        }
        public void writeBytesToProcessModule(long address, List<byte> input)
        {
            writeBytesToProcess(mainModuleAddress + address, input);
        }
    }
}
