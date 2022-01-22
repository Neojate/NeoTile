using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Input;
using System;

namespace NeoTile.Components
{
    public class Bar : Component
    {
        private Vector2 limit;

        private WrapIndexer wrapIndexer;

        private Vector2 barInitialPosition;

        private Vector2 clickPosition;

        private bool canMove = false;

        public Bar(Rectangle bounds, Style style, Vector2 limit, WrapIndexer wrapIndexer)
        {
            Bounds = bounds;
            Style = style;
            this.limit = limit;
            this.wrapIndexer = wrapIndexer;
            
            barInitialPosition = new Vector2(bounds.X, bounds.Y);
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Style.Texture, Bounds, Style.BgColor);
        }

        public override void Update(GameTime gameTime)
        {
            if (mouse.MouseDown() && Bounds.Contains(mouse.Position))
            {
                canMove = true;
                clickPosition = Vector2.Subtract(mouse.Position, new Vector2(Bounds.X, Bounds.Y));
            }

            if (canMove && !mouse.MouseDown())
                canMove = false;

            if (canMove)
            {
                int deltaY = (int)(mouse.Position.Y - clickPosition.Y);
                if (deltaY >= limit.X && deltaY + Bounds.Height <= limit.Y)
                {
                    wrapIndexer.Indexer = (deltaY - (int)barInitialPosition.Y) * -1;
                    Bounds.Y = deltaY;
                }
            }
        }
    }
}
