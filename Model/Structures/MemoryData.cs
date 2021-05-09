namespace KH_Editor.Model.Structures
{
    public class MemoryData
    {
        public long address { get; set; }
        public int size { get; set; }

        public MemoryData() { }
        public MemoryData(long addressIn, int sizeIn) { address = addressIn; size = sizeIn; }
    }
}
