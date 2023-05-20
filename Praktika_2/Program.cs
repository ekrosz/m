using System;
using System.Collections.Generic;

namespace Praktika_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyLinkedList();

            myList.Display();
            myList.PushBack(new Person { Name = "Петя", Age = 20 });
            myList.PushBack(new Person { Name = "Вова", Age = 35 });
            myList.PushBack(new Person { Name = "Паша", Age = 22 });
            myList.Display();

            Console.WriteLine("///////////////////////////////////");

            var systemList = new SystemLinkedList();

            systemList.Display();
            systemList.Add(new Person { Name = "Петя", Age = 20 });
            systemList.Add(new Person { Name = "Вова", Age = 35 });
            systemList.Add(new Person { Name = "Паша", Age = 22 });
            systemList.Display();

            Console.WriteLine("///////////////////////////////////");

            var doublyList = new DoublyLinkedList();

            doublyList.Display();
            doublyList.Push(new Person { Name = "Вова", Age = 35 });
            doublyList.Push(new Person { Name = "Петя", Age = 20 });
            doublyList.Push(new Person { Name = "Паша", Age = 22 });
            doublyList.Push(new Person { Name = "Ян", Age = 40 });
            doublyList.Push(new Person { Name = "Артем", Age = 30 });
            doublyList.Push(new Person { Name = "Дима", Age = 18 });
            doublyList.Display();
        }
    }
}
