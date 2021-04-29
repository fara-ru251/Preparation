using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class AshuraAndKingdom
    {

        public void NumberOfConnectionsBetween(int n, int[][] conn)
        {
            List<int>[] _adjacencyListArr = new List<int>[n + 1];

            for (int i = 1; i <= n; i++)
            {
                _adjacencyListArr[i] = new List<int>();
            }

            for (int i = 0; i < conn.Length; i++)
            {
                var rel = conn[i];

                _adjacencyListArr[rel[0]].Add(rel[1]);
                _adjacencyListArr[rel[1]].Add(rel[0]);
            }

            for (int i = 1; i < _adjacencyListArr.Length; i++)
            {
                Console.Write(i + " => ");
                List<int> adj_list = _adjacencyListArr[i];

                foreach (var rel in adj_list)
                {
                    Console.Write(rel + " ");
                }
                Console.Write("\n");
            }


            //bool[] visited = new bool[n];
            //for (int i = 0; i < n; i++)
            //{
            //    if (!visited[i])
            //    {
            //        DepthFirstSearch(i, visited, _adjacencyListArr);
            //    }
            //}


        }

        private void DepthFirstSearch(int vertex, bool[] visited, List<int>[] adjacencyListArr)
        {
            visited[vertex] = true;
            Console.Write(vertex + " ");


            List<int> adj_list = adjacencyListArr[vertex];

            foreach (var rel in adj_list)
            {
                if (!visited[rel])
                {
                    DepthFirstSearch(rel, visited, adjacencyListArr);
                }
            }
        }
    }

    public class Graph
    {
        private int _vertice; // No. of vertices


        private List<int>[] _adjacencyListArray; // array of lists for adjacency list representation

        public Graph(int vertices)
        {
            _vertice = vertices;

            _adjacencyListArray = new List<int>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                _adjacencyListArray[i] = new List<int>();
            }
        }

        public void AddEdge(int vertex, int weight)
        {
            _adjacencyListArray[vertex].Add(weight);
        }

        public void Dfs(int vertice)
        {
            bool[] visited = new bool[_vertice];

            DfsUtil(vertice, visited);
        }

        public void DfsUtil(int vertice, bool[] visited)
        {
            visited[vertice] = true;
            Console.Write(vertice + " ");

            List<int> _adjacencyList = _adjacencyListArray[vertice];

            foreach (var i in _adjacencyList)
            {
                if (!visited[i])
                {
                    DfsUtil(i, visited);
                }
            }
        }
    }
}
