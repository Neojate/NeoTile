using Microsoft.Xna.Framework;
using NeoTile.Types;
using System;

namespace NeoTile.Animations
{
    public class Fade : BaseAnimation
    {
        private float alpha = 1;
        private float delta;

        public Fade(int duration)
        {
            delta = 1f / duration * FRAMES;
        }

        public void In(GameTime gameTime, ObjectColor color, Action onFinish)
        {
            if (hasFinish)
                return;

            time += gameTime.ElapsedGameTime.Milliseconds;

            if (time <= FRAMES)
                return;

            alpha += delta;
            color.Color *= alpha;
            time = 0;

            if (alpha >= 1)
            {
                hasFinish = true;
                onFinish?.Invoke();
            }

        }

        public void Out(GameTime gameTime, ObjectColor color, Action onFinish)
        {
            if (hasFinish)
                return;

            time += gameTime.ElapsedGameTime.Milliseconds;

            if (time <= FRAMES)
                return;

            alpha -= delta;
            color.Color *= alpha;
            time = 0;

            if (alpha <= 0)
            {
                hasFinish = true;
                onFinish?.Invoke();
            }

        }

    }
}
