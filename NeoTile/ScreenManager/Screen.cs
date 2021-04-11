
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeoTile.Assets;

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

        //Instancia de las texturas
        protected Textures textures { get; set; } = Textures.Instance;

        //Instancia de las fuentes
        protected Fonts fonts { get; set; } = Fonts.Instace;

        //Instancia de la ScreenManager
        protected ScreenManager screenManager = ScreenManager.Instance;

        //Medidas de la pantalla
        protected Rectangle bounds { get; set; }

        //método abstracto necesario para la ejecución del input
        public abstract void HandleInput();

        //método abstracto necesario para la actualización de la pantalla
        public abstract void Update();

        //método abstracto necesario para el renderizado de la pantalla
        public abstract void Draw(SpriteBatch spriteBatch);


    }
}
