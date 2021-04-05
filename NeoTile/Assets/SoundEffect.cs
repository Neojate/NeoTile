
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace NeoTile.Assets
{
    public sealed class Sounds : Asset
    {
        private static readonly Lazy<Sounds> Lazy = new Lazy<Sounds>(() => new Sounds());

        public static Sounds Instance { get { return Lazy.Value; } }

        private Dictionary<string, SoundEffect> data = new Dictionary<string, SoundEffect>();

        public void AddSound(string soundName, string routeFile)
        {
            data.Add(soundName, content.Load<SoundEffect>(routeFile));
        }

        public SoundEffect GetSound(string soundName)
        {
            return data[soundName];
        }

        public void RemoveSound(string soundName)
        {
            data.Remove(soundName);
        }
    }
}
