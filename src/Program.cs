using System;
using System.Collections.Generic;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            Menu menu = new Menu(new List<Option>
            {
                new Option ("Добавить элемент", () => binaryTree.Add(int.Parse(Console.ReadLine()))),
                new Option ("Удалить элемент", () => binaryTree.Remove(int.Parse(Console.ReadLine()))),
                new Option ("Найти элемент", () => binaryTree.Find(int.Parse(Console.ReadLine()))),
                new Option ("Симметричный обход дерева", () => binaryTree.TraverseInOrder(binaryTree.Root)),
                new Option ("Добавить случайные элементы", () => binaryTree.AddRandom())

            });

            menu.MenuHandler();
        }

    }
}
