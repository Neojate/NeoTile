
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace NeoTile.Assets
{
    public class Textures : Asset
    {
        private static readonly Lazy<Textures> Lazy = new Lazy<Textures>(() => new Textures());

        public static Textures Instance { get { return Lazy.Value; } }

        private Dictionary<string, Texture2D> myTextures = new Dictionary<string, Texture2D>();

        public void AddTexture(string textureName, string fileRoute)
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
