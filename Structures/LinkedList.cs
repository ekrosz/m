using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class LinkedList
    {
        private Node _head;

        public LinkedList()
        {
            _head = null;
        }

        public void AddToStart(int value)
        {
            var newNode = new Node
            {
                Value = value,
                Next = _head
            };

            _head = newNode;
        }

        public void AddToEnd(int value)
        {
            var newNode = new Node
            {
                Value = value,
                Next = null
            };

            if (_head == null)
            {
                _head = newNode;
                return;
            }

            var currentNode = _head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = newNode;
        }

        public void Remove(int value)
        {
            if (_head != null && _head.Value == value)
            {
                _head = _head.Next;
                return;
            }

            var currentNode = _head;

            while (currentNode.Next != null && currentNode.Next.Value != value)
            {
                currentNode = currentNode.Next;
            }

            if (currentNode.Next != null && currentNode.Next.Value == value)
            {
                currentNode.Next = currentNode.Next.Next;
            }
        }

        public void Display()
        {
            if (_head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            var currentNode = _head;

            while (currentNode != null)
            {
                Console.Write($"{currentNode.Value} ");
                currentNode = currentNode.Next;
            }

            Console.Write($"\n");
        }
    }

    public class Node
    {
        public int Value { get; set; }

        public Node Next { get; set; }
    }
}
