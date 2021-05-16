using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KH_Editor.Libs.Utils
{
    class FormatHelper
    {
        // Formats strings to 32 characters, cropping to 32 chars and filling with \0s if lacking length
        // Eg: For 32 character names
        public static string formatStringToLength(string text, int length)
        {
            if (text.Length > length) text = text.Substring(0, length);
            if (text.Length < length)
            {
                for (int i = text.Length; i < length; i++)
                {
                    text += "\0";
                }
            }
            return text;
        }

        // Returns a byte list of 0s of the given size
        // Eg: To inilialize objects
        public static List<byte> getByteListOfSize(int size)
        {
            Byte[] array = new Byte[size];
            Array.Clear(array, 0, array.Length);
            return array.ToList();
        }

        // Splices the text in lines of the given length
        // Eg: To display data in the console
        public static string SpliceText(string text, int lineLength)
        {
            return Regex.Replace(text, "(.{" + lineLength + "})", "$1" + Environment.NewLine);
        }

        // Returns a string containing legnth amount of CD.
        // Eg: 4: CDCDCDCD
        public static string cdEof(int length)
        {
            string eofString = "";
            for (int i = 0; i < length; i++) eofString += "CD";
            return eofString;
        }
    }
}
