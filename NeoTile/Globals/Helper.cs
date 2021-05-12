
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
    }
}
