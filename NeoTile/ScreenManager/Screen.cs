﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Assets;
using NeoTile.Input;

namespace NeoTile.ScreenManager
{
    public abstract class Screen
    {
        //Nombre de la pantalla. Por defecto el nombre es {name}Screen
        public string Name { get { return GetType().Name; } }

        //Estado de la pantalla (Active|Hidden|Shutdown). Por defecto las pantallas están activas.
        //Activas: pantallas que se actualizan y sobre las que hay control de input.
        //Hidden: pantallas cargadas pero que no se actualizan, no tienen input ni se renderizan.
        //Shutdow: pantallas que van a cerrarse.
        public ScreenState State { get; set; } = ScreenState.Active;

        //Variable que determina la actualización constante de la pantalla
        public bool IsPartial { get; set; } = false;

        //Medidas de la pantalla
        protected Rectangle bounds { get; set; }

        //Color de fondo de la pantalla
        protected Color bgColor { get; set; } = Color.White;

        //Instancia de las texturas
        protected Textures textures { get; set; } = Textures.Instance;

        //Instancia de las fuentes
        protected Fonts fonts { get; set; } = Fonts.Instace;

        //Instancia de la ScreenManager
        protected ScreenManager screenManager { get; set; } = ScreenManager.Instance;

        //Instancia del keyboard
        protected InputKeyboard keyboard { get; } = InputKeyboard.Instance;

        //Instancia del mouse
        protected InputMouse mouse { get; } = InputMouse.Instance;

        //Método para arrancar las pantallas
        protected bool hasInitialized = false;

        //Método abstracto necesario para la actualización de la pantalla
        public abstract void Update(GameTime gameTime);

        //Método abstracto necesario para el renderizado de la pantalla
        public abstract void Draw(SpriteBatch spriteBatch);

        //Método para arrancar la pantalla fuera del controlador
        protected virtual void init()
        {
            hasInitialized = true;
        }

    }
}
