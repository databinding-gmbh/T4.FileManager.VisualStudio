using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4.FileManager.NetCore.AcceptanceCriteria.Features.Helper
{
    public static class FileEncodingHelper
    {
        private static Dictionary<string, Encoding> encodingDictionary = new Dictionary<string, Encoding>
        {
            { "ascii", Encoding.ASCII },
            { "utf-8", Encoding.UTF8 },
            { "utf-16", Encoding.Unicode },
            { "unicode", Encoding.Unicode },
            { "utf-16be", Encoding.BigEndianUnicode }
        };

        public static Encoding ConvertStringToEncoding(string encodeText)
        {
            var key = encodeText.ToLower();

            if (encodingDictionary.ContainsKey(key))
            {
                return encodingDictionary[key];
            }

            throw new ArgumentException("Encoding not found in dictionary");
        }

        public static Encoding GetEncoding(string path)
        {
            using StreamReader sr = new StreamReader(path, true);
            sr.Peek();
            return sr.CurrentEncoding;
        }
    }
}