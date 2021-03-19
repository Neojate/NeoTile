﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace NeoTile.ScreenManager
{
    public class ScreenManager
    {
        private List<Screen> screens = new List<Screen>();

        public void AddScreen(Screen newScreen)
        {
            screens.Add(newScreen);
        }

        public void AddScreenAndFocus(Screen newScreen)
        {
            screens.ForEach(screen => screen.State = ScreenState.Hidden);
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

        public void Update()
        {
            List<Screen> removeScreens = new List<Screen>();

            foreach (Screen screen in screens.FindAll(s => s.State == ScreenState.ShutDown))
                removeScreens.Add(screen);

            foreach (Screen screen in removeScreens)
                screens.Remove(screen);

            foreach (Screen screen in screens.FindAll(s => s.State == ScreenState.Active))
            {
                screen.HandleInput();
                screen.Update();
            }                
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Screen screen in screens.FindAll(s => s.State == ScreenState.Active))
                screen.Draw(spriteBatch);
        }

        public Screen GetScreen(string screenName)
        {
            return screens.Find(screen => screen.Name == screenName);
        }

    }
}
