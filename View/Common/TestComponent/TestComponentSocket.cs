using KH_Editor.Libs.Memory;

namespace KH_Editor.View.Common.TestComponent
{
    public interface TestComponentSocket
    {
        public void readAction(ProcessHandler processHandler);
        public void writeAction(ProcessHandler processHandler);
        public void writeInfoLabel(string message);
    }
}
