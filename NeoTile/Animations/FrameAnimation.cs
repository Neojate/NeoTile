
using Microsoft.Xna.Framework;

namespace NeoTile.Animations
{
    public class FrameAnimation : Animation
    {
        public int NumFrames = 0;

        public WrapVector2 WrapVector2;

        public bool IsRepeat = false;

        public int yFrame = 0;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            WrapVector2.Value.Y = yFrame;

            if (time > 16)
            {
                WrapVector2.Value.X++;

                if (animationHasFinish())
                {
                    WrapVector2.Value.X = 0;

                    if (!IsRepeat)
                        OnFinish.Invoke();
                }

                time = 0;
            }
        }

        private bool animationHasFinish()
        {
            return WrapVector2.Value.X >= NumFrames;
        }
    }
}
