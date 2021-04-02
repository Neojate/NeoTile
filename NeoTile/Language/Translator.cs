
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace NeoTile.Language
{
    public class Translator
    {
        private static readonly Lazy<Translator> Lazy = new Lazy<Translator>(() => new Translator());

        public static Translator Instance { get { return Lazy.Value; } }

        private Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public void LoadJson(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
        }

        public string Translate(string code)
        {
            try
            {
                return dictionary[code];
            }
            catch (Exception e)
            {
                return code;
            }
        }
    }
}
