using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Input;
using System;
using System.Collections.Generic;

namespace NeoTile.Components
{
    public class Div : Component
    {
        //Lista de los componentes del div
        public List<Component> Children = new List<Component>();

        //Acción al hacer click
        public Action OnClick;

        //Acción al dejar apretado el ratón
        public Action OnPress;

        private InputMouse mouse = InputMouse.Instance;

        public override void HandleInput()
        {
            if (OnClick != null && mouse.MouseClick() && Bounds.Contains(mouse.Position))
                OnClick();

            if (OnPress != null && mouse.MouseDown() && Bounds.Contains(mouse.Position))
                OnPress();

            Children.ForEach(child => child.HandleInput());
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Style.Texture, Bounds, CurrentBgColor);

            Children.ForEach(child => child.Render(spriteBatch));
        }

        public override void Update(GameTime gameTime)
        {
            if (Bounds.Contains(mouse.Position))
            {
                CurrentBgColor = Style.HoverBgColor.A != 0 ? Style.HoverBgColor : Style.BgColor;
                Children.ForEach(child => child.CurrentBgColor = CurrentBgColor);

                CurrentFontColor = Style.HoverFontColor.A != 0 ? Style.HoverFontColor : Style.FontColor;
                Children.ForEach(child => child.CurrentFontColor = CurrentFontColor);
            }

            Children.ForEach(child => child.Update(gameTime));
        }
    }
}
