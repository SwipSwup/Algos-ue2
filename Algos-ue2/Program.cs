using System;

namespace Algos_ue2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            tree.LoadTreeFromFile("../../resources/tree3.txt");

            BTreePrinter.Print(tree.Root, "(0)", 2);

            Console.WriteLine("Searching for key value 23:");
            Node result = tree.SearchKeyValue(23, tree.Root);
            if (result != null)
                BTreePrinter.Print(result, "(0)", 2);

            Console.WriteLine($"The maximum value in the tree is: {tree.Max()}");
            Console.WriteLine($"The minimum value in the tree is: {tree.Min()}");
            Console.WriteLine($"The average value in the tree is: {tree.Avg()}");

            tree.ValidateAVL();

            Console.ReadLine();
        }
    }
}