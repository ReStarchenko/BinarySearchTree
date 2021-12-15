using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class Menu
    {
        static int index = 0;
        public BinaryTree Instance { get; set; }
        public List<Option> Options { get; }

        public Menu(List<Option> options)
        { 
            Options = options;
        }

        public void MenuHandler()
        {
            WriteMenu(Options, Options[index]);

            ConsoleKeyInfo keyinfo;

            do
            {

                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < Options.Count)
                        index++;
                    else index = 0;

                    WriteMenu(Options, Options[index]);
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                        index--;
                    else index = Options.Count - 1;

                    WriteMenu(Options, Options[index]);
                }
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    do
                    {
                        Console.Clear();

                        Options[index].Selected.Invoke();

                        Console.WriteLine("\nНажмите [Esc] чтобы вернуться, [AnyKey] => продолжить");
                        keyinfo = Console.ReadKey();

                        if (keyinfo.Key == ConsoleKey.Escape)
                            break;
                    }
                    while (true);

                    index = 0;
                    WriteMenu(Options, Options[index]);
                }
            }
            while (true);
        }
        public static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
    }
    public class Option
    {
        public string Name { get; }
        public Action Selected { get; set; }

        public Option(string Name, Action Selected)
        {
            this.Name = Name;
            this.Selected = Selected;
        }
    }
}