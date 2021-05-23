using System;
using KH_Editor.Dictionaries.KH_DDD;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_dropprm
{
    [Serializable]
    class DDD_dropprm_Entry
    {
        public static readonly int SIZE = 28;
        public int Id { get; set; }

        public string name { get { return DDD_Entities.getNameByDropId(Id); } }

        // Orb 1
        [Data] public byte id_1 { get; set; }
        [Data] public byte category_1 { get; set; }
        [Data] public byte pad_1 { get; set; }
        [Data] public byte chance_1 { get; set; }
        public string name_1 { get { return DDD_Items.getItemNameById(id_1, category_1); } }

        // Orb 2
        [Data] public byte id_2 { get; set; }
        [Data] public byte category_2 { get; set; }
        [Data] public byte pad_2 { get; set; }
        [Data] public byte chance_2 { get; set; }
        public string name_2 { get { return DDD_Items.getItemNameById(id_2, category_2); } }

        // Orb 3
        [Data] public byte id_3 { get; set; }
        [Data] public byte category_3 { get; set; }
        [Data] public byte pad_3 { get; set; }
        [Data] public byte chance_3 { get; set; }
        public string name_3 { get { return DDD_Items.getItemNameById(id_3, category_3); } }

        // Treat
        [Data] public byte id_4 { get; set; }
        [Data] public byte category_4 { get; set; }
        [Data] public byte pad_4 { get; set; }
        [Data] public byte chance_4 { get; set; }
        public string name_4 { get { return DDD_Items.getItemNameById(id_4, category_4); } }

        // Item - Item or Training toy
        [Data] public byte id_5 { get; set; }
        [Data] public byte category_5 { get; set; }
        [Data] public byte pad_5 { get; set; }
        [Data] public byte chance_5 { get; set; }
        public string name_5 { get { return DDD_Items.getItemNameById(id_5, category_5); } }

        // Dream Piece 1
        [Data] public byte id_6 { get; set; }
        [Data] public byte category_6 { get; set; }
        [Data] public byte pad_6 { get; set; }
        [Data] public byte chance_6 { get; set; }
        public string name_6 { get { return DDD_Items.getItemNameById(id_6, category_6); } }

        // Dream Piece 2
        [Data] public byte id_7 { get; set; }
        [Data] public byte category_7 { get; set; }
        [Data] public byte pad_7 { get; set; }
        [Data] public byte chance_7 { get; set; }
        public string name_7 { get { return DDD_Items.getItemNameById(id_7, category_7); } }
    }
}
