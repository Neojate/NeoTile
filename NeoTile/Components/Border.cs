using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeoTile.Components
{

    public class Border
    {
        private Texture2D texture;

        private Rectangle bounds;

        private Color color;

        private int weight;

        public Border(Texture2D texture, Rectangle bounds, Color color, int weight)
        {
            this.texture = texture;
            this.bounds = bounds;
            this.color = color;
            this.weight = weight;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(bounds.X, bounds.Y, bounds.Width, weight), color);
            spriteBatch.Draw(texture, new Rectangle(bounds.X, bounds.Y + bounds.Height - weight, bounds.Width, weight), color);

            spriteBatch.Draw(texture, new Rectangle(bounds.X, bounds.Y, weight, bounds.Height), color);
            spriteBatch.Draw(texture, new Rectangle(bounds.X + bounds.Width - weight, bounds.Y, weight, bounds.Height), color);
        }

    }
}
