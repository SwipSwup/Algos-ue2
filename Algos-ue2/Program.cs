using System;

namespace Algos_ue2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            
            //Load tree from file
            tree.LoadTreeFromFile("../../resources/tree4.txt");

            // WICHTIG: Diese funktion wirft errors wenn das Konsolenfenster zu klein ist
            try
            {
                BTreePrinter.Print(tree.Root, "(0)", 2);
            }
            catch (Exception)
            {
                Console.WriteLine("Warning: Konsolenfenster zu klein um den Baum auszugeben");
            }
            
            Console.WriteLine("\n############# Stats #############");
            tree.ValidateAVL();
            Console.WriteLine($"min: {tree.Min()}, max: {tree.Max()}, avg: {tree.Avg()}");
            
            Console.WriteLine("\n########### Functions ###########");
            tree.SearchKeyValue(7);
            tree.SearchKeyValue(1);
            
            Console.WriteLine();
            tree.SearchSubTree(new []{5, 7});
            tree.SearchSubTree(new []{7, 2});
            
            Console.ReadLine();
        }
    }
}