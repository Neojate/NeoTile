using Microsoft.Xna.Framework.Input;
using System;

namespace NeoTile.Input
{
    public sealed class InputKeyboard
    {

        private static readonly Lazy<InputKeyboard> Lazy = new Lazy<InputKeyboard>(() => new InputKeyboard());

        public static InputKeyboard Instance { get { return Lazy.Value; } }   

        private KeyboardState currentKeyState;
        private KeyboardState lastKeyState;

        public void Update()
        {
            lastKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
        }

        public bool KeyDown(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        public bool KeyPressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && lastKeyState.IsKeyUp(key);
        }

        
    }
}
