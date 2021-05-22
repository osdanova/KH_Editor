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

        public static String getSpiritById(int id)
        {
            if (spiritById.ContainsKey(id)) return spiritById[id];
            return "";
        }
        public static Dictionary<int, string> spiritById = new Dictionary<int, string>()
        {
            { 0 , "BASE" },
            { 1 , "Meow Wow" },
            { 2 , "Tama Sheep" },
            { 3 , "Yoggy Ram" },
            { 4 , "Komory Bat" },
            { 5 , "Pricklemane" },
            { 6 , "Hebby Repp" },
            { 7 , "Sir Kyroo" },
            { 8 , "Toximander" },
            { 9 , "Fin Fatale" },
            { 10 , "Tatsu Seed" },
            { 11 , "Necho Cat" },
            { 12 , "Thunderaffe" },
            { 13 , "Kooma Panda" },
            { 14 , "Pegaslick" },
            { 15 , "Iceguin Ace" },
            { 16 , "Peepsta Hoo" },
            { 17 , "Escarglow" },
            { 18 , "KO Kabuto" },
            { 19 , "Wheeflower" },
            { 20 , "Ghostabocky" },
            { 21 , "Zolephant" },
            { 22 , "Juggle Pup" },
            { 23 , "Halbird" },
            { 24 , "Staggerceps" },
            { 25 , "Fishboné" },
            { 26 , "Flowbermeow" },
            { 27 , "Cyber Yog" },
            { 28 , "Chef Kyroo" },
            { 29 , "Lord Kyroo" },
            { 30 , "Tatsu Blaze" },
            { 31 , "Electricorn" },
            { 32 , "Woeflower" },
            { 33 , "Jestabocky" },
            { 34 , "Eaglider" },
            { 35 , "Me Me Bunny" },
            { 36 , "Drill Sye" },
            { 37 , "Tyranto Rex" },
            { 38 , "Majik Lapin" },
            { 39 , "Cera Terror" },
            { 40 , "Skelterwild" },
            { 41 , "Ducky Goose" },
            { 42 , "Aura Lion" },
            { 43 , "Ryu Dragon" },
            { 44 , "Drak Quack" },
            { 45 , "Keeba Tiger" },
            { 46 , "Meowjesty" },
            { 47 , "Sudo Neku" },
            { 48 , "Frootz Cat" },
            { 49 , "Ursa Circus" },
            { 50 , "Kab Kannon" },
            { 51 , "R & R Seal" },
            { 52 , "Catanuki" },
            { 53 , "Beatalike" },
            { 54 , "Tubguin Ace" },
        };
    }
}
