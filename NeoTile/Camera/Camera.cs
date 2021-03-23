
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NeoTile.Input;

namespace NeoTile.Camera
{
    public class Camera
    {
        public Vector2 Position { get; set; }

        public Zoom Zoom { get; set; } = new Zoom();

        public bool FreeMovement { get; set; } = true;

        public float Speed { get; set; } = 1f;

        public Keys Up { get; set; } = Keys.Up;
        public Keys Down { get; set; } = Keys.Down;
        public Keys Left { get; set; } = Keys.Left;
        public Keys Right { get; set; } = Keys.Right;

        public void HandleInput(Point newPosition)
        {
            if (InputKeyboard.KeyDown(Zoom.KeyIn))
                Zoom.Scale += Zoom.Speed;
            
            else if (InputKeyboard.KeyDown(Zoom.KeyOut))
                Zoom.Scale -= Zoom.Speed;

            Zoom.Scale = MathHelper.Clamp(Zoom.Scale, Zoom.MinZoom, Zoom.MaxZoom);

            if (FreeMovement)
            {
                Vector2 newVector = Vector2.Zero;
                if (InputKeyboard.KeyDown(Up))
                    newVector = new Vector2(0, -1 * Speed);
                else if (InputKeyboard.KeyDown(Down))
                    newVector = new Vector2(0, 1 * Speed);
                else if (InputKeyboard.KeyDown(Left))
                    newVector = new Vector2(-1 * Speed, 0);
                else if (InputKeyboard.KeyDown(Right))
                    newVector = new Vector2(1 * Speed, 0);
                Position = Vector2.Add(Position, newVector);
            }

        }
    }
}
