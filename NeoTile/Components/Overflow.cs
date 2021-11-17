using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace NeoTile.Components
{
    class Overflow : Component
    {
        public List<Div> Divs;

        private List<Component> components;

        public override void HandleInput()
        {
            throw new NotImplementedException();
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void createInterface()
        {
            if (Divs.Count == 0)
                return;


        }
    }
}
