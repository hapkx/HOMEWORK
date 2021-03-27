using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work1
{
    public class Node<T>  //链表节点
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> node = this.Head.Next;
            while (node != null)
            {
                action(node.Data);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0, max = int.MaxValue, min = int.MinValue;
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }

            Action<int> action = x => { if (x >= max) max = x; };
            action += x => { if (x >= max) max = x; };
            action += x => { sum += x; };

            intlist.ForEach(action);
            Console.WriteLine($"max: {max}; min: {min}; sum: {sum}");

        }
    }
}
