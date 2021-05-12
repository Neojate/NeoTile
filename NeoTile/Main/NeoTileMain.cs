﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Assets;
using NeoTile.Globals;
using NeoTile.Input;
using NeoTile.Language;


namespace NeoTile.Main
{
    public class NeoTileMain
    {
        ScreenManager.ScreenManager screenManager;
        
        InputKeyboard inputKeyboard;
        InputMouse inputMouse;

        Fonts fonts;
        Textures textures;
        Sounds sounds;
        Effects effects;

        Translator translator;

        public NeoTileMain(Vector2 resolution, ContentManager content)
        {
            //establecemos la resolución para la cámara
            GameOptions needs = GameOptions.Instance;
            needs.Resolution = resolution;

            //arrancamos el  ScreenManager
            screenManager = ScreenManager.ScreenManager.Instance;
            
            //arrancamos el input
            inputKeyboard = InputKeyboard.Instance;
            inputMouse = InputMouse.Instance;

            //arrancamos los assets (texturas, fuentes, sonidos, efectos)
            fonts = Fonts.Instace;
            fonts.LinkContent(content);

            textures = Textures.Instance;
            textures.LinkContent(content);

            sounds = Sounds.Instance;
            sounds.LinkContent(content);

            effects = Effects.Instance;
            effects.LinkContent(content);
        }

        public void TranslatorData(string jsonName)
        {
            translator = Translator.Instance;
            translator.LoadJson(jsonName);
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
