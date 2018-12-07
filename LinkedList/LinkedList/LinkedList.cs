using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LList<T>:IEnumerable<T>
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
                HeadNode.Add(data, HeadNode);
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

        public IEnumerator<T> Enumerator()
        {
            var current = HeadNode;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
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

    }
}
