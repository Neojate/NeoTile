
using Microsoft.Xna.Framework;
using System;

namespace NeoTile.Globals
{
    public class Needs
    {
        private static Lazy<Needs> Lazy = new Lazy<Needs>(() => new Needs());

        public static Needs Instance { get { return Lazy.Value; } }

        public Vector2 Resolution { get; set; }
    }
}
