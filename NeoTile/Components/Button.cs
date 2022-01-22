using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Globals;
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

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: Style.Texture,
                destinationRectangle: Bounds,
                color: Enable ? CurrentBgColor : Style.DisabledBgColor
            );

            if (Text != null)
                spriteBatch.DrawString(
                    spriteFont: Style.Font,
                    text: Text,
                    position: Helper.CenterText(Style.Font, Bounds, Text),
                    color: Enable ? CurrentFontColor : Style.DisabledFontColor
                );
        }

        public override void Update(GameTime gameTime)
        {
            if (!Enable)
                return;

            if (Bounds.Contains(mouse.Position))
            {
                if (OnClick != null && mouse.MouseClick())
                    OnClick();

                if (OnPress != null && mouse.MouseDown())
                    OnPress();
            }

            CurrentBgColor = Style.HoverBgColor.A != 0 && Bounds.Contains(mouse.Position) ? Style.HoverBgColor : Style.BgColor;
            CurrentFontColor = Style.HoverFontColor.A != 0 && Bounds.Contains(mouse.Position) ? Style.HoverFontColor : Style.FontColor;

        }
    }
}
