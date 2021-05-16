using System;
using System.Collections.Generic;
using KH_Editor.Enums.DDD;

namespace KH_Editor.Dictionaries.KH_DDD
{
    class DDD_Items
    {
        // CATEGORY NAMES

        public static String getCategoryNameById(byte id)
        {
            if (categoryNameById.ContainsKey(id)) return categoryNameById[id];
            return "";
        }
        public static Dictionary<byte, string> categoryNameById = new Dictionary<byte, string>()
        {
            { (int)DDD_ItemCategories.COMMAND , "Command" },
            { (int)DDD_ItemCategories.KEYBLADE , "Keyblade" },
            { (int)DDD_ItemCategories.RECIPE , "Recipe" },
            { (int)DDD_ItemCategories.KEY_ITEM , "Key Item" },
            { (int)DDD_ItemCategories.GLOSSARY , "Glossary" },
            { (int)DDD_ItemCategories.DREAM_PIECE , "Dream Piece" },
            { (int)DDD_ItemCategories.TREAT , "Treat" },
            { (int)DDD_ItemCategories.TRAINING_TOY , "Training Toy" },
            { (int)DDD_ItemCategories.MEMENTO , "Memento" },
            { (int)DDD_ItemCategories.UNKNOWN , "UNKNOWN" },
        };

        // ITEM NAMES

        public static String getItemNameById(byte id, byte category)
        {
            switch (category)
            {
                case (int)DDD_ItemCategories.KEYBLADE:
                    return getKeybladeById(id);
                case (int)DDD_ItemCategories.RECIPE:
                    return getRecipeById(id);
                case (int)DDD_ItemCategories.KEY_ITEM:
                    return getKeyItemById(id);
                case (int)DDD_ItemCategories.GLOSSARY:
                    return getGlossaryById(id);
                case (int)DDD_ItemCategories.DREAM_PIECE:
                    return getDreamPieceById(id);
                case (int)DDD_ItemCategories.TREAT:
                    return getTreatById(id);
                case (int)DDD_ItemCategories.TRAINING_TOY:
                    return getTrainingToyById(id);
                default:
                    return ""; 
            }
        }

        // KEYBLADES

        public static String getKeybladeById(byte id)
        {
            if (keybladeById.ContainsKey(id)) return keybladeById[id];
            return "";
        }
        public static Dictionary<byte, string> keybladeById = new Dictionary<byte, string>()
        {
            { 0 , "Kingdom Key" },
            { 1 , "Skull Noise (S)" },
            { 2 , "Guardian Bell (S)" },
            { 3 , "Ferris Gear" },
            { 4 , "Dual Disc (S)" },
            { 5 , "All for One (S)" },
            { 6 , "Counterpoint (S)" },
            { 7 , "Sweet Dreams (S)" },
            { 8 , "Ultima Weapon (S)" },
            { 9 , "Unbound (S)" },
            { 10,  "Divewing (S)" },
            { 11,  "End of Pain (S)" },
            { 12,  "Knockout Punch (S)" },
            { 13,  "? (S)" },
            { 14,  "? (S)" },
            { 15,  "NO DATA (S)" },
            { 16,  "Soul Eater" },
            { 17,  "Skull Noise (R)" },
            { 18,  "Guardian Bell (R)" },
            { 19,  "Ocean's Rage" },
            { 20,  "Dual Disc (R)" },
            { 21,  "All for One (R)" },
            { 22,  "Counterpoint (R)" },
            { 23,  "Sweet Dreams (R)" },
            { 24,  "Ultima Weapon (R)" },
            { 25,  "Unbound (R)" },
            { 26,  "Divewing (R)" },
            { 27,  "End of Pain (R)" },
            { 28,  "Knockout Punch (R)" },
            { 29,  "NO DATA (R)" },
            { 30,  "Super Jump (R)" },
            { 31,  "Way to the Dawn" },
        };

        // RECIPES

        public static String getRecipeById(byte id)
        {
            if (recipeById.ContainsKey(id)) return recipeById[id];
            return "";
        }
        public static Dictionary<byte, string> recipeById = new Dictionary<byte, string>()
        {
            { 0 , "Meow Wow Recipe" },
            { 1 , "Tama Sheep Recipe" },
            { 2 , "Yoggy Ram Recipe" },
            { 3 , "Komory Bat Recipe" },
            { 4 , "Pricklemane Recipe" },
            { 5 , "Hebby Repp Recipe" },
            { 6 , "Sir Kyroo Recipe" },
            { 7 , "Toximander Recipe" },
            { 8 , "Fin Fatale Recipe" },
            { 9 , "Tatsu Steed Recipe" },
            { 10 , "Necho Cat Recipe" },
            { 11 , "Thunderaffe Recipe" },
            { 12 , "Kooma Panda Recipe" },
            { 13 , "Pegaslick Recipe" },
            { 14 , "Iceguin Ace Recipe" },
            { 15 , "Peepsta Hoo Recipe" },
            { 16 , "Escarglow Recipe" },
            { 17 , "KO Kabuto Recipe" },
            { 18 , "Wheeflower Recipe" },
            { 19 , "Ghostabocky Recipe" },
            { 20 , "Zolephant Recipe" },
            { 21 , "Juggle Pup Recipe" },
            { 22 , "Halbird Recipe" },
            { 23 , "Staggerceps Recipe" },
            { 24 , "Fishboné Recipe" },
            { 25 , "Flowbermeow Recipe" },
            { 26 , "Cyber Yog Recipe" },
            { 27 , "Chef Kyroo Recipe" },
            { 28 , "Lord Kyroo Recipe" },
            { 29 , "Tatsu Blaze Recipe" },
            { 30 , "Electricorn Recipe" },
            { 31 , "Woeflower Recipe" },
            { 32 , "Jestabocky Recipe" },
            { 33 , "Eaglider Recipe" },
            { 34 , "Me Me Bunny Recipe" },
            { 35 , "Drill Sye Recipe" },
            { 36 , "Tyranto Rex Recipe" },
            { 37 , "Majik Lapin Recipe" },
            { 38 , "Cera Terror Recipe" },
            { 39 , "Skelterwild Recipe" },
            { 40 , "Ducky Goose Recipe" },
            { 41 , "Aura Lion Recipe" },
            { 42 , "Ryu Dragon Recipe" },
            { 43 , "Drak Quack Recipe" },
            { 44 , "Keeba Tiger Recipe" },
            { 45 , "Meowjesty Recipe" },
            { 46 , "Sudo Neku Recipe" },
            { 47 , "Frootz Cat Recipe" },
            { 48 , "Ursa Circus Recipe" },
            { 49 , "Kab Kannon Recipe" },
            { 50 , "R & R Seal Recipe" },
            { 51 , "Catanuki Recipe" },
            { 52 , "Beatalike Recipe" },
            { 53 , "Tubguin Ace Recipe" },
            { 54 , "RECIPE 55" },
            { 55 , "RECIPE 56" },
            { 56 , "RECIPE 57" },
            { 57 , "RECIPE 58" },
            { 58 , "RECIPE 59" },
            { 59 , "RECIPE 60" },
        };

        // KEY ITEMS

        public static String getKeyItemById(byte id)
        {
            if (keyItemById.ContainsKey(id)) return keyItemById[id];
            return "";
        }
        public static Dictionary<byte, string> keyItemById = new Dictionary<byte, string>()
        {
            { 0 , "Stage Gadget" },
            { 1 , "KEY ITEM 2" },
            { 2 , "KEY ITEM 3" },
            { 3 , "KEY ITEM 4" },
            { 4 , "KEY ITEM 5" },
            { 5 , "KEY ITEM 6" },
            { 6 , "KEY ITEM 7" },
            { 7 , "KEY ITEM 8" },
            { 8 , "KEY ITEM 9" },
            { 9 , "KEY ITEM 10" },
            { 10 , "KEY ITEM 11" },
            { 11 , "KEY ITEM 12" },
            { 12 , "KEY ITEM 13" },
            { 13 , "KEY ITEM 14" },
            { 14 , "KEY ITEM 15" },
            { 15 , "KEY ITEM 16" },
            { 16 , "KEY ITEM 17" },
            { 17 , "KEY ITEM 18" },
            { 18 , "KEY ITEM 19" },
            { 19 , "KEY ITEM 20" },
            { 20 , "KEY ITEM 21" },
            { 21 , "KEY ITEM 22" },
            { 22 , "KEY ITEM 23" },
            { 23 , "KEY ITEM 24" },
            { 24 , "KEY ITEM 25" },
            { 25 , "KEY ITEM 26" },
            { 26 , "KEY ITEM 27" },
            { 27 , "KEY ITEM 28" },
            { 28 , "KEY ITEM 29" },
            { 29 , "KEY ITEM 30" },
            { 30 , "KEY ITEM 31" },
            { 31 , "KEY ITEM 32" },
            { 32 , "KEY ITEM 33" },
            { 33 , "KEY ITEM 34" },
            { 34 , "KEY ITEM 35" },
            { 35 , "KEY ITEM 36" },
            { 36 , "KEY ITEM 37" },
            { 37 , "KEY ITEM 38" },
            { 38 , "KEY ITEM 39" },
            { 39 , "KEY ITEM 40" },
        };

        // GLOSSARY

        public static String getGlossaryById(byte id)
        {
            if (glossaryById.ContainsKey(id)) return glossaryById[id];
            return "";
        }
        public static Dictionary<byte, string> glossaryById = new Dictionary<byte, string>()
        {
            { 0 , "Keyblades" },
            { 1 , "Keyblade Masters" },
            { 2 , "Master Xehanort" },
            { 3 , "The Keyblade War" },
            { 4 , "Heartless" },
            { 5 , "Kingdom Hearts" },
            { 6 , "Nobodies" },
            { 7 , "Organization" },
            { 8 , "Seven Princesses" },
            { 9 , "Recusant's Sigil" },
            { 10 , "X-Blade" },
            { 11 , "Hearts Tied to Sora" },
            { 12 , "Secret Message" },
            { 13 , "GLOSSARY 14" },
            { 14 , "GLOSSARY 15" },
            { 15 , "GLOSSARY 16" },
            { 16 , "GLOSSARY 17" },
            { 17 , "GLOSSARY 18" },
            { 18 , "GLOSSARY 19" },
            { 19 , "GLOSSARY 20" },
        };

        // DREAM PIECES

        public static String getDreamPieceById(byte id)
        {
            if (dreamPieceById.ContainsKey(id)) return dreamPieceById[id];
            return "";
        }
        public static Dictionary<byte, string> dreamPieceById = new Dictionary<byte, string>()
        {
            { 0 , "Fleeting Figment" },
            { 1 , "Fleeting Fancy" },
            { 2 , "Fleeting Fantasy" },
            { 3 , "Lofty Figment" },
            { 4 , "Lofty Fancy" },
            { 5 , "Lofty Fantasy" },
            { 6 , "Rampant Figment" },
            { 7 , "Rampant Fancy" },
            { 8 , "Rampant Fantasy" },
            { 9 , "Dulcet Figment" },
            { 10 , "Dulcet Fancy" },
            { 11 , "Dulcet Fantasy" },
            { 12 , "Malleable Fantasy" },
            { 13 , "Prickly Fantasy" },
            { 14 , "Wild Fantasy" },
            { 15 , "Epic Fantasy" },
            { 16 , "Charming Fantasy" },
            { 17 , "Brilliant Fantasy" },
            { 18 , "Intrepid Figment" },
            { 19 , "Intrepid Fancy" },
            { 20 , "Intrepid Fantasy" },
            { 21 , "Savage Fantasy" },
            { 22 , "Noble Figment" },
            { 23 , "Noble Fancy" },
            { 24 , "Noble Fantasy" },
            { 25 , "Grim Figment" },
            { 26 , "Grim Fancy" },
            { 27 , "Grim Fantasy" },
            { 28 , "Vibrant Figment" },
            { 29 , "Vibrant Fancy" },
            { 30 , "Vibrant Fantasy" },
            { 31 , "Troubling Figment" },
            { 32 , "Troubling Fancy" },
            { 33 , "Troubling Fantasy" },
            { 34 , "Wondrous Figment" },
            { 35 , "Wondrous Fancy" },
            { 36 , "Wondrous Fantasy" },
        };

        // TREATS

        public static String getTreatById(byte id)
        {
            if (treatById.ContainsKey(id)) return treatById[id];
            return "";
        }
        public static Dictionary<byte, string> treatById = new Dictionary<byte, string>()
        {
            { 0 , "Confetti Candy" },
            { 1 , "Shield Cookie" },
            { 2 , "Block-It Chocolate" },
            { 3 , "Ice Dream Cone" },
            { 4 , "Royal Cake" },
            { 5 , "Confetti Candy 2" },
            { 6 , "Shield Cookie 2" },
            { 7 , "Block-It Chocolate 2" },
            { 8 , "Ice Dream Cone 2" },
            { 9 , "UNUSED" },
            { 10 , "Confetti Candy 3" },
            { 11 , "Shield Cookie 3" },
            { 12 , "Block-It Chocolate 3" },
            { 13 , "Ice Dream Cone 3" },
            { 14 , "UNUSED" },
            { 15 , "FOOD ITEM 16" },
            { 16 , "FOOD ITEM 17" },
            { 17 , "FOOD ITEM 18" },
            { 18 , "FOOD ITEM 19" },
            { 19 , "FOOD ITEM 20" },
        };

        // TRAINING TOYS

        public static String getTrainingToyById(byte id)
        {
            if (trainingToyById.ContainsKey(id)) return trainingToyById[id];
            return "";
        }
        public static Dictionary<byte, string> trainingToyById = new Dictionary<byte, string>()
        {
            { 0 , "Balloon" },
            { 1 , "UNUSED" },
            { 2 , "UNUSED" },
            { 3 , "Candy Goggles" },
            { 4 , "Water Barrel" },
            { 5 , "Paint Gun: Red" },
            { 6 , "Paint Gun: Blue" },
            { 7 , "Paint Gun: Green" },
            { 8 , "Paint Gun: Yellow" },
            { 9 , "Paint Gun: White" },
            { 10 , "Paint Gun: Black" },
            { 11 , "Paint Gun: Purple" },
            { 12 , "Paint Gun: Sky Blue" },
            { 13 , "TOY 14" },
            { 14 , "TOY 15" },
            { 15 , "TOY 16" },
            { 16 , "TOY 17" },
            { 17 , "TOY 18" },
            { 18 , "TOY 19" },
            { 19 , "TOY 20" },
        };
    }
}
