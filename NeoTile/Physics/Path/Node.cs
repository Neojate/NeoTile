using Microsoft.Xna.Framework;
using NeoTile.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoTile.Physics.Path
{
    public class Node
    {
        public Vector2 Position { get; set; }

        public Node Parent { get; set; }

        public int F { get; set; }
        public int G { get; set; }
        public int H { get; set; }

        public Node(Vector2 position)
        {
            Position = position;
        }

        public List<Node> NeighbourNodes(Tile[,] map)
        {
            List<Node> neighbourNodes = new List<Node>();

            for (int y = 0; y < 2; y++)
                for (int x = 0; x < 2; x++)
                    if (!(x == 0 && y == 0) && !map[(int)Position.X, (int)Position.Y].IsBlock)
                        neighbourNodes.Add(new Node(new Vector2(Position.X + x, Position.Y + y)));

            return neighbourNodes;
        }

        public void CalculateFGH(Node startNode, Node endNode)
        {
            G = Math.Abs((int)(Position.X - startNode.Position.X)) + Math.Abs((int)(Position.Y - startNode.Position.Y));

            H = Math.Abs((int)(Position.X - endNode.Position.X)) + Math.Abs((int)(Position.Y - endNode.Position.Y));

            F = G + H;
        }
    }
}
