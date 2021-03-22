
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeoTile.World
{
    public class Tile
    {
        //TODO: hacer un factory de tiles.

        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; } = Rectangle.Empty;
        public Color BgColor { get; set; } = Color.White;
        public Point Position { get; set; }

        public Size Size { get; set; } = TileOption.Size;

        public float Friction { get; set; } = TileOption.Friction;

        public bool IsBlock { get; set; } = false;

        public Tile()
        {

        }

        public Tile(Point position)
        {
            Position = position;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Texture,
                new Rectangle(Position.X * Size.Width, Position.Y * Size.Height, Size.Width, Size.Height),
                SourceRectangle,
                BgColor
            );
        }


    }
}
