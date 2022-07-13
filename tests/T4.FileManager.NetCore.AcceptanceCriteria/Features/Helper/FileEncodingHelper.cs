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
        public static Encoding ConvertStringToEncoding(string encodeText)
        {
            var dict = new Dictionary<string, Encoding>();
            dict.Add("ascii", Encoding.ASCII);
            dict.Add("utf-8", Encoding.UTF8);
            dict.Add("utf-16", Encoding.Unicode);
            dict.Add("unicode", Encoding.Unicode);

            var key = encodeText.ToLower();

            if (dict.ContainsKey(key))
            {
                return dict[key];
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
