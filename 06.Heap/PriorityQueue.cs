using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
     class PriorityQueue<TElement, TPriority> where TPriority:IComparable<TPriority>
    {
        private struct Node // 배열 기반으로 구현할 것이라 Node를 구조체로 만들어줌
        {
            public TElement element;
            public TPriority priority;

            public Node(TElement element, TPriority priority)
            {
                this.element= element;
                this.priority = priority;
            }
        }
        private List<Node> nodes; //Node를 리스트(배열)로 가짐

        public PriorityQueue()
        {
            nodes = new List<Node>();
        }

        public void Enqueue(TElement element, TPriority priority)
        {
            Node newNode = new Node(element, priority);

            //일단 가장 뒤에 추가
            nodes.Add(newNode);
            int index = nodes.Count-1; // 가장 마지막 위치 반환

            //최상단에 도착하기 전까지 반복하여 비교
            while(index > 0)
            {
                int parentIndex = (index - 1) / 2;
                Node parentNode = nodes[parentIndex]; //부모노드의 인덱스를 구하고 그 값을 봄
                if (newNode.priority.CompareTo(parentNode.priority) < 0) //새 노드가 더 작은경우
                {
                    nodes[index] = parentNode;
                    nodes[parentIndex] = newNode;
                    index= parentIndex; //상승
                }
                else
                {
                    break; 
                }
            }
            //상승작업 완료후 삽입
            nodes[index] = newNode;
        }
        public TElement Dequeue()
        {
            Node rootNode = nodes[0];

            //제거잡업
            Node lastNode = nodes[nodes.Count-1];
            nodes[0] = lastNode;
            nodes.RemoveAt(nodes.Count - 1);

            int index = 0;
            while(index < nodes.Count)
            {
                int leftIndex = 2 * index + 1;
                int rightIndex = 2 * index + 2;
               
                if (rightIndex < nodes.Count)//양쪽 다 자식이 있을 때
                {
                    int lessIndex;

                    if (nodes[leftIndex].priority.CompareTo(nodes[rightIndex].priority)<0 ) //둘다 있는 경우
                      {
                        lessIndex = leftIndex;
                    }
                    else
                    {
                        lessIndex = rightIndex;
                    }

                    Node lessNode = nodes[lessIndex];
                    if (nodes[index].priority.CompareTo(lessNode.priority) < 0)
                    {
                        nodes[lessIndex] = lastNode;
                        nodes[index] = lessNode;
                        index = lessIndex;
                    }
                    else
                    {
                        break;
                    }
                }else if(leftIndex < nodes.Count) // 자식이 하나만 있을 때
                {
                    Node leftNode = nodes[leftIndex];
                    if (nodes[index].priority.CompareTo(nodes[leftIndex].priority) > 0)
                    {
                        nodes[leftIndex] = lastNode;
                        nodes[index] = leftNode;
                        index = leftIndex;          
                    }
                }
                else
                {
                    break;
                }
  
            }
            return rootNode.element;
        }

    }
}
