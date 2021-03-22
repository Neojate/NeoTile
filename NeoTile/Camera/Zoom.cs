
using Microsoft.Xna.Framework.Input;

namespace NeoTile.Camera
{
    public class Zoom
    {
        public Keys KeyIn { get; set; } = Keys.Z;

        public Keys KeyOut { get; set; } = Keys.X;

        public float Scale { get; set; } = 1f;

        public float Speed { get; set; } = 1f;
    }
}
