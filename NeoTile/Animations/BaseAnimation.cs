using Microsoft.Xna.Framework;

namespace NeoTile.Animations
{
    public class BaseAnimation
    {
        protected float time = 0;

        protected int interval = 30;

        protected bool hasFinish = false;

        public virtual void Update(GameTime gameTime)
        {
            if (hasFinish)
                return;

            time += gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
