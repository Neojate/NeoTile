using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Types;
using NeoTile.Worlds;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NeoTile.Objects
{
    public class GameObject
    {
        [JsonIgnore]
        public Texture2D Texture;

        public Rectangle SourceRectangle { get; set; }

        public Vector2 Position { get; set; }

        public Color BgColor { get; set; } = Color.White;

        private bool isDraw = true;

        protected Vector2 frame = Vector2.Zero;

        public virtual void Render(SpriteBatch spriteBatch, Camera.Camera camera)
        {
            if (!isDraw)
                return;

            spriteBatch.Draw(
                getTexture(),
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
            return NeighbourPositions(false);
        }

        public List<Vector2> NeighbourPositions(bool centerTile)
        {
            List<Vector2> neighbours = new List<Vector2>();

            for (int y = -1; y < 2; y++)
                for (int x = -1; x < 2; x++)
                    if (centerTile)
                        neighbours.Add(new Vector2(Position.X + x, Position.Y + y));
                    else
                        if (!(x == 0 && y == 0))
                            neighbours.Add(new Vector2(Position.X + x, Position.Y + y));

            return neighbours;
        }

        public void ChangeVisibility()
        {
            isDraw = !isDraw;
        }

        protected virtual Texture2D getTexture()
        {
            return null;
        }

    }
}
