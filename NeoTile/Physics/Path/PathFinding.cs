
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

        public List<Vector2> SearchPath(Vector2 startPosition, Vector2 endPosition, Tile[,] map)
        {
            startNode = new Node(startPosition);
            endNode = new Node(endPosition);

            openNodes = new List<Node>();
            closedNodes = new List<Node>();

            openNodes.Add(startNode);

            while (openNodes.Count > 0)
            {
                currentNode = openNodes.OrderBy(node => node.F).First();

                openNodes.Remove(currentNode);
                closedNodes.Add(currentNode);

                if (currentNode.Position == endPosition)
                    break;

                foreach (Node neighbourNode in currentNode.NeighbourNodes(map))
                {
                    if (closedNodes.FirstOrDefault(n => n.Position == neighbourNode.Position) != null)
                        continue;

                    if (openNodes.FirstOrDefault(n => n.Position == neighbourNode.Position) == null)
                    {
                        openNodes.Add(neighbourNode);
                        neighbourNode.Parent = currentNode;
                        neighbourNode.CalculateFGH(startNode, endNode);
                    }
                    else
                    {
                        if (neighbourNode.G < currentNode.G)
                        {
                            neighbourNode.Parent = currentNode;
                            neighbourNode.CalculateFGH(startNode, endNode);
                        }
                    }
                }
            }

            List<Vector2> finalPositions = new List<Vector2>();
            while (currentNode != null)
            {
                finalPositions.Add(currentNode.Position);
                currentNode = currentNode.Parent;
            }
            return finalPositions;
        }
    }
}
