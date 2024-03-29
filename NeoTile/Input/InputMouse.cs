﻿
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

        public Vector2 TilePosition { get { return new Vector2((int)(Position.X / 32), (int)(Position.Y / 32)); } }

        public void Update()
        {
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        public bool MouseDown()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed;
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

        public bool MouseClick()
        {
            return MouseDown() && lastMouseState.LeftButton == ButtonState.Released;
        }

        public bool MouseClick(MouseButton button)
        {
            switch(button)
            {
                case MouseButton.Left:
                    return MouseDown(button) && lastMouseState.LeftButton == ButtonState.Released;
                case MouseButton.Right:
                    return MouseDown(button) && lastMouseState.RightButton == ButtonState.Released;
                default:
                    return false;
            }
        }

    }
}
