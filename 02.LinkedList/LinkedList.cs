using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LinkedList<T>
    {
        private LinkedListNode<T> head; //맨 앞노드
        private LinkedListNode<T> tail; //맨 뒷노드
        private int count; 

        public LinkedList()
        {
            count = 0;
            head = null;
            tail = null;
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> newnode = new LinkedListNode<T> (value); //우선 값을 저장할 새 노드 생성
            //AddBefore(head, newnode);
            InsertNodeBefore(head, newnode);
            return newnode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node,T value)
        {
            LinkedListNode<T> newnode = new LinkedListNode<T>(value); //우선 값을 저장할 새 노드 생성
            InsertNodeBefore(node, newnode); //연산자체는 앞에 붙이는것과 뒤에 붙이는것이 크게 다르지 않음
            return newnode;
        }

        private void InsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
           
            // <연결리스트 삽입>
            // 새로 추가하는 노드가 이전/이후 노드를 참조한 뒤
            // 이전/이후 노드가 새로 추가하는 노드를 참조함
            // 
            //          ┌─┬───┬─┐                        ┌─┬────┬─┐                      ┌─┬────┬─┐ 
            //          │ │new│ │                      ┌───│new │───┐                  ┌───│new │───┐
            //          └─┴───┴─┘          =>          ↓ └─┴────┴─┘ ↓         =>       ↓ └─┴────┴─┘ ↓
            // ┌─┬────┬─┐         ┌─┬────┬─┐    ┌─┬────┬─┐         ┌─┬───┬─┐    ┌─┬────┬─┐ ↑     ↑ ┌─┬────┬─┐
            // │ │prev│←───────────→│next│ │    │ │prev│←─────────→ │next│ │    │ │prev│───┘     └───│next│ │
            // └─┴────┴─┘         └─┴────┴─┘    └─┴────┴─┘         └─┴───┴─┘    └─┴────┴─┘         └─┴────┴─┘
            LinkedListNode<T> prevNode = node.prev;

            // 1.newnode의 prev를 node의 prev로
            newNode.prev = prevNode;

            // 2.newnode의 next는 node로
            newNode.next = node;

            // 3.node 앞의 유무에 따라 
            if(node == head)
            {
                head = newNode; //head 를 newNode로
            }
            else
            {
                prevNode.next = newNode; //node의 prev를 newNode로
            }

            // 4.node의 prev를 newnode의 next로
            node.prev = newNode;
            count++;
        }
    }


    public class LinkedListNode<T>
    {
        private T value; //Data 값

        public LinkedListNode<T> prev; //어디에 연결되있는지 참조 변수
        public LinkedListNode<T> next;

        public LinkedListNode(T value)
        {
            this.value = value;
            this.prev = null;
            this.next = null;
        }
        public LinkedListNode(T value, LinkedListNode<T> prev, LinkedListNode<T> next)
        {
            this.value = value;
            this.prev = prev;
            this.next = next;
        }


        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get {  return next; } }

        public T Value { get { return value; } set { this.value = value; } }
    }
}
