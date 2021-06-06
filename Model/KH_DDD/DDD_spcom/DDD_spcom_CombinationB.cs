using System;
using KH_Editor.Dictionaries.KH_DDD;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_spcom
{
    [Serializable]
    class DDD_spcom_CombinationB
    {
        public static readonly int SIZE = 16;

        [Data] public byte itemId { get; set; }
        [Data] public byte itemCategory { get; set; }
        [Data] public short hp { get; set; }
        [Data] public byte attack { get; set; }
        [Data] public byte defense { get; set; }
        [Data] public byte magic { get; set; }
        [Data] public byte ele_fire { get; set; }
        [Data] public byte ele_blizzard { get; set; }
        [Data] public byte ele_thunder { get; set; }
        [Data] public byte ele_water { get; set; }
        [Data] public byte ele_dark { get; set; }
        [Data] public byte ele_light { get; set; }
        [Data] public byte affinity { get; set; }
        [Data] public short padding { get; set; }

        public string itemName { get { return DDD_Items.getItemNameById(itemId, itemCategory); } }
    }
}
