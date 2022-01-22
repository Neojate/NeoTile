
using Microsoft.Xna.Framework;
using System;

namespace NeoTile.Animations
{
    public enum FadeType
    {
        FadeIn,
        FadeOut
    }

    public class FadeAnimation : Animation
    {
        private FadeType fadeType;

        private WrapNumber number;

        private float increment;

        private int destiny;

        public FadeAnimation(FadeType fadeType, WrapNumber number, float increment, int interval, Action onFinish)
        {
            this.fadeType = fadeType;
            this.number = number;
            this.increment = increment;
            this.interval = interval;
            this.OnFinish = onFinish;
        }

        public override void Update(GameTime gameTime)
        {
            if (hasFinish)
                return;

            base.Update(gameTime);

            if (time > interval)
            {
                if (fadeType == FadeType.FadeIn)
                {
                    number.Value += increment;

                    if (number.Value >= 1)
                    {
                        hasFinish = true;
                        OnFinish?.Invoke();
                    }
                }
                else
                {
                    number.Value -= increment;

                    if (number.Value <= 0)
                    {
                        hasFinish = true;
                        OnFinish?.Invoke();
                    }
                }
                time = 0;
            }
        }
    }
}
