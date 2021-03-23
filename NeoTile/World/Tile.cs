
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Camera;

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

        public void Render(SpriteBatch spriteBatch, Camera.Camera camera)
        {
            spriteBatch.Draw(
                Texture,
                new Vector2(Position.X * Size.Width * camera.Zoom.Scale - camera.Position.X, Position.Y * Size.Height * camera.Zoom.Scale - camera.Position.Y),
                SourceRectangle,
                BgColor,
                0f, 
                Vector2.Zero,
                camera.Zoom.Scale,
                SpriteEffects.None,
                0f
            );
        }


    }
}
