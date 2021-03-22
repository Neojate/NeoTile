using Microsoft.Xna.Framework.Input;

namespace NeoTile.Input
{
    public class InputKeyboard
    {
        private static KeyboardState currentKeyState;
        private static KeyboardState lastKeyState;

        public static void Update()
        {
            lastKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
        }

        public static bool KeyDown(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && lastKeyState.IsKeyUp(key);
        }

        
    }
}
