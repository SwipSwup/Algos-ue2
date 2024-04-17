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

        public float Min()
        {
            //TODO LUKAS
            return 0f;
        }

        public float Max()
        {
            //TODO LUKAS
            return 0;
        }

        public float Avg()
        {
            //TODO LUKAS
            return 0;
        }

        public float Balance(Node node)
        {
            //TODO IVO
            return 0;
        }

        public void SearchKeyValue(int keyValue)
        {
            //TODO IVO
        }

        public void SearchSubTree(int[] subtree)
        {
            //TODO lukas
        }
    }
}