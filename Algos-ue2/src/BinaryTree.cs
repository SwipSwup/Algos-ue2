using System;
using System.Collections.Generic;
using System.IO;

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

        public Node SearchKeyValue(int keyValue, Node node)
        {
            if (node == null)
            {
                Console.WriteLine("Key value " + keyValue + " doesn't exist");
                return null;
            }

            if (node.KeyValue == keyValue)
            {
                Console.WriteLine("Keyvalue found");
                return node;
            }

            if (keyValue < node.KeyValue)
            {
                return SearchKeyValue(keyValue, node.LeftNode);
            }
                return SearchKeyValue(keyValue, node.RightNode);
        }

        public void SearchSubTree(int[] subtree)
        {
            //TODO lukas
        }
    }
}