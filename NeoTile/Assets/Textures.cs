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
        private static Lazy<Textures> Lazy = new Lazy<Textures>(() => new Textures());

        public static Textures Instance { get { return Lazy.Value; } }

        private Dictionary<string, Texture2D> myTextures = new Dictionary<string, Texture2D>();

        public void AddTexture(string textureName, string fileRoute, ContentManager content)
        {
            myTextures.Add(textureName, content.Load<Texture2D>(fileRoute));
        }

        public Texture2D GetTexture(string textureName)
        {
            return myTextures[textureName];
        }

        public void RemoveTexture(string textureName)
        {
            myTextures.Remove(textureName);
        }
    }
}
