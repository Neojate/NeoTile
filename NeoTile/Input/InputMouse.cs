﻿using Microsoft.Xna.Framework.Input;
using System;

namespace NeoTile.Input
{
    public sealed class InputMouse
    {
        private static readonly Lazy<InputMouse> Lazy = new Lazy<InputMouse>(() => new InputMouse());

        public static InputMouse Instance { get { return Lazy.Value; } }

        private static MouseState currentMouseState;
        private static MouseState lastMouseState;

        public void Update()
        {
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        public bool MouseDown(MouseButton button)
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

        public bool MouseClick(MouseButton button)
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
