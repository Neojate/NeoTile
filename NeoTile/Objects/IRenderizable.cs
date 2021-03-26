using Microsoft.Xna.Framework.Graphics;

namespace NeoTile.Objects
{
    public interface IRenderizable
    {
        void Render(SpriteBatch spriteBatch, Camera.Camera camera);
    }
}
