using System;
using System.Collections.Generic;

class UnionFind
{
    private int[] parent;
    private int[] rank;

    public UnionFind(int n)
    {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i; // Initially, each node is its own parent
            rank[i] = 0;   // Initialize rank to 0 for all nodes
        }
    }

    public int Find(int u)
    {
        // Path compression: Makes the tree flat for faster future queries
        if (parent[u] != u)
        {
            parent[u] = Find(parent[u]);
        }
        return parent[u];
    }

    public void Union(int u, int v)
    {
        int rootU = Find(u);
        int rootV = Find(v);

        if (rootU != rootV)
        {
            // Union by rank: Attach the smaller tree under the larger tree
            if (rank[rootU] > rank[rootV])
            {
                parent[rootV] = rootU;
            }
            else if (rank[rootU] < rank[rootV])
            {
                parent[rootU] = rootV;
            }
            else
            {
                parent[rootV] = rootU;
                rank[rootU] += 1;
            }
        }
    }
}

class Kruskal
{
    public static List<Tuple<int, int, int>> KruskalAlgorithm(int n, List<Tuple<int, int, int>> edges)
    {
        UnionFind uf = new UnionFind(n);
        edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));  // Sort edges by weight

        List<Tuple<int, int, int>> mst = new List<Tuple<int, int, int>>();

        foreach (var edge in edges)
        {
            int u = edge.Item1;
            int v = edge.Item2;
            int weight = edge.Item3;

            if (uf.Find(u) != uf.Find(v))
            {
                uf.Union(u, v);
                mst.Add(edge);  // Add the edge to the MST
            }
        }

        return mst;
    }

    static void Main()
    {
        // Number of vertices (nodes) in the graph
        int n = 4;  // for example, 4 nodes

        // Edges in the format (u, v, weight)
        List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>()
        {
            Tuple.Create(0, 1, 10),
            Tuple.Create(0, 2, 6),
            Tuple.Create(0, 3, 5),
            Tuple.Create(1, 3, 15),
            Tuple.Create(2, 3, 4)
        };

        List<Tuple<int, int, int>> mst = KruskalAlgorithm(n, edges);

        Console.WriteLine("Edges in the MST:");
        foreach (var edge in mst)
        {
            Console.WriteLine($"{edge.Item1} - {edge.Item2}: {edge.Item3}");
        }
    }
}
