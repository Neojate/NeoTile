using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeoTile.Components
{
    public struct Style
    {
        public Texture2D Texture { get; set; }

        public Color BgColor { get; set; }

        public Color HoverBgColor { get; set; }

        public SpriteFont Font { get; set; }

        public Color FontColor { get; set; }

        public Color HoverFontColor { get; set; }

        public Vector2 Padding { get; set; }
    }
}
