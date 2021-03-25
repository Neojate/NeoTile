
using Microsoft.Xna.Framework;
using NeoTile.Globals;

namespace NeoTile
{
    public class NeoTile
    {
        //NuevoTile
        public NeoTile(Vector2 resolution)
        {
            Needs game = Needs.Instance;
            game.Resolution = resolution;
        }
    }
}
