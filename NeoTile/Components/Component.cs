using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Input;

namespace NeoTile.Components
{
    public abstract class Component
    {
        public Rectangle Bounds;

        public Style Style;

        public Color CurrentBgColor, CurrentFontColor;

        protected InputMouse mouse = InputMouse.Instance;

        public abstract void Render(SpriteBatch spriteBatch);

        public abstract void HandleInput();

        public abstract void Update(GameTime gameTime);
    }
}
