using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Input;
using System;

namespace NeoTile.Components
{
    public class Button : Component
    {
        public string Text;

        public Action OnClick;

        public Action OnPress;

        public bool Enable = true;

        public override void HandleInput()
        {
            if (!Enable)
                return;

            if (OnClick != null && mouse.MouseClick() && Bounds.Contains(mouse.Position))
                OnClick();

            if (OnPress != null && mouse.MouseDown() && Bounds.Contains(mouse.Position))
                OnPress();
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Style.Texture, Bounds, CurrentBgColor);

            if (Text != null)
                spriteBatch.DrawString(Style.Font, Text, new Vector2(Bounds.X, Bounds.Y), CurrentFontColor);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Enable)
                return;

            CurrentBgColor = Style.HoverBgColor.A != 0 && Bounds.Contains(mouse.Position)
                ? Style.HoverBgColor
                : Style.BgColor;

            CurrentFontColor = Style.HoverFontColor.A != 0 && Bounds.Contains(mouse.Position)
                ? Style.HoverFontColor
                : Style.FontColor;
        }
    }
}
