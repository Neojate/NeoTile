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
        public int H { get; set; }
        public int G { get; set; }

        public Node(Vector2 position)
        {
            this.Position = position;
        }

        public List<Node> NeighbourNodes(Tile[,] map)
        {
            List<Node> neighbourdNodes = new List<Node>();
            for (int y = -1; y < 2; y++)
                for (int x = -1; x < 2; x++)
                    if (!(x == 0 && y == 0) && !map[(int)Position.X + x, (int)Position.Y + y].IsBlock)
                        neighbourdNodes.Add(new Node(new Vector2(Position.X + x, Position.Y + y)));
            return neighbourdNodes;
        }

        public void CalculateFGH(Node startNode, Node endNode)
        {
            //distancia al nodo inicial
            G = Math.Abs((int)Position.X - (int)startNode.Position.X) + Math.Abs((int)Position.Y - (int)startNode.Position.Y);
            //distancia al nodo final
            H = Math.Abs((int)Position.X - (int)endNode.Position.X) + Math.Abs((int)Position.Y - (int)endNode.Position.Y);
            //sumatorio
            F = G + H;
        }
    }
}
