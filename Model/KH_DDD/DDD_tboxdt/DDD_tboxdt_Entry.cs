using System;
using KH_Editor.Dictionaries.KH_DDD;
using KH_Editor.Enums.DDD;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_tboxdt
{
    [Serializable]
    class DDD_tboxdt_Entry
    {
        [Data] public byte unk0 { get; set; }
        [Data] public byte unk1 { get; set; }
        [Data] public byte itemId { get; set; }
        [Data] public byte itemCategory { get; set; }
        [Data] public byte worldId { get; set; }
        [Data] public byte chestId { get; set; }
        [Data] public short padding { get; set; }

        public string itemName
        {
            get
            {
                if(itemCategory == (long)DDD_ItemCategories.COMMAND) return DDD_Commands.getCommandById(itemId);
                else return DDD_Items.getItemNameById(itemId, itemCategory);
            }
        }
        public string categoryName { get { return DDD_Items.getCategoryNameById(itemCategory); } }

        public string worldName { get { return DDD_Areas.getWorldNameById(worldId); } }
    }
}
