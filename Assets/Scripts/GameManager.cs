using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Bot bot_dijkstra;
    Bot_Astar bot_astar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bot_dijkstra != null)
        {
            if (bot_dijkstra.score == 6)
            {
                Debug.Log("Dijkstra l'emporte !");
                Application.Quit();
            }
        }
        if (bot_astar != null)
        {
            if (bot_astar.score == 6)
            {
                Debug.Log("Astar l'emporte !");
                Application.Quit();
            }
        }
    }
}
