#nullable enable

namespace Algos_ue2
{
    public class Node
    {
        public Node(int keyValue)
        {
            KeyValue = keyValue;
        }
        public int KeyValue { get; private set; }

        public Node? LeftNode { get; set; }
        public Node? RightNode { get; set; }
    }
}