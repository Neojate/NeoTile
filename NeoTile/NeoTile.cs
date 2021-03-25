
using Microsoft.Xna.Framework;
using NeoTile.Globals;

namespace NeoTile
{
    public class NeoTile
    {
        public NeoTile(Vector2 resolution)
        {
            Needs game = Needs.Instance;
            game.Resolution = resolution;
        }
    }
}
