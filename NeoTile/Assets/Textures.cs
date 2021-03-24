using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoTile.Assets
{
    public class Textures
    { 
        private static Dictionary<string, Texture2D> myTextures = new Dictionary<string, Texture2D>();

        public static void AddTexture(string textureName, string fileRoute, ContentManager content)
        {
            myTextures.Add(textureName, content.Load<Texture2D>(fileRoute));
        }

        public static Texture2D GetTexture(string textureName)
        {
            return myTextures[textureName];
        }

        public static void RemoveTexture(string textureName)
        {
            myTextures.Remove(textureName);
        }
    }
}
