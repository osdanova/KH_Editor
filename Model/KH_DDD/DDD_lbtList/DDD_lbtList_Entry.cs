using System;
using KH_Editor.Dictionaries.KH_DDD;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_lbtList
{
    [Serializable]
    class DDD_lbtList_Entry
    {
        public static readonly int SIZE = 12;

        [Data] public byte unk0 { get; set; }
        [Data] public byte unk1 { get; set; }
        [Data] public short padding { get; set; }
        [Data] public byte it1 { get; set; }
        [Data] public byte itc1 { get; set; }
        [Data] public byte it2 { get; set; }
        [Data] public byte itc2 { get; set; }
        [Data] public byte it3 { get; set; }
        [Data] public byte itc3 { get; set; }
        [Data] public byte it4 { get; set; }
        [Data] public byte itc4 { get; set; }

        public string item1 { get { return DDD_Items.getItemNameById(it1, itc1); } }
        public string category1 { get { return DDD_Items.getCategoryNameById(itc1); } }
        public string item2 { get { return DDD_Items.getItemNameById(it2, itc2); } }
        public string category2 { get { return DDD_Items.getCategoryNameById(itc2); } }
        public string item3 { get { return DDD_Items.getItemNameById(it3, itc3); } }
        public string category3 { get { return DDD_Items.getCategoryNameById(itc3); } }
        public string item4 { get { return DDD_Items.getItemNameById(it4, itc4); } }
        public string category4 { get { return DDD_Items.getCategoryNameById(itc4); } }
    }
}
