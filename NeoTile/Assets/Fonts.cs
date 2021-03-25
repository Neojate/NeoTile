using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoTile.Assets
{
    public class Fonts
    {
        private static Lazy<Fonts> Lazy = new Lazy<Fonts>(() => new Fonts());

        public static Fonts Instace { get { return Lazy.Value; } }

        private Dictionary<string, SpriteFont> myFonts = new Dictionary<string, SpriteFont>();

        public void AddFont(string fontName, string fileRoute, ContentManager content)
        {
            myFonts.Add(fontName, content.Load<SpriteFont>(fileRoute));
        }

        public SpriteFont GetFont(string fontName)
        {
            return myFonts[fontName];
        }

        public void RemoveFont(string fontName)
        {
            myFonts.Remove(fontName);
        }
    }
}
