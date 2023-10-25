using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph<Data>
{
    [SerializeField] public List<Noeud<Data>> graph;

    public Graph() 
    {
        graph = new List<Noeud<Data>>();
    }

    public void AddNoeud(int id, Data data)
    {
        graph.Add(new Noeud<Data>(id, data));
    }

    public void Dijkstra(Noeud<Data> noeud_1, Noeud<Data> noeud_2)
    {
        float min = float.PositiveInfinity;
        for (int i = 0; i < graph.Count; i++)
        {
            foreach (KeyValuePair<Noeud<Data>, float> entree in graph[i].link)
            {
                if (min )
                {
                    
                }
            }
        }
    }
}
