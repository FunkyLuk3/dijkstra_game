using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] List<Noeud<string>> list_noeuds;
    [SerializeField] Graph<string> graph = new Graph<string>();

    // Start is called before the first frame update
    void Start()
    {
        graph.AddNoeud(0, "A");
        graph.AddNoeud(1, "B");
        graph.AddNoeud(2, "C");
        graph.AddNoeud(3, "D");
        graph.AddNoeud(4, "E");

        //A
        graph.graph[0].CreateConnection(graph.graph[1], 3);
        graph.graph[0].CreateConnection(graph.graph[3], 1);

        //B
        graph.graph[1].CreateConnection(graph.graph[0], 3);
        graph.graph[1].CreateConnection(graph.graph[2], 5);
        graph.graph[1].CreateConnection(graph.graph[3], 4);
        graph.graph[1].CreateConnection(graph.graph[4], 5);

        //C
        graph.graph[2].CreateConnection(graph.graph[1], 5);
        graph.graph[2].CreateConnection(graph.graph[4], 9);

        //D
        graph.graph[3].CreateConnection(graph.graph[0], 1);
        graph.graph[3].CreateConnection(graph.graph[1], 4);
        graph.graph[3].CreateConnection(graph.graph[4], 1);

        //E
        graph.graph[4].CreateConnection(graph.graph[3], 1);
        graph.graph[4].CreateConnection(graph.graph[2], 9);
        graph.graph[4].CreateConnection(graph.graph[1], 5);

        graph.Dijkstra(graph.graph[0], graph.graph[4]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
