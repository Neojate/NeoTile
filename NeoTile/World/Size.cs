using Microsoft.Xna.Framework;
using NeoTile.Exceptions;

namespace NeoTile.World
{
    public class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Size(int width, int height)
        {
            Width = validateValue(width);
            Height = validateValue(height);
        }

        public Size(Point point)
        {
            Width = validateValue(point.X);
            Height = validateValue(point.Y);
        }

        private int validateValue(int value)
        {
            if (value > 0) return value;

            throw new SizeException("Size cant be lower than 0");
        }
    }
}
