
namespace NeoTile.World
{
    public class Tile : GameObject
    {
        public Size Size { get; set; } = TileOption.Size;

        public float Friction { get; set; } = TileOption.Friction;

        public bool IsBlock { get; set; } = false;



    }
}
