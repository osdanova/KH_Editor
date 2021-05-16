using System;
using System.Collections.Generic;
using KH_Editor.Enums.DDD;

namespace KH_Editor.Dictionaries.KH_DDD
{
    class DDD_Areas
    {
        // WORLDS

        public static String getWorldNameById(byte id)
        {
            if (worldNameById.ContainsKey(id)) return worldNameById[id];
            return "";
        }
        public static Dictionary<byte, string> worldNameById = new Dictionary<byte, string>()
        {
            { (int)DDD_WorldAreas.EX , "EX" },
            { (int)DDD_WorldAreas.DESTINY_ISLANDS , "Destiny Islands" },
            { (int)DDD_WorldAreas.MYSTERIOUS_TOWER , "Mysterious Tower" },
            { (int)DDD_WorldAreas.TRAVERSE_TOWN , "Traverse Town" },
            { (int)DDD_WorldAreas.COUNTRY_MUSKETEERS , "The Country of Musketeers" },
            { (int)DDD_WorldAreas.SYMPHONY_SORCERY , "Symphony of Sorcery" },
            { (int)DDD_WorldAreas.PRANKSTERS_PARADISE , "Prankster's Paradise" },
            { (int)DDD_WorldAreas.RADIANT_GARDEN , "Radiant Garden" },
            { (int)DDD_WorldAreas.CITE_DES_CLOCHES , "Cité des Cloches" },
            { (int)DDD_WorldAreas.THE_GRID , "The Grid" },
            { (int)DDD_WorldAreas.TWTNW , "TWTNW" },
            { (int)DDD_WorldAreas.WORLD_MAP , "World Map" },
            { (int)DDD_WorldAreas.DREAM_EATER , "Dream Eater area" },
            { (int)DDD_WorldAreas.ZZ , "ZZ" },
            { (int)DDD_WorldAreas.TRAVERSE_TOWN_2 , "Traverse Town 2" },
            { (int)DDD_WorldAreas.ENDING , "Ending" },
        };

        // AREAS
    }
}
