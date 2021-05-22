using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KH_Editor.Dictionaries.KH_DDD;
using Xe.BinaryMapper;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_spirit
{
    [Serializable]
    class DDD_spirit_Entry
    {
        // 256 bytes
        [Data] public byte spiritType { get; set; }
        [Data] public byte unk1 { get; set; }
        [Data] public byte dispRank { get; set; }
        [Data] public byte level { get; set; }
        [Data] public byte unk4 { get; set; }
        [Data] public byte unk5 { get; set; }
        [Data(Count = 22)] public List<byte> name { get; set; }
        [Data] public short pad1Maybe { get; set; }
        [Data] public byte affiLvlUnk { get; set; }
        [Data] public byte unk32 { get; set; }
        [Data] public byte colorR { get; set; }
        [Data] public byte colorG { get; set; }
        [Data] public byte colorB { get; set; }
        [Data] public byte colorPad { get; set; }
        [Data] public int exp { get; set; }
        [Data] public int affinity { get; set; }
        [Data] public short lp { get; set; }
        [Data] public short unk47 { get; set; }
        [Data] public short maxHp { get; set; }
        [Data] public byte unk51 { get; set; }
        [Data(Count = 10)] public List<byte> unk52 { get; set; }
        [Data] public byte attack { get; set; }
        [Data] public byte magic { get; set; }
        [Data] public byte defense { get; set; } //72
        [Data] public byte ele_physical { get; set; }
        [Data] public byte ele_fire { get; set; }
        [Data] public byte ele_blizzard { get; set; }
        [Data] public byte ele_thunder { get; set; }
        [Data] public byte ele_water { get; set; }
        [Data] public byte ele_dark { get; set; }
        [Data] public byte ele_light { get; set; }
        [Data(Count = 3)] public List<byte> unk72 { get; set; }
        [Data] public byte timesLinked { get; set; }
        [Data(Count = 3)] public List<byte> unk74 { get; set; }
        [Data] public int battleData { get; set; } //90
        [Data] public short unkShort83 { get; set; }
        [Data] public short unkShort85 { get; set; }
        [Data] public short unkShort87 { get; set; }
        [Data] public short unkShort89 { get; set; }
        [Data] public short unkShort91 { get; set; } //100
        [Data] public byte shine { get; set; }
        [Data] public short petGauge { get; set; }
        [Data(Count = 161)] public List<byte> unkEnd { get; set; }

        public string spiritTypeName { get { return DDD_Spirits.getSpiritById(spiritType); } }

        public string nameDefault { get { return Encoding.Default.GetString(name.ToArray()); } set { name = FormatHelper.textFormatDottedBytes(value); } } 
        public string nameASCII { get { return Encoding.ASCII.GetString(name.ToArray()); } }
        public string nameUTF8 { get { return Encoding.UTF8.GetString(name.ToArray()); } }

        public byte rank
        {
            get { return (byte)(dispRank & 0xF); }
            set { dispRank = (byte)(value | (disposition << 4)); }
        }
        public byte disposition
        {
            get { return (byte)((dispRank >> 4) & 0xF); }
            set { dispRank = (byte)(rank | (value << 4)); }
        }

        public byte affiLvl
        {
            get { return (byte)(affiLvlUnk & 0xF); }
            set { affiLvlUnk = (byte)(value | (affiLvl2 << 4)); }
        }
        public byte affiLvl2
        {
            get { return (byte)((affiLvlUnk >> 4) & 0xF); }
            set { affiLvlUnk = (byte)(affiLvl | (value << 4)); }
        }

        public bool shiny
        {
            get { return shine == 2; }
            set { if (value) shine = 2; else shine = 1; }
        }
    }
}
