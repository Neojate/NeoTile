
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NeoTile.Input;

namespace NeoTile.Camera
{
    public class Zoom
    {
        public Keys KeyIn { get; set; } = Keys.Z;

        public Keys KeyOut { get; set; } = Keys.X;

        public float Scale { get; set; } = 1f;

        public float Speed { get; set; } = 0.005f;

        public float MinZoom { get; set; } = 0.5f;

        public float MaxZoom { get; set; } = 2f;

        public void HandleInput(InputKeyboard keyboard)
        {
            if (keyboard.KeyDown(KeyIn))
                Scale += Speed;

            else if (keyboard.KeyDown(KeyOut))
                Scale -= Speed;

            Scale = MathHelper.Clamp(Scale, MinZoom, MaxZoom);
        }
    }
}
