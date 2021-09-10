using Microsoft.Xna.Framework;
using NeoTile.Types;
using System;

namespace NeoTile.Animations
{
    public class Translation : BaseAnimation
    {
        public void Update(GameTime gameTime, ObjectVector2 currentPosition, Vector2 increment, Vector2 destiny, Action onFinish)
        {
            base.Update(gameTime);

            if (hasFinish)
                return;

            if (time > interval)
            {
                currentPosition.Position = Vector2.Add(currentPosition.Position, increment);

                if (currentPosition.Position == destiny)
                {
                    hasFinish = true;

                    onFinish?.Invoke();
                }
                time = 0;
            }
        }

    }
}
