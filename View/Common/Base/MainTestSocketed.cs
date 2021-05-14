using System.Diagnostics;
using KH_Editor.Libs.Memory;
using KH_Editor.View.Common.Test;
using KH_Editor.View.Main;

namespace KH_Editor.View.Common.Base
{
    class MainTestSocketed : TestComponentSocket
    {
        public TestComponent testComponent;
        public MainSocket mainSocket;

        // CONSTRUCTORS

        public MainTestSocketed(MainSocket mainSocketIn, Enums.ProcessType procType)
        {
            mainSocket = mainSocketIn;
            testComponent = new TestComponent(procType, this);
        }
        public MainTestSocketed(MainSocket mainSocketIn, Enums.ProcessType procType, bool readOn, bool writeOn, bool exportOn)
        {
            mainSocket = mainSocketIn;
            testComponent = new TestComponent(procType, this, readOn, writeOn, exportOn);
        }

        // ACTIONS

        public virtual void readAction(ProcessHandler processHandler) { Debug.WriteLine("UNDEFINED READ ACTION"); }

        public virtual void writeAction(ProcessHandler processHandler) { Debug.WriteLine("UNDEFINED WRITE ACTION"); }

        public virtual void exportAction() { Debug.WriteLine("UNDEFINED EXPORT ACTION"); }

        // FUNCTIONS

        public void writeInfoLabel(string message)
        {
            if (mainSocket != null) mainSocket.writeInfoLabel(message);
        }
    }
}
