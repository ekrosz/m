using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class BinaryTree
    {
        public BinaryNode _root;

        public BinaryTree()
        {
            _root = null;
        }

        private void AddNode(BinaryNode root, int value)
        {
            if (value >= root.Value && root.Right != null)
            {
                AddNode(root.Right, value);
                return;
            }
            else if (value >= root.Value && root.Right == null)
            {
                root.Right = new BinaryNode
                {
                    Value = value,
                    Right = null,
                    Left = null
                };
                return;
            }

            if (value < root.Value && root.Left != null)
            {
                AddNode(root.Left, value);
                return;
            }
            else if (value < root.Value && root.Left == null)
            {
                root.Left = new BinaryNode
                {
                    Value = value,
                    Right = null,
                    Left = null
                };
                return;
            }
        }

        public void Add(int value)
        {
            var newNode = new BinaryNode
            {
                Value = value,
                Left = null,
                Right = null
            };

            if (_root == null)
            {
                _root = newNode;
                return;
            }

            AddNode(_root, value);
        }

        private void SearchNode(BinaryNode root, int value)
        {
            if (root.Value == value)
            {
                Console.WriteLine("Value is exist.");
            }

            if (value > root.Value && root.Right != null)
            {
                SearchNode(root.Right, value);
            }
            else if (value > root.Value && root.Right == null)
            {
                Console.WriteLine("Value not found.");
            }

            if (value < root.Value && root.Left != null)
            {
                SearchNode(root.Left, value);
            }
            else if (value < root.Value && root.Left == null)
            {
                Console.WriteLine("Value not found.");
            }
        }

        public void Search(int value)
        {
            if (_root == null)
            {
                Console.WriteLine("Binary tree is empty");
                return;
            }

            SearchNode(_root, value);
        }

        private void DisplayNode(BinaryNode root)
        {
            if (root != null)
            {
                Console.WriteLine($"Root {root.Value}: Left {root.Left?.Value}; Right {root.Right?.Value}");

                DisplayNode(root.Left);
                DisplayNode(root.Right);
            }
        }

        public void Display()
        {
            if (_root == null)
            {
                Console.WriteLine("Binary tree is emmpty.");
                return;
            }

            DisplayNode(_root);
        }
    }

    public class BinaryNode
    {
        public int Value { get; set; }

        public BinaryNode Right { get; set; }

        public BinaryNode Left { get; set; }
    }
}
