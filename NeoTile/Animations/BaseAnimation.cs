using Microsoft.Xna.Framework;
using NeoTile.Types;
using System;

namespace NeoTile.Animations
{
    public class BaseAnimation
    {
        protected const int FRAMES = 16;

        protected float time = 0;

        protected int interval = 30;

        protected bool hasFinish = false;

        protected int duration = 0;

        protected Action onFinish;

        public virtual void Update(GameTime gameTime)
        {
            if (hasFinish)
                return;

            time += gameTime.ElapsedGameTime.Milliseconds;
        }

    }
}
