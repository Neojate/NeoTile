
using Microsoft.Xna.Framework;
using System;

namespace NeoTile.Animations
{
    public class Animation
    {
        protected float time = 0;

        protected int interval = 0;

        protected bool hasFinish = false;

        public Action OnFinish;

        public virtual void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
