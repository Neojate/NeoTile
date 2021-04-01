
using NeoTile.Objects;
using System.Collections.Generic;

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

    }
}
