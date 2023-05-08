using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class AStar
    {
        const int CostStraight = 10;
        const int CostDiagonal = 14;

        static Point[] Direction =
        {
            new Point(0, +1),
            new Point(0, -1),
            new Point(-1, 0),
            new Point(+1, 0),
        };

        public static bool PathFinding(bool[,] tileMap, Point start, Point end, out List<Point> path)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            bool[,] visited = new bool[ySize, xSize];
            ASNode[,] nodes = new ASNode[ySize, xSize];
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

           
            ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end));
            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f);

            while (nextPointPQ.Count > 0)
            {
                ASNode nextNode = nextPointPQ.Dequeue();

                visited[nextNode.point.y, nextNode.point.x] = true;

                if (nextNode.point.x == end.x && nextNode.point.y == end.y)
                {
                    Point? pathPoint = end;
                    path = new List<Point>();

                    while (pathPoint != null)
                    {
                        Point point = pathPoint.GetValueOrDefault();
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;
                    }

                    path.Reverse();
                    return true;
                }

                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y;

                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    else if (tileMap[y, x] == false)
                        continue;
                    else if (visited[y, x])
                        continue;

                    int g = nextNode.g + CostStraight;
                    int h = Heuristic(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

                    if (nodes[y, x] == null || nodes[y, x].f > newNode.f)
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }
            path = null;
            return false;
        }


        private static int Heuristic(Point start, Point end)
        {
            int xSize = Math.Abs(start.x - end.x);
            int ySize = Math.Abs(start.y - end.y);
            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }

        private class ASNode
        {
            public Point point;   
            public Point? parent; 

            public int f;         
            public int g;         
            public int h;         

            public ASNode(Point point, Point? parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }
    }
}
