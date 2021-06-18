
using Microsoft.Xna.Framework;
using System;

namespace NeoTile.Globals
{
    public class GameOptions
    {
        private static readonly Lazy<GameOptions> Lazy = new Lazy<GameOptions>(() => new GameOptions());

        public static GameOptions Instance { get { return Lazy.Value; } }

        //Medidas de la Resolucion
        public Vector2 Resolution { get; set; }

        //Medidas del Tile
        public Vector2 TileSize { get; set; }
    }
}
