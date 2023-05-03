using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._PathFinding_Test
{
    internal class Astar
    {
        const int CostStraight = 10;
        const int CostDiagonal = 14;

        static Point[] Direction =
        {
            new Point(0, +1),	// 상
            new Point(0, -1),	// 하
            new Point(-1, 0),	// 좌
            new Point(+1, 0),	// 우
			new Point(-1, +1),	// 좌상
			new Point(-1, -1),	// 좌하
			new Point(+1, +1),	// 우상
			new Point(+1, -1),	// 우하
        };

        public static bool PathFinding(bool[,] tileMap, Point start, Point end, out List<Point> path)
        {
            // 초기화 진행
            int ySize = tileMap.GetLength(0);       // 타일맵은 가로와 세로의 길이가 다를 수 있으므로 각각 다른 값을 넣어준다.
            int xSize = tileMap.GetLength(1);

            bool[,] visited = new bool[ySize, xSize];
            ASNode[,] nodes = new ASNode[ySize, xSize];
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();
            
            ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end));       // 시작 노드 생성
            nodes[startNode.point.y, startNode.point.x] = startNode;                    // nodes에 시작 노드 값을 저장한다.
            nextPointPQ.Enqueue(startNode, startNode.f);                                // 시작 노드와 가중치 f를 우선순위 큐에 넣는다.

            while (nextPointPQ.Count > 0)
            {
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue();

                // 2. 방문한 정점은 방문 표시
                visited[nextNode.point.y, nextNode.point.x] = true;
                
                // 3. 탐색할 정점이 도착지인경우
                // 도착했다고 판단해서 경로반환
                if (nextNode.point.x == end.x && nextNode.point.y == end.y)             // 다음 노드의 x, y가 end의 x, y와 같을 경우
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

                // 4. Astar 탐색진행
                // 방향탐색
                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y;

                    // 4-1. 탐색하면 안되는 경우 제외
                    // 맵을 벗어났을 경우
                    if (x < 0 || x > xSize || y < 0 || y > ySize)
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == false)
                        continue;
                    // 이미 방문한 정점일 경우
                    else if (visited[y, x])
                        continue;

                    // 4-2. 점수계산
                    int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal);
                    int h = Heuristic(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
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

        public static int Heuristic(Point start, Point end)
        {
            int xSize = Math.Abs(start.x - end.x);
            int ySize = Math.Abs(start.y - end.y);

            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }

        public class ASNode
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

    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
