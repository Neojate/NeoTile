using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeoTile.Components
{
    public abstract class Component
    {
        public Rectangle Bounds;

        public Style Style;

        public Color CurrentBgColor, CurrentFontColor;

        public abstract void Render(SpriteBatch spriteBatch);

        public abstract void HandleInput();

        public abstract void Update(GameTime gameTime);
    }
}
