
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Globals;
using System.Collections.Generic;

namespace NeoTile.Components
{
    public class TextArea : Component
    {
        private SpriteFont font;

        private List<string> texts;

        public TextArea(Rectangle bounds, SpriteFont font, string text, Style style)
        {
            Bounds = bounds;
            this.font = font;
            texts = Helper.JustifyText(font, text, bounds.Width);
            Style = style;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            int y = Bounds.Y;
            foreach (string text in texts)
            {
                spriteBatch.DrawString(font, text, new Vector2(Bounds.X, y), Style.FontColor);
                y += (int)font.MeasureString("L").Y + 1;
            }
                
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
