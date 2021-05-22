using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // Returns a string containing N times the given string.
        // Eg: "CD", 4: CDCDCDCD
        public static string repeatString(String str, int times)
        {
            string repeatStr = "";
            for (int i = 0; i < times; i++) repeatStr += str;
            return repeatStr;
        }

        // Returns the given string as a list of bytes with a "." after each letter. (As viewed in Cheat Engine/HxD)
        // Eg: "Meow, 5": "M.e.o.w."
        public static List<byte> textFormatDottedBytes(string text)
        {
            List<byte> byteText = Encoding.Default.GetBytes(text).ToList();
            List<byte> byteResult = new List<byte>();
            for(int i = 0; i < byteText.Count; i++)
            {
                byteResult.Add(byteText[i]);
                byteResult.Add(0);
            }
            return byteResult;
        }
    }
}
