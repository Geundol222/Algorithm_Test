namespace _10._ShortestPath
{
    internal class Program
    {
        const int INF = 99999;          // Max 값을 넣게 되면, 만약 INF에 더하는 경우가 있을 경우 오버플로우가 날 수 있으므로 충분히 크지만 최대값은 아닌 값을 저장한다.

        static void ShortestPath(int[,] graph, int start, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0);      // 그래프의 길이로 size를 저장한다. 그래프에서는 0과 1의 길이가 같으므로 아무 길이나 넣어주어도 된다.
            bool[] visited = new bool[size];    // 해당 노드가 방문 되었는지를 확인하기 위해 visited 변수를 선언한다.

            distance = new int[size];           // distance와 path를 초기화한다.
            path = new int[size];
            for (int i = 0; i < size; i++)
            {
                distance[i] = graph[start, i];
                path[i] = graph[start, i] < INF ? start : -1;
            }

            for (int i = 0; i < size; i++)
            {
                int next = -1;                  // 탐색할 노드의 인덱스를 저장할 next 변수
                int minCost = INF;              // 탐색 가능한 노드 가중치 중 최소 값을 저장할 minCost변수 즉, 가장 가까운 경로를 저장할 변수
                // 1. 탐색해보지 않았고, 가장 가까운 정점 탐색
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] && distance[j] < minCost)       // 만약 방문한 적이 없고 경로가 minCost보다 작다면 가장 가까운 경로라는 의미
                    {
                        next = j;                                   // 가장 가까운 경로를 찾았다면 그 경로의 인덱스를 저장한다.
                        minCost = distance[j];                      // 가장 가까운 경로를 찾았다면 그 경로의 가중치를 저장한다.
                    }
                }
                if (next < 0)          // 만약 다음 찾아갈 인덱스가 0보다 작으면 다음이 없다는 의미이므로 반복문을 종료한다.
                    break;

                // 2. 직접 가는 거리보다 거쳐서 가는 것이 더 짧다면 갱신
                for (int j = 0; j < size; j++)
                {
                    if (distance[j] > distance[next] + graph[next, j])  // 직접 가는 경로보다, 거쳐서 가는 경로가 더 짧다면,
                    {
                        distance[j] = distance[next] + graph[next, j];  // 거쳐서가는 경로를 해당경로의 길이로 하고 거쳐서 가게될 인덱스를 path에 저장한다.
                        path[j] = next;
                    }
                }
                visited[next] = true;   // 모든 과정이 종료되었으면 해당 경로는 탐색한 것이 되므로 중복 탐색을 막기 위해 visited를 true로 한다.
            }
        }

        static void Main(string[] args)
        {
            int[,] graph = new int[5, 5]
            {
                {   0, INF,   3,   4, INF },
                {   8,   0, INF,   8, INF },
                {   3, INF,   0,   5, INF },
                { INF,   3,   2,   0, INF },
                { INF, INF, INF, INF,   0 },
            };

            int[] distance;
            int[] path;
            ShortestPath(graph, 0, out distance, out path);
            PrintDijkstra(distance, path);                      // 프린트는 교수님이 하신 것 가져왔습니다.
        }

        private static void PrintDijkstra(int[] distance, int[] path)
        {
            Console.Write("Vertex");
            Console.Write("\t");
            Console.Write("dist");
            Console.Write("\t");
            Console.WriteLine("path");

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write("{0,3}", i);
                Console.Write("\t");
                if (distance[i] >= INF)
                    Console.Write("INF");
                else
                    Console.Write("{0,3}", distance[i]);
                Console.Write("\t");
                if (path[i] < 0)
                    Console.WriteLine("  X ");
                else
                    Console.WriteLine("{0,3}", path[i]);
            }
        }
    }
}