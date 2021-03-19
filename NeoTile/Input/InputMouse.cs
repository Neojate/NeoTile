using Microsoft.Xna.Framework.Input;

namespace NeoTile.Input
{
    public class InputMouse : Input
    {
        private static MouseState currentMouseState;
        private static MouseState lastMouseState;

        public override void Update()
        {
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        public static bool MouseDown(MouseButton button)
        {
            switch(button)
            {
                case MouseButton.Left:
                    return currentMouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return currentMouseState.RightButton == ButtonState.Pressed;
                default:
                    return false;
            }
        }

        public static bool MouseClick(MouseButton button)
        {
            switch(button)
            {
                case MouseButton.Left:
                    return MouseDown(button) && lastMouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return MouseDown(button) && lastMouseState.RightButton == ButtonState.Pressed;
                default:
                    return false;
            }
        }

    }
}
