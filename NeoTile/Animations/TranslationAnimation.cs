
using Microsoft.Xna.Framework;
using System;

namespace NeoTile.Animations
{
    public class TranslationAnimation : Animation
    {
        private WrapNumber number;

        private int increment;

        private int destiny;

        private bool positiveSignal;

        public TranslationAnimation(WrapNumber number, int increment, int destiny, int interval, Action onFinish)
        {
            this.number = number;
            this.increment = increment;
            this.destiny = destiny;
            this.interval = interval;
            this.OnFinish = onFinish;

            positiveSignal = increment > 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (hasFinish)
                return;

            base.Update(gameTime);

            if (time > interval)
            {
                number.Value += increment;

                if (positiveSignal)
                {
                    if (number.Value >= destiny)
                    {
                        hasFinish = true;
                        OnFinish?.Invoke();
                    }
                } 
                else
                {
                    if (number.Value <= destiny)
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
