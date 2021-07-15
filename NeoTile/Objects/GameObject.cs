using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Types;
using NeoTile.Worlds;
using System.Collections.Generic;

namespace NeoTile.Objects
{
    public class GameObject
    {
        public Texture2D Texture { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public Vector2 Position { get; set; }

        public Size Size { get; set; }

        public Color BgColor { get; set; } = Color.White;

        private bool isDraw = true;

        public virtual void Render(SpriteBatch spriteBatch, Camera.Camera camera)
        {
            if (!isDraw)
                return;

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

        public List<Vector2> NeighbourPositions()
        {
            List<Vector2> neighbours = new List<Vector2>();

            for (int y = -1; y < 2; y++)
                for (int x = -1; x < 2; x++)
                    if (!(x == 0 && y == 0))
                        neighbours.Add(new Vector2(Position.X + x, Position.Y + y));

            return neighbours;
        }

        public void ChangeVisibility()
        {
            isDraw = !isDraw;
        }
    }
}
