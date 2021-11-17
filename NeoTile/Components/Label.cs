using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeoTile.Components
{
    public class Label : Component
    {
        //Texto del label
        public string Text;

        public override void HandleInput()
        {
            
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Style.Font, Text, new Vector2(Bounds.X, Bounds.Y), CurrentFontColor);
        }

        public override void Update(GameTime gameTime)
        {
            CurrentFontColor = Style.HoverFontColor.A != 0 ? Style.HoverFontColor : Style.FontColor;
        }
    }
}
