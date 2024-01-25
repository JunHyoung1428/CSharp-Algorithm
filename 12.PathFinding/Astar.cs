using System.Security.AccessControl;

namespace _12.PathFinding
{

    /************************************************************
      * A* 알고리즘
      * 
      * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
      * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
      * 
      다익스트라 -> 가장 가까운 경로 (g(x) 만을 계산.)
      A*         -> 가장 예상 가중치가 높은 경로 선택 , f(x) =  기존의 g(x)에다가 + 휴리스틱값인 h(x)
      ************************************************************/
    internal class Astar
    {
        const int CostStraight = 10;
        const int CostDiagonal = 14;

        static Point[] Direction =
        {   //          x   y
            new Point(  0, +1 ),            // 상
            new Point(  0, -1 ),            // 하
            new Point( -1,  0 ),            // 좌
            new Point( +1,  0 ),            // 우
            new Point( -1, +1 ),            // 좌상
            new Point( -1, -1 ),            // 좌하
            new Point( +1, +1 ),            // 우상
            new Point( +1, -1 )             // 우하
        };

        public static bool PathFinding(in bool[,] tileMap, in Point start, in Point end, out List<Point> path)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);
            ASNode[,] nodes = new ASNode[ySize, xSize];
            bool[,] visited = new bool[ySize, xSize]; //순서 유의할 것
            PriorityQueue<ASNode,int> pq = new PriorityQueue<ASNode,int>();

            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, new Point(), 0, Heuristic(start,end));
            nodes[startNode.point.y, startNode.point.x] = startNode;
            pq.Enqueue(startNode,startNode.f);

            while (pq.Count > 0)
            {

                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = pq.Dequeue();

                // 2. 방문한 정점은 방문표시
                visited[nextNode.point.y, nextNode.point.x] = true;

                // 3. 다음으로 탐색할 정점이 도착지인 경우
                // 도착했다고 판단해서 경로 반환
                if (nextNode.point.x == end.x && nextNode.point.y == end.y)
                {
                    path = new List<Point>();

                    Point point = end;
                    while ((point.x == start.x && point.y == start.y) == false)
                    {
                        path.Add(point);
                        point = nodes[point.y, point.x].parent;
                    }
                    path.Add(start);
                    path.Reverse(); // 역순으로 뒤집어 시작~도착지점 순서로 만들어줌
                    return true;
                }
                // 4. AStar 탐색을 진행, 도착한 정점 주변의 점수 계산
                // 방향 탐색
                for (int i = 0; i < Direction.Length; i++)
                {
                    // Direction의 좌표를 더해서 상하좌우 대각선으로 이동 
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y;

                    // 4-1. 탐색하면 안되는 경우
                    // 맵을 벗어났을 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == false)
                        continue;
                    // 이미 방문한 정점일 경우
                    else if (visited[y, x])
                        continue;
                    // * 대각선으로 이동이 불가능 지역인 경우
                    else if (i >= 4 && tileMap[y, nextNode.point.x] == false && tileMap[nextNode.point.y, x] == false)
                        continue;

                    // 4-2. 탐색한 정점 만들기
                    int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal); //*
                    int h = Heuristic(new Point(x, y), end); //새로 휴리스틱 계산
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y, x] == null ||      // 탐색하지 않은 정점이거나
                        nodes[y, x].f > newNode.f)  // 가중치가 높은 정점인 경우
                    {
                        nodes[y, x] = newNode;
                        pq.Enqueue(newNode, newNode.f);
                    }
                }
            }
            path = null;
            return false;
        }



        // 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
        private static int Heuristic(Point start, Point end)
        {
            int xSize = Math.Abs(start.x -end.x); // 가로로 가야하는 횟수
            int ySize = start.y> end.y ?  start.y-end.y : end.y-start.y; // 세로로 가야하는 횟수

            // 맨해튼 거리 : 직선을 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            // return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);

            // 타일맵 거리 : 직선과 대각선을 통해 이동하는 거리
            int straightCount = Math.Abs(xSize - ySize);
            int diagonalCount = Math.Max(xSize, ySize) - straightCount;
            return CostStraight * straightCount + CostDiagonal * diagonalCount;
        }

        private class ASNode // struct
        {
            public Point point;     // 현재 정점 위치
            public Point parent;    // 이 정점을 탐색한 정점

            public int g;           // 현재까지의 값, 즉 지금까지 경로 가중치
            public int h;           // 앞으로 예상되는 값, 목표까지 추정 경로 가중치
            public int f;           // f(x) = g(x) + h(x);

            public ASNode(Point point, Point parent, int g, int h)
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

        public static bool operator == (Point right, Point left)
        {
            return right.x== left.x && right.y== left.y;
        }

        public static bool operator !=(Point right, Point left)
        {
            return right.x != left.x || right.y != left.y;
        }
    }
}




