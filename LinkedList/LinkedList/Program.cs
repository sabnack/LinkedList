using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = new LList<string>();
            n.Add("1");
            n.Add("2");
            n.Add("3");
            n.Add("4");
            n.Add("5");

            n.RemoveAt(3);

            foreach (var item in n)
            {
                Console.WriteLine(item);
            }
          
            //    Console.WriteLine(n.Next.Next.Data);
        }

    }
}
