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

        public float Min(Node node = null)
        {
            if (node == null)
            {
                return Min(_root);
            }
            else
            {
                if (node.LeftNode == null)
                {
                    return node.KeyValue;
                }
                else
                {
                    return Min(node.LeftNode);
                }
            }
        }

        public float Max(Node node = null)
        {
            if (node == null)
            {
                return Max(_root);
            }


            else
            {
                if (node.RightNode == null)
                {
                    return node.KeyValue;
                }
                else
                {
                    return Max(node.RightNode);
                }
            }
        }

        public float calcSumRec(Node node = null)
        {
            float sum = 0;
            if (node == null)
            {
                return calcSumRec(_root);
            }
            else
            {
                sum += node.KeyValue;

                if (node.LeftNode != null)
                {
                    sum += calcSumRec(node.LeftNode);
                }

                if (node.RightNode != null)
                {
                    sum += calcSumRec(node.RightNode);
                }
            }

            return sum;
        }

        public float Avg()
        {
            return calcSumRec() / (_size + 1);
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