using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noeud<Data> 
{
    public int id;
    public Data data;
    public Dictionary<Noeud<Data>, float> link;

    public Noeud(int id, Data data)
    {
        this.id = id;
        this.data = data;

        link = new Dictionary<Noeud<Data>, float>();
    }

    public void CreateConnection(Noeud<Data> noeud, float distence)
    {   
        link.TryAdd(noeud, distence);  
    }
}
