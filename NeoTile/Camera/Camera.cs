
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NeoTile.Input;

namespace NeoTile.Camera
{
    public class Camera
    {
        public Point Position { get; set; }

        public Vector2 Offset { get; set; }

        public Zoom Zoom { get; set; } = new Zoom();

        public void HandleInput()
        {
            if (InputKeyboard.KeyDown(Zoom.KeyIn))
                Zoom.Scale += Zoom.Speed;
            
            else if (InputKeyboard.KeyDown(Zoom.KeyOut))
                Zoom.Scale -= Zoom.Speed;

            Zoom.Scale = MathHelper.Clamp(Zoom.Scale, Zoom.MinZoom, Zoom.MaxZoom);
        }
    }
}
