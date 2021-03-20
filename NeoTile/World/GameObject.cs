using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeoTile.World
{
    public class GameObject : IRenderizable
    {
        public Texture2D Texture { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public Point Position { get; set; }

        public Size Size { get; set; }

        public Color BgColor { get; set; } = Color.White;

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle(Position.X, Position.Y, Size.Width, Size.Height), SourceRectangle, BgColor);
        }
    }
}
