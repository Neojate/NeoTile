using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeoTile.ScreenManager
{
    public class ScreenManager
    {
        private static Lazy<ScreenManager> Lazy = new Lazy<ScreenManager>(() => new ScreenManager());

        private List<string> historical = new List<string>();

        public static ScreenManager Instance { get { return Lazy.Value; } }

        private List<Screen> screens = new List<Screen>();

        public void AddScreen(Screen newScreen)
        {
            historical.Add(newScreen.Name);
            screens.Add(newScreen);
        }

        public void AddScreenAndFocus(Screen newScreen)
        {
            historical.Add(newScreen.Name);
            screens.ForEach(screen => screen.State = ScreenState.Hidden);
            screens.Add(newScreen);
        }

        public void AddWithoutHistorical(Screen newScreen)
        {
            screens.Add(newScreen);
        }

        public void RemoveScreen(Screen removeScreen)
        {
            screens.Find(screen => screen.Name == removeScreen.Name).State = ScreenState.ShutDown;
        }

        public void RemoveScreen(String screenName)
        {
            screens.Find(screen => screen.Name == screenName).State = ScreenState.ShutDown;
        }

        public void RemoveScreenWithFocus(string removeName, string focusScreen)
        {
            foreach (Screen screen in screens)
            {
                if (screen.Name == removeName)
                    screen.State = ScreenState.ShutDown;
                else if (screen.Name == focusScreen)
                    screen.State = ScreenState.Active;
            }
        }

        public void ReturnBack()
        {
            string currentScreenName = historical.Last();
            historical.Remove(currentScreenName);
            string newScreenName = historical.Last();
            foreach (Screen screen in screens)
            {
                if (screen.Name == currentScreenName)
                    screen.State = ScreenState.ShutDown;

                if (screen.Name == newScreenName)
                    screen.State = ScreenState.Active;
            }
        }

        public void SetFocus(string screenName)
        {
            screens.Find(screen => screen.Name == screenName).State = ScreenState.Active;
        }

        public void Update(GameTime gameTime)
        {
            List<Screen> removeScreens = new List<Screen>();

            foreach (Screen screen in screens.FindAll(s => s.State == ScreenState.ShutDown))
                removeScreens.Add(screen);

            foreach (Screen screen in removeScreens)
                screens.Remove(screen);

            foreach (Screen screen in screens.FindAll(s => s.State == ScreenState.Active))
            {
                screen.HandleInput();
                screen.Update(gameTime);
            }                
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Screen screen in screens.FindAll(s => s.State != ScreenState.ShutDown))
                screen.Draw(spriteBatch);
        }

        public Screen GetScreen(string screenName)
        {
            return screens.Find(screen => screen.Name == screenName);
        }

    }
}
