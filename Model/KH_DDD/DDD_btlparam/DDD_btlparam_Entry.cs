using System;
using KH_Editor.Dictionaries.KH_DDD;
using KH_Editor.Libs.Utils;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_btlparam
{
    [Serializable]
    class DDD_btlparam_Entry
    {
        // 72 bytes total
        [Data(Count = 8)] public string entity { get; set; }
        [Data] public short unk8 { get; set; }
        [Data] public short exp { get; set; }
        [Data] public byte unk12 { get; set; }
        [Data] public byte unk13 { get; set; }
        [Data] public byte unk14 { get; set; }
        [Data] public byte unk15 { get; set; }
        [Data] public short ele_physical { get; set; }
        [Data] public short ele_fire { get; set; }
        [Data] public short ele_blizzard { get; set; }
        [Data] public short ele_thunder { get; set; }
        [Data] public short ele_water { get; set; }
        [Data] public short ele_dark { get; set; }
        [Data] public short ele_light { get; set; }
        [Data] public short unk30 { get; set; }
        [Data] public short unk32 { get; set; }
        [Data] public short unk34 { get; set; }
        [Data] public byte unk36 { get; set; }
        [Data] public byte unk37 { get; set; }
        [Data] public byte unk38 { get; set; }
        [Data] public byte unk39 { get; set; }
        [Data] public byte unk40 { get; set; }
        [Data] public byte unk41 { get; set; }
        [Data] public byte unk42 { get; set; }
        [Data] public byte unk43 { get; set; }
        [Data] public short hp { get; set; }
        [Data] public short attack { get; set; }
        [Data] public short magic { get; set; }
        [Data] public short defense { get; set; }
        [Data(Count = 4)] public byte[] unk52 { get; set; }
        [Data(Count = 2)] public byte[] statusFlags { get; set; }
        [Data] public byte unk58 { get; set; }
        [Data(Count = 13)] public byte[] runtimeReserved { get; set; }

        public string name { get { return DDD_Entities.getNameByEntity(entity); } }

        public bool statusFreeze { get { return BinaryHelper.getBitFromFlag(statusFlags[0], 0); } set { statusFlags[0] = BinaryHelper.setBitFromFlagTo(statusFlags[0], 0, value); } }
        public bool statusStop { get { return BinaryHelper.getBitFromFlag(statusFlags[0], 1); } set { statusFlags[0] = BinaryHelper.setBitFromFlagTo(statusFlags[0], 1, value); } }
        public bool statusGravity { get { return BinaryHelper.getBitFromFlag(statusFlags[0], 2); } set { statusFlags[0] = BinaryHelper.setBitFromFlagTo(statusFlags[0], 2, value); } }
        public bool statusMagnet { get { return BinaryHelper.getBitFromFlag(statusFlags[0], 3); } set { statusFlags[0] = BinaryHelper.setBitFromFlagTo(statusFlags[0], 3, value); } }
        public bool statusStun { get { return BinaryHelper.getBitFromFlag(statusFlags[0], 4); } set { statusFlags[0] = BinaryHelper.setBitFromFlagTo(statusFlags[0], 4, value); } }
        public bool statusSleep { get { return BinaryHelper.getBitFromFlag(statusFlags[0], 5); } set { statusFlags[0] = BinaryHelper.setBitFromFlagTo(statusFlags[0], 5, value); } }
        public bool statusBind { get { return BinaryHelper.getBitFromFlag(statusFlags[0], 6); } set { statusFlags[0] = BinaryHelper.setBitFromFlagTo(statusFlags[0], 6, value); } }
        public bool statusSlow { get { return BinaryHelper.getBitFromFlag(statusFlags[0], 7); } set { statusFlags[0] = BinaryHelper.setBitFromFlagTo(statusFlags[0], 7, value); } }

        public bool statusPoison { get { return BinaryHelper.getBitFromFlag(statusFlags[1], 0); } set { statusFlags[1] = BinaryHelper.setBitFromFlagTo(statusFlags[1], 0, value); } }
        public bool statusIgnite { get { return BinaryHelper.getBitFromFlag(statusFlags[1], 1); } set { statusFlags[1] = BinaryHelper.setBitFromFlagTo(statusFlags[1], 1, value); } }
        public bool statusConfusion { get { return BinaryHelper.getBitFromFlag(statusFlags[1], 2); } set { statusFlags[1] = BinaryHelper.setBitFromFlagTo(statusFlags[1], 2, value); } }
        public bool statusBlind { get { return BinaryHelper.getBitFromFlag(statusFlags[1], 3); } set { statusFlags[1] = BinaryHelper.setBitFromFlagTo(statusFlags[1], 3, value); } }
        public bool statusMini { get { return BinaryHelper.getBitFromFlag(statusFlags[1], 4); } set { statusFlags[1] = BinaryHelper.setBitFromFlagTo(statusFlags[1], 4, value); } }
        public bool statusTimeBomb { get { return BinaryHelper.getBitFromFlag(statusFlags[1], 5); } set { statusFlags[1] = BinaryHelper.setBitFromFlagTo(statusFlags[1], 5, value); } }
        public bool statusFlag15 { get { return BinaryHelper.getBitFromFlag(statusFlags[1], 6); } set { statusFlags[1] = BinaryHelper.setBitFromFlagTo(statusFlags[1], 6, value); } }
        public bool statusZantetsuken { get { return BinaryHelper.getBitFromFlag(statusFlags[1], 7); } set { statusFlags[1] = BinaryHelper.setBitFromFlagTo(statusFlags[1], 7, value); } }
    }
}
