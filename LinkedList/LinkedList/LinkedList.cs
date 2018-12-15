using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LList<T>:IEnumerable
    {
        Node<T> HeadNode;

        public LList()
        {
            HeadNode = null;
        }

        public void Add(T data)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node<T>(data);
            }
            else
            {
                Add(data, HeadNode);
            }
        }

        public void Add(T data, Node<T> headNode)
        {
            if (headNode.Next == null)
            {
                headNode.Next = new Node<T>(data)
                {
                    Prev = headNode
                };
                headNode.Next.Index = headNode.Index + 1;
            }
            else
            {
                Add(data, headNode.Next);
                headNode.Next.Index = headNode.Index + 1;
            }
        }

        public void RemoveFirst()
        {
            HeadNode = HeadNode.Next;
            HeadNode.Prev = null;
            RebildIndex();
        }

        public void RemoveLast()
        {
            if (HeadNode!=null)
            {
                Remove(HeadNode);
            }
        }

        private void Remove(Node<T> headNode)
        {
            if (headNode.Next != null)
            {
                Remove(headNode.Next);
            }
            else
            {
                headNode.Prev.Next = null;
            }
        }

        public IEnumerator Enumerator()
        {
            var current = HeadNode;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void RebildIndex()
        {
            int i = 0;
            var current = HeadNode;
            while(current != null)
            {
                current.Index = i;
                i++;
                current = current.Next;
            }
        }

        public void RemoveAt(int index)
        {
            var current = HeadNode;
            while(current.Index != index)
            {
                current = current.Next;
            }
            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;
            RebildIndex();
        }

        public int Count()
        {
            var current = HeadNode;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Index + 1;
        }

    }
}
