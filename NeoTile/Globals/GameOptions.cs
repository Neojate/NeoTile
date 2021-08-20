
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace NeoTile.Globals
{
    public class GameOptions
    {
        private static readonly Lazy<GameOptions> Lazy = new Lazy<GameOptions>(() => new GameOptions());

        public static GameOptions Instance { get { return Lazy.Value; } }

        public Vector2 Resolution { get; set; }

        public GraphicsDevice GraphicsDevice { get; set; }
    }
}
