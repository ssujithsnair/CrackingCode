using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCode
{
    class Node
    {
        string data;
        Node left, right;
        public Node(string item)
        {
            data = item;
            left = right = null;
        }

        public Node AddLeft(string l)
        {
            if (!string.IsNullOrWhiteSpace(l))
                left = new Node(l);
            return left;
        }
        public Node AddRight(string r)
        {            
            if (!string.IsNullOrWhiteSpace(r))
                right = new Node(r);
            return right;
        }

        class NodeLevel
        {
            public Node Node;
            public int level;
        }

        public static int FindDeepestLeafLevel(Node root)
        {
            return 0;
        }

        public static int FindDeepestLevel(Node node, int level)
        {
            return 0;
        }

        public static int FindShallowestLeafLevel(Node root)
        {
            if (root == null)
                return 0;
            Queue<NodeLevel> q = new Queue<NodeLevel>();
            q.Enqueue(new NodeLevel{Node = root, level = 1});
            while (q.Count > 0)
            {
                var levelNode = q.Dequeue();
                Node node = levelNode.Node;
                int level = levelNode.level;

                if (node.left == null && node.right == null)
                    return level;
                if (node.left != null)
                {
                    q.Enqueue(new NodeLevel { Node = node.left, level = level + 1 });
                }
                if (node.right != null)
                {
                    q.Enqueue(new NodeLevel { Node = node.right, level = level + 1 });
                }
            }
            return 0;
        }
    }
    class BMTest
    {
        private static int TraverseTree(Dictionary<string, List<string>> nodeslist, string root)
        {
            if (root == null)
                return -1;
            Queue<Tuple<string, int>> q = new Queue<Tuple<string, int>>();
            q.Enqueue(new Tuple<string, int>(root, 0));
            while (q.Count > 0)
            {
                Tuple<string, int> levelNode = q.Dequeue();
                List<string> node = nodeslist.ContainsKey(levelNode.Item1) ? nodeslist[levelNode.Item1] : null;
                if (node == null || node.Count == 0)
                {
                    return levelNode.Item2;
                }
                string firstChild = node.Count > 0 ? node[0] : null;
                string secondChild = node.Count > 1 ? node[1] : null;
                if (string.IsNullOrWhiteSpace(firstChild) && string.IsNullOrWhiteSpace(secondChild))
                {
                    return levelNode.Item2;
                }

                if (!string.IsNullOrWhiteSpace(firstChild))
                {
                    q.Enqueue(new Tuple<string, int>(firstChild, levelNode.Item2 + 1));
                }

                if (!string.IsNullOrWhiteSpace(secondChild))
                {
                    q.Enqueue(new Tuple<string, int>(secondChild, levelNode.Item2 + 1));
                }
            }
            return -1;
        }
        public static void Test1()
        {
            Dictionary<string, List<string>> nodeslist = new Dictionary<string, List<string>>();
            string root = null;
            string input = null;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                string[] arr_temp = input.Split(',');
                if (root == null)
                    root = arr_temp[0];
                nodeslist.Add(arr_temp[0], new List<string>());
                nodeslist[arr_temp[0]].Add(arr_temp.Length > 1 ? arr_temp[1] : null);
                nodeslist[arr_temp[0]].Add(arr_temp.Length > 2 ? arr_temp[2] : null);
            }
            Console.WriteLine(TraverseTree(nodeslist, root));
        }

        public static void Test()
        {
            string input = null;
            Node Root = null;
            Node parentnode = null;

            // Use a dictionary just in case nodes dont come in order
            Dictionary<string, Node> nodelist = new Dictionary<string, Node>();
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                string[] arr_temp = input.Split(',');
                if (Root == null)
                {
                    parentnode = new Node(arr_temp[0]);
                    Root = parentnode;
                }
                else
                {
                    parentnode = nodelist[arr_temp[0]];
                }
                if (arr_temp.Length > 1 && !string.IsNullOrWhiteSpace(arr_temp[1]))
                {
                    nodelist.Add(arr_temp[1], parentnode.AddLeft(arr_temp[1]));
                }
                if (arr_temp.Length > 2 && !string.IsNullOrWhiteSpace(arr_temp[2]))
                {
                    nodelist.Add(arr_temp[2], parentnode.AddRight(arr_temp[2]));
                }
            }
            int level = Node.FindShallowestLeafLevel(Root);
        }
    }
}
/*
a,b,c
b,d,e
c,f,g
d,h,i
e,j,k
f,l,m
g,n,

*/