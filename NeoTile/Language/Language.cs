using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoTile.Language
{
    public class Language
    {
        private static readonly Lazy<Language> Lazy = new Lazy<Language>(() => new Language());

        public Language Instance { get { return Lazy.Value; } }

        private Dictionary<string, string> dictionary = new Dictionary<string, string>();

        

        public void LoadJson(string route)
        {

        }
    }
}
