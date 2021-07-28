
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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
    }
}
