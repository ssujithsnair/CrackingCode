
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCode.TopologicalSort
{
    public class StackMin : Stack<int>
    {
        public void Push(int val)
        {
            base.Push(val);
        }
    }

    class TopologicalSort
    {
        
        public static void Test()
        {
            var projects = GetProjectsBuildOrder(new[] { "a", "b", "c", "d", "e", "f" },
                new string[][] { new[] { "a", "d" }, new[] { "f", "b" }, new[] { "b", "d" }, new[] { "f", "a" }, new[] { "d", "c" } });
        }
        public static Project[] GetProjectsBuildOrder(string[] projects, string[][] dependencies)
        {
            Graph g = new Graph();
            foreach (var proj in projects)
                g.GetProject(proj);
            foreach (var dep in dependencies)
                g.AddNeighbor(dep[0], dep[1]);
            return OrderProjects(g.Nodes);
        }
        private static Project[] OrderProjects(List<Project> nodes)
        {
            Project[] order = new Project[nodes.Count];
            int offset = AddNonDependency(order, nodes, 0);
            int current = 0;
            while (current < order.Length)
            {
                Project proj = order[current];
                if (proj == null)
                    return null;
                foreach (var p in proj.Children)
                    p.Dependencies--;
                offset = AddNonDependency(order, proj.Children, offset);
                current++;
            }
            return order;
        }
        private static int AddNonDependency(Project[] order, List<Project> projects, int offset)
        {
            foreach(var proj in projects)
                if (proj.Dependencies == 0)
                    order[offset++] = proj;
            return offset;
        }
    }

    class Graph
    {
        public List<Project> Nodes = new List<Project>();
        Dictionary<string, Project> Projects = new Dictionary<string, Project>();
        public Project GetProject(string name)
        {
            Project p = null;
            if (Projects.ContainsKey(name))
                p = Projects[name];
            else
            {
                Projects.Add(name, p = new Project(name));
                Nodes.Add(p);
            }
            return p;
        }
        public void AddNeighbor(string start, string end)
        {
            var p1 = GetProject(start);
            var p2 = GetProject(end);
            p1.AddDependency(p2);
        }
    }

    class Project
    {
        public List<Project> Children = new List<Project>();
        Dictionary<string, Project> Projects = new Dictionary<string, Project>();
        public int Dependencies;
        public string Name;
        public Project(string name)
        {
            Name = name;
        }
        public void AddDependency(Project proj)
        {
            if (!Projects.ContainsKey(proj.Name))
            {
                Children.Add(proj);
                Projects[Name] = proj;
                proj.Dependencies++;
            }
        }
    }
}
