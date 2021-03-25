using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Assets;

namespace NeoTile.World
{
    public class GameObject : IRenderizable
    {
        public Texture2D Texture { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public Vector2 Position { get; set; }

        public Size Size { get; set; }

        public Color BgColor { get; set; } = Color.White;

        public void Render(SpriteBatch spriteBatch, Camera.Camera camera)
        {
            spriteBatch.Draw(
                Texture,
                new Vector2(Position.X * TileOption.Size.Width * camera.Zoom.Scale - camera.Position.X, Position.Y * TileOption.Size.Height * camera.Zoom.Scale - camera.Position.Y),
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
