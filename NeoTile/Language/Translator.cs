
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            try { return dictionary[code]; }
            catch { return code; }
        }

        public string Translate(string code, Dictionary<string, string> variables)
        {
            try
            {
                List<string> splittedText = dictionary[code].Split(' ').ToList();

                string result = "";

                splittedText.ForEach(split =>
                {
                    if (split[0] == ':')
                        split = Translate(variables[split.Remove(0, 1)]);
                    
                    result += split + " ";
                });

                return result;
            }
            catch { return code; }
        }
    }
}
