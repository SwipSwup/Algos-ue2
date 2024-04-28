using System;
using System.Collections.Generic;
using System.IO;

namespace Algos_ue2
{
    public class BinaryTree
    {
        private int _size;

        public Node Root { get; private set; }

        /// <summary>
        /// Loads a binary tree from a file
        /// </summary>
        /// <param name="src">The path of the file</param>
        public void LoadTreeFromFile(string src)
        {   
            string[] lines = File.ReadAllLines(src);

            foreach (string line in lines)
                AddNode(int.Parse(line));
        }

        /// <summary>
        /// Adds a new node to the binary tree
        /// </summary>
        /// <param name="keyValue">The keyvalue to be added</param>
        public void AddNode(int keyValue)
        {
            if (Root == null)
            {
                Root = new Node(keyValue);
                _size++;

                return;
            }

            Node node = Root;

            while (node != null)
            {
                if (node.KeyValue == keyValue)
                    return;

                _size++;
                if (node.KeyValue > keyValue)
                {
                    if (node.LeftNode == null)
                    {
                        node.LeftNode = new Node(keyValue);

                        return;
                    }

                    node = node.LeftNode;
                }
                else
                {
                    if (node.RightNode == null)
                    {
                        node.RightNode = new Node(keyValue);
                        return;
                    }

                    node = node.RightNode;
                }
            }
        }

        /// <summary>
        /// Calculates the height
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns></returns>
        private int CalculateHeight(Node node)
        {
            if (node == null)
                return 0;

            int leftHeight = CalculateHeight(node.LeftNode);
            int rightHeight = CalculateHeight(node.RightNode);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        /// <summary>
        /// Calculates the balance of the tree
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns></returns>
        private int Balance(Node node)
        {
            if (node == null)
                return 0;

            int leftHeight = CalculateHeight(node.LeftNode);
            int rightHeight = CalculateHeight(node.RightNode);

            return rightHeight - leftHeight;
        }

        /// <summary>
        /// Checks if the tree is a AVL tree, via AVL violations
        /// </summary>
        /// <param name="node">Node</param>
        /// <param name="isAVL">Check if the tree is AVL</param>
        private void IsAVLTree(Node node, ref bool isAVL)
        {
            if (node == null)
                return;

            int balanceFactor = Balance(node);


            // Check for AVL violation
            if (balanceFactor > 1 || balanceFactor < -1)
            {
                Console.WriteLine($"bal({node.KeyValue}) = {balanceFactor} (AVL violation!)");
                isAVL = false;
            }
            else
            {
                // Print balance factor for current node
                Console.WriteLine($"bal({node.KeyValue}) = {balanceFactor}");
            }

            // Recursively check left and right subtrees
            IsAVLTree(node.LeftNode, ref isAVL);
            IsAVLTree(node.RightNode, ref isAVL);
        }
        
        public bool IsAVL()
        {
            bool isAVL = true;
            IsAVLTree(Root, ref isAVL);
            return isAVL;
        }

        /// <summary>
        /// Checks if the tree is AVL valid and prints the result
        /// </summary>
        public void ValidateAVL()
        {
            bool isAVL = IsAVL();

            if (isAVL)
                Console.WriteLine("AVL: yes");
            else
                Console.WriteLine("AVL: no");
        }

        /// <summary>
        /// Looks for the smallest keyvalue in the tree
        /// </summary>
        /// <param name="node">The node from which the search should start</param>
        /// <returns>The smallest keyvalue of the tree</returns>
        public int Min(Node node = null)
        {
            if (node == null)
                node = Root;

            if (node.LeftNode == null)
                return node.KeyValue;

            return Min(node.LeftNode);
        }

        /// <summary>
        /// Looks for the biggest keyvalue in the tree
        /// </summary>
        /// <param name="node">The node from which the search should start</param>
        /// <returns>The biggest keyvalue of the tree</returns>
        public int Max(Node node = null)
        {
            if (node == null)
                node = Root;

            if (node.RightNode == null)
                return node.KeyValue;

            return Max(node.RightNode);
        }

        /// <summary>
        /// Checks if Node is there else adds the keyvalue to the node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns></returns>
        private float CalcSumRec(Node node)
        {
            if (node == null)
                return 0;

            float sum = node.KeyValue;

            if (node.LeftNode != null)
                sum += CalcSumRec(node.LeftNode);

            if (node.RightNode != null)
                sum += CalcSumRec(node.RightNode);

            return sum;
        }

        /// <summary>
        /// Calculates the the avarage of all keyvalues
        /// </summary>
        /// <returns>The avarage of keyvalues</returns>
        public float Avg()
        {
            if (Root == null)
                return 0;

            return CalcSumRec(Root) / (_size + 1);
        }

        /// <summary>
        /// Searches for a specific key value and prints the result
        /// </summary>
        /// <param name="keyValue">The value to search for</param>
        public void SearchKeyValue(int keyValue)
        {
            List<int> steps = new List<int>();
            Node node = SearchKeyValueInternal(keyValue, Root, ref steps);

            if (node == null)
            {
                Console.WriteLine($"{keyValue} not found");
                return;
            }

            Console.WriteLine($"{keyValue} found {string.Join(", ", steps)}");
        }

        /// <summary>
        /// Overload of helper function without the steps. Returns null if the key value doesnt exist
        /// </summary>
        /// <param name="keyValue">The value to look for</param>
        /// <param name="node">The node to start the search</param>
        /// <returns>The Node of the keyValue</returns>
        private Node SearchKeyValueInternal(int keyValue, Node node)
        {
            List<int> ignored = new List<int>();

            return SearchKeyValueInternal(keyValue, node, ref ignored);
        }

        /// <summary>
        /// Internal helper function to search for the key value. Returns null if the key value doesnt exist
        /// </summary>
        /// <param name="keyValue">The value to look for</param>
        /// <param name="node">The node to start the search</param>
        /// <param name="steps">The steps that the algorithm took</param>
        /// <returns>The Node of the keyValue</returns>
        private Node SearchKeyValueInternal(int keyValue, Node node, ref List<int> steps)
        {
            if ( node == null)
            {
                return null;
            }

            /*if ((node.LeftNode != null || node.LeftNode!.KeyValue > keyValue) &&
                (node.RightNode != null || node.RightNode!.KeyValue < keyValue))
            {
                return null;
            }*/

            if (node.KeyValue == keyValue)
            {
                steps.Add(node.KeyValue);
                return node;
            }

            steps.Add(node.KeyValue);
            return SearchKeyValueInternal(keyValue, keyValue < node.KeyValue ? node.LeftNode : node.RightNode,
                ref steps);
        }

        /// <summary>
        /// Searches the tree for a specific subtree
        /// </summary>
        /// <param name="subtree">The nodes to look for</param>
        /// <param name="node">The node to start the search</param>
        /// <param name="index">Index for the subtree array</param>
        public void SearchSubTree(int[] subtree, Node node = null, int index = 0)
        {
            if (index != 0 && node == null)
            {
                Console.WriteLine("Subtree not found");
                return;
            }

            if (subtree.Length == index)
            {
                Console.WriteLine("Subtree found");
                return;
            }

            SearchSubTree(subtree, SearchKeyValueInternal(subtree[index++], node ?? Root), index);
        }
    }
}