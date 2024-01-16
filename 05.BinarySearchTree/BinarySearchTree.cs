using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _DataStructure
{
    class BinarySearchTree<T> where T : IComparable<T>
    {
        Node root;
        public BinarySearchTree()
        {
            this.root = null;
        }

        public bool Add(T item)
        {
            var newNode = new Node(item, null, null, null);

            if (this.root == null)
            {
                root = newNode;
                return true;
            }

            var current = root;
            while(current != null) 
            {
                if (item.CompareTo(current.item )< 0)
                {
                    //왼쪽 가는 경우
                    if (current.left == null)
                    {
                        //왼쪽 자식이 있는경우 계속 하강
                        current = current.left;
                    }
                    else
                    {
                        //왼쪽 자식이 없는 경우
                        current.left = newNode;
                        newNode.parent=current;
                        break;
                    }
                  
                }else if (item.CompareTo(current.item) > 0)
                {
                    //오른쪽 가는경우
                    if(current.right == null)
                    {
                        current = current.right;
                    }
                    else
                    {
                        current.right = newNode;
                        newNode.parent=current;
                        break;
                    }
                }
                else //Key가 같은 경우임으로, 추가 안함
                {
                    return false;
                }
                
            }

            return true;
        }

        public bool Remove(T item) 
        {

            return false; 
        }

        private Node FindNode(T item)
        {
            //root가 비었으면 애초에 아무것도 없는 것이므로
            if (root == null)
            {
                return null;
            }

            //root부터 순회
            Node current = root;
            while (current != null) 
            {
                if(item.CompareTo(current.item) < 0) //왼쪽으로 가는 경우
                {
                    current=current.left;
                }else if(item.CompareTo(current.item) > 0) //오른쪽으로 가는경우
                {
                    current = current.right;
                }
                else//똑같은 것을 발견함
                {
                    return current;
                }
            }
            return null;
        }
        private class Node
        {
            public T item;
            public Node parent;
            public Node left;
            public Node right;

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }


            public bool IsRootNode { get {return parent == null; }  }
            public bool IsLeftChild { get { return parent!=null&& parent.left == this; } }
            public bool IsRightChild { get { return parent!=null && parent.right == this; } }

            public bool HasNoChild { get { return left ==null & right == null; } }
            public bool HasLeftChild { get { return left != null; } }
            public bool HasRightChild { get { return right != null; } }
            public bool HasBothChild { get { return left != null && right !=null; } }
        }
    }

   
}
