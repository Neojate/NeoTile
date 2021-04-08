
using Microsoft.Xna.Framework;
using NeoTile.Worlds;
using System;
using System.Collections.Generic;

namespace NeoTile.Physics.Raycast
{
    public class RayCasting
    {
        public RayObject CheckPath(Vector2 start, Vector2 end, Tile[,] map)
        {
            //El buen algoritmo de Bresenham
            RayObject rayObject = new RayObject();

            int dX = (int)end.X - (int)start.X;
            int dY = (int)end.Y - (int)start.Y;

            Vector2 step = Vector2.One;

            if (dY < 0)
            {
                dY *= -1;
                step.Y = -1;
            }

            if (dX < 0)
            {
                dX *= -1;
                step.X = -1;
            }

            Vector2 temp = start;

            int p, incE, incNE;

            if (dX > dY)
            {
                p = 2 * dY - dX;
                incE = 2 * dY;
                incNE = 2 * (dY - dX);

                while (temp.X != (int)end.X)
                {
                    temp.X += step.X;
                    if (p < 0)
                    {
                        p += incE;
                    }
                    else
                    {
                        temp.Y += step.Y;
                        p += incNE;
                    }
                    rayObject.LinePositions.Add(temp);

                    if (map[(int)temp.X, (int)temp.Y].StopVision)
                    {
                        rayObject.HasCollision = true;
                        break;
                    }
                    
                }

            }
            else
            {
                p = 2 * dX - dY;
                incE = 2 * dX;
                incNE = 2 * (dX - dY);

                while (temp.Y != (int)end.Y)
                {
                    temp.Y += step.Y;
                    if (p < 0)
                    {
                        p += incE;
                    }
                    else
                    {
                        temp.X += step.X;
                        p += incNE;
                    }
                    rayObject.LinePositions.Add(temp);

                    if (map[(int)temp.X, (int)temp.Y].StopVision)
                    {
                        rayObject.HasCollision = true;
                        break;
                    }

                }

            }

            return rayObject;
        }

    }

    public class RayObject
    {
        public bool HasCollision { get; set; } = false;

        public List<Vector2> LinePositions { get; set; } = new List<Vector2>();
    }
}
