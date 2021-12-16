using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    static class BTreePrinter
    {
        public static void Print(Node root, string text, ConsoleColor clr, int space)
        {
            if (root == null)
                return;

            for (int i = 0; i < space; i++)
                Console.Write(" ");

            Console.Write("└─");
            Console.ForegroundColor = clr;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(root.Data + "\n");

            space += 2;

            Print(root.LeftNode, "L:", ConsoleColor.Green, space);

            Print(root.RightNode, "R:", ConsoleColor.Red, space);

        }
    }
}