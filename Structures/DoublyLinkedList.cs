using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class DoublyLinkedList
    {
        private DoublyNode _head;

        public DoublyLinkedList()
        {
            _head = null;
        }

        public void AddToStart(int value)
        {
            var newNode = new DoublyNode
            {
                Value = value,
                Next = _head,
                Previous = null
            };

            if (_head != null)
            {
                _head.Previous = newNode;
            }

            _head = newNode;
        }

        public void AddToEnd(int value)
        {
            var newNode = new DoublyNode
            {
                Value = value,
                Next = null,
                Previous = null
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

            newNode.Previous = currentNode;
            currentNode.Next = newNode;
        }

        public void Remove(int value)
        {
            if (_head != null && _head.Value == value)
            {
                _head = _head.Next;
                return;
            }

            var previousNode = _head;
            var currentNode = _head.Next;

            while (currentNode != null && currentNode.Value != value)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (currentNode != null && currentNode.Value == value)
            {
                previousNode.Next = currentNode.Next;

                if (currentNode.Next != null)
                {
                    currentNode.Next.Previous = previousNode;
                }
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

    public class DoublyNode
    {
        public int Value { get; set; }

        public DoublyNode Next { get; set; }

        public DoublyNode Previous { get; set; }
    }
}
