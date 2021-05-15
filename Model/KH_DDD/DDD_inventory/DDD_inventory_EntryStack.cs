using System;
using KH_Editor.Dictionaries.KH_DDD;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_inventory
{
    [Serializable]
    class DDD_inventory_EntryStack
    {
        // type and category can be 0, in which case the item is not shown in the inventory
        public byte typeId { get; set; }
        public byte categoryId { get; set; }

        [Data] public byte type { get; set; }
        [Data] public byte category { get; set; }
        [Data] public short amount { get; set; }

        public string name { get { return DDD_Items.getItemNameById(typeId, categoryId); } }
        public string categoryName { get { return DDD_Items.getCategoryNameById(categoryId); } }
        public bool obtained
        {
            get
            {
                if (category != 0) return true;
                return false;
            }
            set
            {
                if (value)
                {
                    type = typeId;
                    category = categoryId;
                }
                else
                {
                    type = 0;
                    category = 0;
                }
            }
        }
    }
}
