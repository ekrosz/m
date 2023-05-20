using System;

namespace Structures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new DoublyLinkedList();

            //linkedList.Display();
            //linkedList.AddToEnd(1);
            //linkedList.AddToEnd(2);
            //linkedList.AddToStart(3);
            //linkedList.Display();
            //linkedList.Remove(2);
            //linkedList.Display();

            var binaryTree = new HashTable(10);

            binaryTree.Display();
            binaryTree.Add(5);
            binaryTree.Add(6);
            binaryTree.Add(6);
            binaryTree.Add(11);
            binaryTree.Add(3);
            binaryTree.Add(4);
            binaryTree.Add(8);
            binaryTree.Add(15);
            binaryTree.Add(26);
            binaryTree.Display();
            binaryTree.Add(5);
            binaryTree.Add(33);
            binaryTree.Add(101);
            binaryTree.Display();
            binaryTree.Remove(6);
            binaryTree.Remove(6);
            binaryTree.Display();
        }
    }
}
