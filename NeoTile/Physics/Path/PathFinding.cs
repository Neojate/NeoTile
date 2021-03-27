
using Microsoft.Xna.Framework;
using NeoTile.World;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeoTile.Physics.Path
{
    public class PathFinding
    {
        private Node startNode, endNode, currentNode;
        private List<Node> openNodes = new List<Node>();
        private List<Node> closedNodes = new List<Node>();

        public List<Point> SearchPath(Point startPosition, Point endPosition, Tile[,] map)
        {
            startNode   = new Node(startPosition);
            endNode     = new Node(endPosition);

            openNodes.Add(startNode);

            while(openNodes.Count > 0)
            {
                currentNode = openNodes.OrderBy(node => node.F).First();

                openNodes.Remove(currentNode);
                closedNodes.Add(currentNode);

                if (currentNode.Position == endPosition)
                    break;

                foreach (Node neighbourdNode in currentNode.NeighbourNodes(map))
                {
                    if (closedNodes.FirstOrDefault(node => node.Position == neighbourdNode.Position) != null)
                        continue;

                    if (openNodes.FirstOrDefault(node => node.Position == neighbourdNode.Position) == null)
                    {
                        openNodes.Add(neighbourdNode);
                        neighbourdNode.Parent = currentNode;
                        neighbourdNode.CalculateFGH(startNode, endNode);
                    }
                    else
                    {
                        if (neighbourdNode.G < currentNode.G)
                        {
                            neighbourdNode.Parent = currentNode;
                            neighbourdNode.CalculateFGH(startNode, endNode);
                        }
                    }
                }
            }

            List<Point> finalPositions = new List<Point>();
            while(currentNode != null)
            {
                finalPositions.Add(currentNode.Position);
                currentNode = currentNode.Parent;
            }

            return finalPositions;
        }
    }
}
