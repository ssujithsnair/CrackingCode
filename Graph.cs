using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCode
{
    class Graph
    {
        List<int>[] nodes;
        public Graph(int v)
        {
            nodes = new List<int>[v];
            //for(int i=0; i< v; i++)
            //{
            //    nodes[i] = new List<int>();
            //}
        }

        public bool AddEdge(int a, int b)
        {
            if (nodes.Length <= a)
                return false;
            if (nodes[a] == null)
                nodes[a] = new List<int>();
            nodes[a].Add(b);
            return true;
        }

        public void DFS(int n)
        {
            bool[] marked = new bool[nodes.Length];
            for(int i=0; i < nodes.Length; i++)
            {
                if (!marked[i])
                    DfsInternal(n, marked);
            }
        }

        private void DfsInternal(int n, bool[] marked)
        {
            marked[n] = true;
            Console.WriteLine(n);
            var items = nodes[n];
            if (items == null)
                return;
            foreach (var node in items)
            {
                if (!marked[node])
                    DfsInternal(node, marked);
            }
        }

        public void BFS(int n)
        {
            bool[] marked = new bool[nodes.Length];
            Queue<int> q = new Queue<int>();
            marked[n] = true;
            q.Enqueue(n);
            while (q.Count > 0)
            {
                var item = q.Dequeue();
                Console.WriteLine(item);
                var items = nodes[item];
                if (items == null)
                    continue;
                foreach(var entry in items)
                {
                    if (!marked[entry])
                    {
                        marked[entry] = true;
                        q.Enqueue(entry);
                    }
                }
            }
        }

        public static void Test()
        {
            Graph g = new Graph(6);
            g.AddEdge(0, 1);
            g.AddEdge(0, 4);
            g.AddEdge(0, 5);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);
            g.AddEdge(3, 2);
            g.AddEdge(2, 1);

            Console.WriteLine("DFS for 0");
            g.DFS(0);
            Console.WriteLine("BFS for 0");
            g.BFS(0);
        }
    }
}
