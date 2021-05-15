using KH_Editor.Dictionaries.KH_DDD;
using KH_Editor.Libs.Utils;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_inventory
{
    class DDD_inventory_Command
    {
        [Data] public byte Id { get; set; }
        [Data] public byte Pad1 { get; set; }
        [Data] public byte DecksSora { get; set; }
        [Data] public byte DecksRiku { get; set; }
        [Data] public byte Pad2 { get; set; }
        [Data] public byte Amount { get; set; }
        [Data] public short Pad3 { get; set; }

        public string name { get { return DDD_Commands.getCommandById(Id); } }

        public bool soraDeck1 { get { return BinaryHelper.getBitFromFlag(DecksSora, 0); } set { DecksSora = BinaryHelper.setBitFromFlagTo(DecksSora, 0, value); } }
        public bool soraDeck2 { get { return BinaryHelper.getBitFromFlag(DecksSora, 1); } set { DecksSora = BinaryHelper.setBitFromFlagTo(DecksSora, 1, value); } }
        public bool soraDeck3 { get { return BinaryHelper.getBitFromFlag(DecksSora, 2); } set { DecksSora = BinaryHelper.setBitFromFlagTo(DecksSora, 2, value); } }

        public bool rikuDeck1 { get { return BinaryHelper.getBitFromFlag(DecksRiku, 0); } set { DecksRiku = BinaryHelper.setBitFromFlagTo(DecksRiku, 0, value); } }
        public bool rikuDeck2 { get { return BinaryHelper.getBitFromFlag(DecksRiku, 1); } set { DecksRiku = BinaryHelper.setBitFromFlagTo(DecksRiku, 1, value); } }
        public bool rikuDeck3 { get { return BinaryHelper.getBitFromFlag(DecksRiku, 2); } set { DecksRiku = BinaryHelper.setBitFromFlagTo(DecksRiku, 2, value); } }
    }
}
