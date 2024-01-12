using System;
using System.Collections.Generic;
using System.IO.Pipes;
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

        // 노드 삽입 구현
        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> newnode = new LinkedListNode<T> (value); //우선 값을 저장할 새 노드 생성
            //AddBefore(head, newnode);
            if(head == null) // head가 Null이면 빈 리스트에 그냥 노드를 집어넣기가 됨
            {
                InsertNodeToEmptyList(newnode);
            }
            else
            {
                InsertNodeBefore(head, newnode); 
            }
            
            return newnode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node,T value)
        {
            LinkedListNode<T> newnode = new LinkedListNode<T>(value); //우선 값을 저장할 새 노드 생성
            InsertNodeBefore(node, newnode); //연산자체는 앞에 붙이는것과 뒤에 붙이는것이 크게 다르지 않음
            return newnode;
        }

       public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newnode = new LinkedListNode<T>(value);
            if(tail == null)  //tail이 null이면 빈 리스트에 그냥 노드를 집어넣기가 됨
            {
                InsertNodeToEmptyList(newnode);
            }
            else
            {
                InsertNodeAfter(tail, newnode);
            }
            return newnode;
        }

        private void InsertNodeToEmptyList(LinkedListNode<T> newnode)
        {
            //리스트가 비어있을 때 이 연산 수행, 맨 첫 노드를 head와 tail로
            head = newnode;
            tail = newnode;
            count++;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node , T value)
        {
            LinkedListNode<T> newnode = new LinkedListNode<T>(value);
            InsertNodeAfter(node, newnode); 
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

        private void InsertNodeAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.prev = node;

            newNode.next = node.next;

            if(node == tail)
            {
                tail = newNode;
            }
            else
            {
                node.next.prev = newNode;
            }

            node.next= newNode;
            count++;
        }

        //노드 삭제 구현
        // <연결리스트 삭제>
        // 삭제하는 노드의 이전 노드가 이후 노드를 참조한 뒤
        // 삭제하는 노드의 이후 노드가 이전 노드를 참조함
        // 
        //          ┌─┬───┬─┐                      ┌─┬───┬─┐                      ┌─┬───┬─┐
        //        ┌──→│ C │←──┐                    │ │ C │←──┐                    │ │ C │ │
        //        │ └─┴───┴─┘ │        =>          └─┴───┴─┘ │        =>          └─┴───┴─┘
        // ┌─┬───┬│┐         ┌│┬───┬─┐    ┌─┬───┬─┐         ┌│┬───┬─┐    ┌─┬───┬─┐         ┌─┬───┬─┐
        // │ │ A │↓│         │↓│ B │ │    │ │ A │──────────→│↓│ B │ │    │ │ A │←───────────→│ B │ │
        // └─┴───┴─┘         └─┴───┴─┘    └─┴───┴─┘         └─┴───┴─┘    └─┴───┴─┘         └─┴───┴─┘

        public void RemoveNode(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("null node");
            }

            if (head == node)
                head = node.next;
            if(tail == node) 
                tail = node.prev;

            if (node.prev != null)
            {
                node.prev.next = node.next;
            }
            if(node.next != null)
            {
                node.next.prev = node.prev;
            }
            count--;
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> node = head;
            if (value == null)
            {
                while (node != null)
                {
                    if (null == node.Value)
                        return node;
                    else
                        node = node.next;
                }
            }
            else
            {
                while (node != null)
                {
                    if (value.Equals(node.Value))
                        return node;
                    else
                        node = node.next;
                }
            }
            return null;
        }
        

        public bool Remove(T value)
        {
            LinkedListNode<T> node = Find(value);
            //찾고 있으면 지우기
            if (node!=null){
                Remove(node);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Remove(LinkedListNode<T> node)
        {
            RemoveNode(node);
        }
        public void RemoveFirst()
        {
            RemoveNode(head);
        }

        public void RemoveLast()
        {
            RemoveNode(tail);
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
