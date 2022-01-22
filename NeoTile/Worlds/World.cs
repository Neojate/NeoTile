
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

    }
}
