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
        private static Dictionary<string, SpriteFont> myFonts = new Dictionary<string, SpriteFont>();

        public static void AddFont(string fontName, string fileRoute, ContentManager content)
        {
            myFonts.Add(fontName, content.Load<SpriteFont>(fileRoute));
        }

        public static SpriteFont GetFont(string fontName)
        {
            return myFonts[fontName];
        }

        public static void RemoveFont(string fontName)
        {
            myFonts.Remove(fontName);
        }
    }
}
