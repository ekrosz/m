using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika_2
{
    public class MyLinkedList
    {
        private Node _head;

        public MyLinkedList()
        {
            _head = null;
        }

        public void PushForward(Person person)
        {
            if (_head == null)
            {
                _head = new Node
                {
                    Next = null,
                    Person = person
                };

                return;
            }

            var newHead = new Node()
            {
                Next = _head,
                Person = person
            };

            _head = newHead;
        }

        public void PushBack(Person person)
        {
            if (_head == null)
            {
                _head = new Node
                {
                    Next = null,
                    Person = person
                };

                return;
            }

            var currentNode = _head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = new Node()
            {
                Next = null,
                Person = person
            };
        }

        public void Display()
        {
            if (_head == null)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("List is empty");
                Console.WriteLine("-------------------------------------");
                return;
            }

            var currentNode = _head;

            while (currentNode != null)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Name: {currentNode.Person.Name}, Age: {currentNode.Person.Age}\n");
                Console.WriteLine("-------------------------------------");
                currentNode = currentNode.Next;
            }
        }
    }

    public class Node
    {
        public Node Next { get; set; }

        public Person Person { get; set; }
    }
}
