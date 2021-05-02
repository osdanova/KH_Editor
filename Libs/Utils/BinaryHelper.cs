using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KH_Editor.Libs.Utils
{
    class BinaryHelper
    {
        // BINARY TO DATA
        public static String bytesAsHexString(List<byte> input) { return BitConverter.ToString(input.ToArray()).Replace("-", ""); }
        public static String bytesAsString(List<byte> input) { return System.Text.Encoding.UTF8.GetString(input.ToArray()); }
        // 8 bytes
        public static ulong bytesAsULong(List<byte> input) { return BitConverter.ToUInt64(input.ToArray(), 0); }
        public static long bytesAsLong(List<byte> input) { return BitConverter.ToInt64(input.ToArray(), 0); }
        // 4 bytes
        public static uint bytesAsUInt(List<byte> input) { return BitConverter.ToUInt32(input.ToArray(), 0); }
        public static int bytesAsInt(List<byte> input) { return BitConverter.ToInt32(input.ToArray(), 0); }
        // 2 bytes
        public static ushort bytesAsUShort(List<byte> input) { return BitConverter.ToUInt16(input.ToArray(), 0); }
        public static short bytesAsShort(List<byte> input) { return BitConverter.ToInt16(input.ToArray(), 0); }
        // 1 byte
        public static byte bytesAsByte(List<byte> input) { return input[0]; }
        public static sbyte bytesAsSByte(List<byte> input) { return (sbyte)input[0]; }
        // Float (4 bytes)
        public static float bytesAsFloat(List<byte> input) { return BitConverter.ToSingle(input.ToArray(), 0); }

        // DATA TO BINARY
        public static List<byte> hexStringAsBytes(String input)
        {
            byte[] bytes = new byte[input.Length / 2];
            for (int i = 0; i < input.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(input.Substring(i, 2), 16);
            return bytes.ToList();
        }
        public static List<byte> stringAsBytes(String text) { return System.Text.Encoding.UTF8.GetBytes(text).ToList(); }
        public static List<byte> stringAs32Bytes(String text) { return System.Text.Encoding.UTF8.GetBytes(FormatHelper.formatStringToLength(text, 32)).ToList(); }
        // 8 bytes
        public static List<byte> ulongAsBytes(ulong input) { return BitConverter.GetBytes(input).ToList(); }
        public static List<byte> longAsBytes(long input) { return BitConverter.GetBytes(input).ToList(); }
        // 4 bytes
        public static List<byte> uintAsBytes(uint input) { return BitConverter.GetBytes(input).ToList(); }
        public static List<byte> intAsBytes(int input) { return BitConverter.GetBytes(input).ToList(); }
        // 2 bytes
        public static List<byte> ushortAsBytes(ushort input) { return BitConverter.GetBytes(input).ToList(); }
        public static List<byte> shortAsBytes(short input) { return BitConverter.GetBytes(input).ToList(); }
        // 1 byte
        public static List<byte> byteAsBytes(byte input) { return new List<byte> { input }; }
        public static List<byte> sbyteAsBytes(sbyte input) { return BitConverter.GetBytes(input).ToList(); }
        // Float (4 bytes)
        public static List<byte> floatAsBytes(float input) { return BitConverter.GetBytes(input).ToList(); }

        // X bytes
        public static List<byte> uintAsBytesOfSize(uint input, int size)
        {
            List<byte> result = BitConverter.GetBytes(input).ToList();
            padByteListToSize(result, size);
            return result;
        }
        public static List<byte> intAsBytesOfSize(int input, int size)
        {
            List<byte> result = BitConverter.GetBytes(input).ToList();
            padByteListToSize(result, size);
            return result;
        }

        public static void padByteListToSize(List<byte> input, int size)
        {
            for (int i = 0; i < size - input.Count; i++)
            {
                input.Insert(0, 0);
            }
        }

        public static byte setBitFromFlagTo(Byte flag, int pos, bool one)
        {
            byte[] bytes = new byte[1];
            bytes[0] = flag;
            BitArray ba = new BitArray(bytes);
            ba.Set(pos, one);
            //Convert back to byte.
            ba.CopyTo(bytes, 0);
            return bytes[0];
        }
    }
}
