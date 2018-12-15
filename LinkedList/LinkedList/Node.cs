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
    }
}
