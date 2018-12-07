using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node<T>
    {
        public T Data;
        public Node<T> Next;
        public Node<T> Prev;
        public int Index;

        public Node(T data)
        {
            Data = data;
            Index = 0;
            Next = null;
            Prev = null;
        }

        public void Add(T data, Node<T> headNode)
        {
            if (headNode.Next == null)
            {
                headNode.Next = new Node<T>(data)
                {
                    Prev = headNode
                };
                headNode.Next.Index = Index + 1;
            }
            else
            {
                headNode.Next.Add(data, headNode.Next);
                headNode.Next.Index = Index + 1;
            }
        }
    }
}
