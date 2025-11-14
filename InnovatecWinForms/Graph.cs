using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovatecWinForms
{
    public class Edge
    {
        public string To { get; set; }
        public double Weight { get; set; }

        public Edge(string to, double weight)
        {
            To = to;
            Weight = weight;
        }
    }

    public class Graph
    {
        private Dictionary<string, List<Edge>> adj = new Dictionary<string, List<Edge>>();

        public void AddVertex(string v)
        {
            if (!adj.ContainsKey(v))
                adj[v] = new List<Edge>();
        }

        public void AddEdge(string a, string b, double weight)
        {
            AddVertex(a);
            AddVertex(b);

            adj[a].Add(new Edge(b, weight));
            adj[b].Add(new Edge(a, weight));
        }

        public IEnumerable<Edge> GetAdj(string v)
        {
            if (!adj.ContainsKey(v)) return Enumerable.Empty<Edge>();
            return adj[v];
        }

        public (double dist, List<string> path) Dijkstra(string start, string end)
        {
            if (!adj.ContainsKey(start) || !adj.ContainsKey(end))
                return (double.PositiveInfinity, null);

            var dist = new Dictionary<string, double>();
            var prev = new Dictionary<string, string>();
            var pq = new SortedSet<(double, string)>(Comparer<(double, string)>.Create(
                (a, b) => a.Item1 == b.Item1 ? a.Item2.CompareTo(b.Item2) : a.Item1.CompareTo(b.Item1)
            ));

            foreach (var v in adj.Keys)
                dist[v] = double.PositiveInfinity;

            dist[start] = 0;
            pq.Add((0, start));

            while (pq.Count > 0)
            {
                var (d, u) = pq.First();
                pq.Remove((d, u));

                if (u == end) break;

                foreach (var e in adj[u])
                {
                    double alt = dist[u] + e.Weight;

                    if (alt < dist[e.To])
                    {
                        if (dist[e.To] != double.PositiveInfinity)
                            pq.Remove((dist[e.To], e.To));

                        dist[e.To] = alt;
                        prev[e.To] = u;
                        pq.Add((alt, e.To));
                    }
                }
            }

            if (double.IsInfinity(dist[end])) return (dist[end], null);

            List<string> path = new List<string>();
            string current = end;

            while (current != null)
            {
                path.Add(current);
                prev.TryGetValue(current, out current);
            }

            path.Reverse();
            return (dist[end], path);
        }

        public Dictionary<string, List<Edge>> GetAll() => adj;
    }
}
