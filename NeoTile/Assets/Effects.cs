
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace NeoTile.Assets
{
    public sealed class Effects : Asset
    {
        private static readonly Lazy<Effects> Lazy = new Lazy<Effects>(() => new Effects());

        public static Effects Instance { get { return Lazy.Value; } }

        public Dictionary<string, Effect> data = new Dictionary<string, Effect>();

        public void AddEffect(string effectName, string fileRoute)
        {
            data.Add(effectName, content.Load<Effect>(fileRoute));
        }

        public Effect GetEffect(string effectName)
        {
            return data[effectName];
        }

        public void RemoveEffect(string effectName)
        {
            data.Remove(effectName);
        }
    }
}
