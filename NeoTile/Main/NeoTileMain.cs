


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Globals;
using NeoTile.Input;
using NeoTile.ScreenManager;

namespace NeoTile.Main
{
    public class NeoTileMain
    {
        ScreenManager.ScreenManager screenManager;
        InputKeyboard inputKeyboard;
        InputMouse inputMouse;

        public NeoTileMain(Vector2 resolution)
        {
            Needs needs = Needs.Instance;
            needs.Resolution = resolution;

            screenManager = ScreenManager.ScreenManager.Instance;
            inputKeyboard = InputKeyboard.Instance;
            inputMouse = InputMouse.Instance;
        }

        public void Update()
        {
            screenManager.Update();

            inputKeyboard.Update();
            inputMouse.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            screenManager.Draw(spriteBatch);
        }

    }
}
