using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }
    }
    class BinaryTree
    {
        public Node Root { get; set; }


        public bool Add(int value)
        {
            Node before = null, after = Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data)
                    after = after.LeftNode;
                else if (value > after.Data)
                    after = after.RightNode;
                else
                    return false;
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (Root == null)
                Root = newNode;
            else
            {
                if (value < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        private int MinValue(Node node)
        {
            int minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        //
        public Node Find(int value)
        {
            return this.Find(value, this.Root);
        }

        private Node Find(int value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Data) return parent;
                if (value < parent.Data)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }
        //
        
        //
        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }

        private Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data)
                parent.RightNode = Remove(parent.RightNode, key);

            else
            {
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }
        //

        //
        public int GetTreeDepth()
        {
            return this.GetTreeDepth(Root);
        }

        private int GetTreeDepth(Node parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }
        //

        public void AddRandom()
        {
            Console.WriteLine("Введите количество элементов которое необходимо добавить: ");
            int number = int.Parse(Console.ReadLine());
            Random random = new Random();
            for (int i = 0; i < number; i++)
                this.Add(random.Next(-100, 100));
        }
    }
}