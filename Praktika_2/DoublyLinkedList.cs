using System;
using System.Threading;

namespace Praktika_2
{
    public class DoublyLinkedList
    {
        private DoublyNode _head;

        public DoublyLinkedList()
        {
            _head = null;
        }

        public void Push(Person person)
        {
            if (_head == null)
            {
                _head = new DoublyNode
                {
                    Next = null,
                    Person = person
                };
                return;
            }

            var currentNode = _head;
            var previousNode = _head.Previous;

            while (currentNode != null && currentNode.Person.Age < person.Age)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                var node = new DoublyNode
                {
                    Previous = previousNode,
                    Person = person
                };

                previousNode.Next = node;

                return;
            }

            var newNode = new DoublyNode
            {
                Next = currentNode,
                Previous = previousNode,
                Person = person
            };

            if (previousNode != null)
            {
                previousNode.Next = newNode;
            }
            else
            {
                _head = newNode;
            }

            currentNode.Previous = newNode;
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

    public class DoublyNode
    {
        public DoublyNode Next { get; set; }

        public DoublyNode Previous { get; set; }

        public Person Person { get; set; }
    }
}
