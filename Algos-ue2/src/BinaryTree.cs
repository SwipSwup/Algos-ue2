using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Algos_ue2
{
    public class BinaryTree
    {
        private Node _root;
        private int _size;

        public Node Root => _root;

        public void LoadTreeFromFile(string src)
        {
            string[] lines = File.ReadAllLines(src);

            foreach (string line in lines)
                AddNode(int.Parse(line));
        }

        public void AddNode(int keyValue)
        {
            if (_root == null)
            {
                _root = new Node(keyValue);
                return;
            }

            Node node = _root;
            _size++;

            while (node != null)
            {
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

        private int CalculateHeight(Node node)
        {
            if (node == null)
                return 0;

            int leftHeight = CalculateHeight(node.LeftNode);
            int rightHeight = CalculateHeight(node.RightNode);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        private int Balance(Node node)
        {
            if (node == null)
                return 0;

            int leftHeight = CalculateHeight(node.LeftNode);
            int rightHeight = CalculateHeight(node.RightNode);

            return rightHeight - leftHeight;
        }

        private bool IsAVLTree(Node node)
        {
            if (node == null)
                return true;

            int balanceFactor = Balance(node);

            // Print balance factor for current node
            Console.WriteLine($"bal({node.KeyValue}) = {balanceFactor}");

            // Check for AVL violation
            if (balanceFactor > 1 || balanceFactor < -1)
            {
                Console.WriteLine($"bal({node.KeyValue}) = {balanceFactor} (AVL violation!)");
                return false;
            }

            // Recursively check left and right subtrees
            return IsAVLTree(node.LeftNode) && IsAVLTree(node.RightNode);
        }

        public bool IsAVL()
        {
            return IsAVLTree(_root);
        }

        public void ValidateAVL()
        {
            bool isAVL = IsAVL();

            if (isAVL)
                Console.WriteLine("AVL: yes");
            else
                Console.WriteLine("AVL: no");
        }

        public int Min(Node node = null)
        {
            if (node == null)
                node = _root;

            if (node.LeftNode == null)
                return node.KeyValue;

            return Min(node.LeftNode);
        }

        public int Max(Node node = null)
        {
            if (node == null)
                node = _root;

            if (node.RightNode == null)
                return node.KeyValue;

            return Max(node.RightNode);
        }

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

        public float Avg()
        {
            if (_root == null)
                return 0;

            return CalcSumRec(_root) / (_size + 1);
        }
        
        public float Balance(Node node)
        {
            //TODO IVO
            return 0;
        }

        public void SearchKeyValue(int keyValue)
        {
            Node node = SearchKeyValueInternal(keyValue, _root);

            if (node == null)
            {
                Console.WriteLine("Key value " + keyValue + " doesn't exist");
            }

            Console.WriteLine("Keyvalue found");
        }

        private Node SearchKeyValueInternal(int keyValue, Node node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.KeyValue == keyValue)
            {
                Console.WriteLine("Keyvalue found");
                return node;
            }

            return SearchKeyValueInternal(keyValue, keyValue < node.KeyValue ? node.LeftNode : node.RightNode);
        }

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

            SearchSubTree(subtree, SearchKeyValueInternal(subtree[index++], node ?? _root), index);
        }
    }
}
