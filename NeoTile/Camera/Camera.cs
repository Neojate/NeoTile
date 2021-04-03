
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NeoTile.Globals;
using NeoTile.Input;
using NeoTile.Worlds;

namespace NeoTile.Camera
{
    public class Camera
    {
        public Vector2 Position { get; set; }

        public Zoom Zoom { get; set; } = new Zoom();

        public float Speed { get; set; } = 1f;

        public Keys Up { get; set; } = Keys.Up;
        public Keys Down { get; set; } = Keys.Down;
        public Keys Left { get; set; } = Keys.Left;
        public Keys Right { get; set; } = Keys.Right;

        private InputKeyboard keyboard = InputKeyboard.Instance;
        private InputMouse mouse = InputMouse.Instance;

        private Needs needs = Needs.Instance;

        public void HandleInput()
        {
            Zoom.HandleInput(keyboard);

            Vector2 newVector = Vector2.Zero;

            if (keyboard.KeyDown(Up))
                newVector = new Vector2(0, -1 * Speed);
            else if (keyboard.KeyDown(Down))
                newVector = new Vector2(0, 1 * Speed);
            else if (keyboard.KeyDown(Left))
                newVector = new Vector2(-1 * Speed, 0);
            else if (keyboard.KeyDown(Right))
                newVector = new Vector2(1 * Speed, 0);

            Position = Vector2.Add(Position, newVector);
        }

        public void HandleInput(Vector2 position)
        {
            Zoom.HandleInput(keyboard);

            position = Vector2.Multiply(position, new Vector2(TileOption.Size.Width, TileOption.Size.Height));

            Vector2 posResolution = Vector2.Divide(needs.Resolution, 2);

            Position = Vector2.Subtract(position, posResolution);

        }

    }
}
