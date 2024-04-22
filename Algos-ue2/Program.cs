using System;

namespace Algos_ue2
{
    internal class Program
    {
        /*
         * TODO Einlesen und Aufbau des Baums (david)
         * TODO Rekursive Berechnung Balance (ivo)
         * TODO Rekursive Berechnung Min/Max/Avg (lukas)
         * TODO Rekursive Suche Schlüsselwert (ivo)
         * TODO Rekursive Suche Teilbaum (lukas)
         */

        public static void Main(string[] args)
        {
            BinaryTree tree = new();
            
            tree.LoadTreeFromFile("../../resources/tree1.txt");
            


            BTreePrinter.Print(tree.Root, "(0)", 2);

            BTreePrinter.Print(tree.SearchKeyValue(23, tree.Root), "(0)", 2);

            Console.WriteLine("Das minimum des Baumes ist: " + BinaryTree.Min(tree));
            Console.WriteLine("Das maximum des Baumes ist: " + BinaryTree.Max(tree));


            while (true)
            {
                
            }
        }
    }
}