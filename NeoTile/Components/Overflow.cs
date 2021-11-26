using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace NeoTile.Components
{
    public enum OverflowDirection
    {
        Bottom, Top
    }

    public class Overflow : Component
    {
        private List<Div> divs;

        private List<Component> components = new List<Component>();

        private int areaSize = 0;

        private OverflowDirection direction;

        private WrapIndexer wrapIndexer;

        private int startDivY;

        private Style styleButton;

        public int moveSpeed = 5;

        private Bar bar;

        public Overflow(List<Div> divs, Rectangle bounds, OverflowDirection direction, int wrap, Style styleButton)
        {
            this.divs = divs;
            Bounds = bounds;
            this.direction = direction;

            if (divs.Count > 0)
                areaSize = divs[0].Bounds.Height + wrap;

            this.styleButton = styleButton;

            int indexer = 0;
            wrapIndexer = new WrapIndexer() { Indexer = indexer };
            createInterface();
        }

        public override void HandleInput()
        {
            divs.ForEach(div => div.HandleInput());

            components.ForEach(component => component.HandleInput());
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            int y = direction == OverflowDirection.Top
                ? Bounds.Y + wrapIndexer.Indexer
                : Bounds.Y + wrapIndexer.Indexer + Bounds.Height - (divs.Count * areaSize);

            startDivY = y;

            divs.ForEach(div =>
            {
                if (y >= Bounds.Y && y <= Bounds.Y + Bounds.Height - areaSize)
                {
                    div.Bounds.Y = y;
                    div.Render(spriteBatch);
                    if (div.Children != null)
                        div.Children.ForEach(child => child.Bounds.Y = y);
                }
                y += areaSize;
            });

            components.ForEach(component => component.Render(spriteBatch));
        }

        public override void Update(GameTime gameTime)
        {
            divs.ForEach(div => div.Update(gameTime));

            components.ForEach(component => component.Update(gameTime));
        }

        private void createInterface()
        {
            if (divs.Count == 0)
                return;

            int totalItemHeight = areaSize * divs.Count;
            int maxBarHeight = Bounds.Height - 15 * 2;

            if (totalItemHeight > maxBarHeight)
            {
                components = new List<Component>();

                components.Add(new Button()
                {
                    Bounds = new Rectangle(Bounds.X + Bounds.Width - 15, Bounds.Y + 5, 10, 10),
                    OnPress = up,
                    Style = styleButton
                });

                components.Add(new Button()
                {
                    Bounds = new Rectangle(Bounds.X + Bounds.Width - 15, Bounds.Y + Bounds.Height - 15, 10, 10),
                    OnPress = down,
                    Style = styleButton
                });

                Vector2 limit = new Vector2(Bounds.Y + 15 + 10, Bounds.Y + Bounds.Height - 15 - 10);
                int barHeight = maxBarHeight - (totalItemHeight - maxBarHeight);
                Rectangle barRectangle = direction == OverflowDirection.Top
                    ? new Rectangle(Bounds.X + Bounds.Width - 15, Bounds.Y + 15 + 10, 10, barHeight)
                    : new Rectangle(Bounds.X + Bounds.Width - 15, Bounds.Y + Bounds.Height - barHeight - 15 - 10, 10, barHeight);

                bar = new Bar(
                    bounds: barRectangle,
                    style: styleButton,
                    limit: limit,
                    wrapIndexer: wrapIndexer
                );

                components.Add(bar);                    
            }

        }

        private void up()
        {
            if (startDivY < Bounds.Y)
            {
                wrapIndexer.Indexer += moveSpeed;
                bar.Bounds.Y -= moveSpeed;
            }
        }

        private void down()
        {
            if (startDivY + divs.Count * areaSize >= Bounds.Y + Bounds.Height)
            {
                wrapIndexer.Indexer -= moveSpeed;
                bar.Bounds.Y += moveSpeed;
            }
        }
    }

    public class WrapIndexer
    {
        public int Indexer;
    }
}
