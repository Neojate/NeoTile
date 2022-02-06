using Microsoft.Xna.Framework;
using NeoTile.Objects;
using System.Collections.Generic;
using System.Linq;

namespace NeoTile.Worlds
{
    public class World
    {
        public Tile[,] Map { get; set; }

        public List<GameObject> GameObjects { get; set; }

        public List<GameObject> RemoveObjects { get; set; } = new List<GameObject>();

        public virtual void LoadWorld(string fileName)
        {

        }

        public virtual void SaveWorld(string fileName)
        {

        }

        public void DestroyRemovedObjects()
        {
            RemoveObjects.ForEach(element => GameObjects.Remove(element));
            RemoveObjects = new List<GameObject>();
        }

        public List<T> GetElements<T>() where T : GameObject
        {
            return GameObjects.Where(gameObject => gameObject is T).Cast<T>().ToList();
        }

        public Tile GetTile(Vector2 position)
        {
            return Map[(int)position.X, (int)position.Y];
        }

        public Tile GetTile(int x, int y)
        {
            return Map[x, y];
        }

        public bool IsInMap(Vector2 position)
        {
            return new Rectangle(0, 0, Map.GetLength(0), Map.GetLength(1)).Contains(position);
        }

        public bool IsInMap(int x, int y)
        {
            return IsInMap(new Vector2(x, y));
        }
    }
}
