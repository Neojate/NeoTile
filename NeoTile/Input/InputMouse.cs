
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace NeoTile.Input
{
    public sealed class InputMouse
    {
        private static readonly Lazy<InputMouse> Lazy = new Lazy<InputMouse>(() => new InputMouse());

        public static InputMouse Instance { get { return Lazy.Value; } }

        private MouseState currentMouseState;
        private MouseState lastMouseState;

        public Vector2 Position { get { return new Vector2(currentMouseState.X, currentMouseState.Y); } }

        public void Update()
        {
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        public bool MouseClick()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed;
        }

        public bool MouseClick(MouseButton button)
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

        public bool MouseDown()
        {
            return MouseClick() && lastMouseState.LeftButton == ButtonState.Pressed;
        }

        public bool MouseDown(MouseButton button)
        {
            switch(button)
            {
                case MouseButton.Left:
                    return MouseClick(button) && lastMouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return MouseClick(button) && lastMouseState.RightButton == ButtonState.Pressed;
                default:
                    return false;
            }
        }

    }
}
