using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeoTile.Types
{
    public struct Picture
    {
        public Vector2 Position { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public Texture2D Texture { get; set; }

        public Picture(Vector2 position, Rectangle sourceRectangle, Texture2D texture)
        {
            Position = position;
            SourceRectangle = sourceRectangle;
            Texture = texture;
        }

    }
}