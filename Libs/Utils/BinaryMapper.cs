using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace KH_Editor.Libs.Utils
{
    // Wrapper for Xeeynamo's BinaryMapping
    class BinaryMapper
    {
        public static T toObject<T>(List<byte> byteList) where T : class
        {
            return BinaryMapping.ReadObject<T>(new MemoryStream(byteList.ToArray()));
        }
        public static List<byte> toBytes<T>(T item) where T : class
        {
            MemoryStream memStream = new MemoryStream();
            BinaryMapping.WriteObject(memStream, item);
            return memStream.ToArray().ToList();
        }
    }
}
