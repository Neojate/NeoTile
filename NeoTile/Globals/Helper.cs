
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace NeoTile.Globals
{
    public static class Helper
    {
        public static T Clone<T>(T clonedItem)
        {
            T newObject = Activator.CreateInstance<T>();
            foreach (var property in clonedItem.GetType().GetProperties())
            {
                var value = property.GetValue(clonedItem);
                clonedItem.GetType().GetProperty(property.Name).SetValue(newObject, value, null);
            }
            return (T)(object)newObject;
        }

        public static Vector2 CenterText(SpriteFont font, Rectangle bounds, string text)
        {
            Vector2 measureString = Vector2.Divide(font.MeasureString(text), 2);
            
            return new Vector2(
                bounds.Width / 2 - measureString.X + bounds.X,
                bounds.Height / 2 - measureString.Y + bounds.Y
                );
        }

        public static Rectangle CenterScreen(Vector2 resolution, Vector2 dimensions)
        {
            return new Rectangle(
                (int)(resolution.X / 2 - dimensions.X / 2),
                (int)(resolution.Y / 2 - dimensions.Y / 2),
                (int)dimensions.X,
                (int)dimensions.Y);
        }

        public static List<string> JustifyText(SpriteFont font, string text, int width)
        {
            if (font.MeasureString(text).X < width)
                return new List<string>() { text };

            List<string> results = new List<string>();
            string result = "";
            foreach (string word in text.Split(' '))
            {
                if (font.MeasureString($"{result} {word} ").X >= width)
                {
                    results.Add(result);
                    result = "";
                }

                result += $"{word} ";
            }
            results.Add(result);

            return results;
        }

    }
}
