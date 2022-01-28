
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeoTile.ScreenManager
{
    public interface IRenderizable
    {
        void Update(GameTime gameTime);

        void Render(SpriteBatch spriteBatch);
    }
}
