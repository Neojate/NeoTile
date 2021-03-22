
namespace NeoTile.World
{
    public class Scene
    {
        public Tile[,] Map { get; set; }

        public void Draw()
        {
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    Map[x, y].Render();
                }
            }
        }
    }
}
