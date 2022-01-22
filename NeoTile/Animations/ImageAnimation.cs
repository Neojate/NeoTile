using Microsoft.Xna.Framework;
using System;

namespace NeoTile.Animations
{
    public class ImageAnimation : Animation
    {
        private int frames = 0;

        private int frame = 0;

        private bool repeat = false;

        private Action onFinish;

        public ImageAnimation(int frames, int interval)
        {
            this.frames = frames;
            this.interval = interval;
            this.repeat = true;
        }

        public ImageAnimation(int frames, int interval, Action onFinish)
        {
            this.frames = frames;
            this.interval = interval;
            this.onFinish = onFinish;
        }

        public void Update(GameTime gameTime, ref int x)
        {
            base.Update(gameTime);

            if (hasFinish)
                return;

            if (time > interval)
            {
                if (frame == frames - 1)
                {
                    if (repeat)
                        frame = 0;
                    else 
                    {
                        hasFinish = true;
                        onFinish?.Invoke();
                    }
                        
                }
                else
                    frame++;
                
                time = 0;
                x = frame;
            }
            
        }
        
    }
}
