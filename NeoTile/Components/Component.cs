using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Input;
using NeoTile.ScreenManager;

namespace NeoTile.Components
{
    public abstract class Component : IRenderizable
    {
        public Rectangle Bounds;

        public Style Style;

        public Color CurrentBgColor, CurrentFontColor;

        public Component Father;

        protected InputMouse mouse = InputMouse.Instance;

        public abstract void Render(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);

        protected Vector2 relativePos()
        {
            return new Vector2(Father.Bounds.X + Bounds.X, Father.Bounds.Y + Bounds.Y);
        }
    }
}
