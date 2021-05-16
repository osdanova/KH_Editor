using System;
using KH_Editor.Dictionaries.KH_DDD;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_itemdata
{
    [Serializable]
    class DDD_itemdata_Entry
    {
        [Data] public byte id { get; set; }
        [Data] public byte category { get; set; }
        [Data] public byte unk1 { get; set; }
        [Data] public byte enabledByte { get; set; }

        public string name { get { return DDD_Items.getItemNameById(id, category); } }
        public string categoryName { get { return DDD_Items.getCategoryNameById(category); } }

        public bool enabled
        {
            get { return enabledByte == 1; }
            set { if (value) enabledByte = 1; else enabledByte = 0; }
        }
    }
}
