using System;
using System.Collections.Generic;

namespace KH_Editor.Dictionaries.KH_DDD
{
    class DDD_Lboard
    {
        public static String getNodeById(byte id)
        {
            if (nodeTypeById.ContainsKey(id)) return nodeTypeById[id];
            return "";
        }
        public static Dictionary<byte, string> nodeTypeById = new Dictionary<byte, string>()
        {
            { 0 , "NONE" },
            { 1 , "Empty" },
            { 2 , "START" },
            { 3 , "Stat" },
            { 4 , "Item" },
            { 5 , "" },
            { 6 , "Level Gate" },
            { 7 , "Secret" },
            { 8 , "END" },
            { 9 , "" },
            { 10 , "" },
            { 22 , "Link Gate" },
            { 23 , "Secret (Red)" },
            { 38 , "Item Gate" },
        };

        public static String getLinkById(byte id)
        {
            if (linkById.ContainsKey(id)) return linkById[id];
            return "";
        }
        public static Dictionary<byte, string> linkById = new Dictionary<byte, string>()
        {
            { 0 , "None" },
            { 1 , "Both" },
            { 2 , "Out" },
            { 3 , "In" },
        };
    }
}
