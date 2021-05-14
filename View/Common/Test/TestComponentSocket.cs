using KH_Editor.Libs.Memory;

namespace KH_Editor.View.Common.Test
{
    public interface TestComponentSocket
    {
        public void readAction(ProcessHandler processHandler);
        public void writeAction(ProcessHandler processHandler);
        public void exportAction();
        public void writeInfoLabel(string message);
    }
}
