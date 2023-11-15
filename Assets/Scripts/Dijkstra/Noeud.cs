using System.Collections.Generic;
using UnityEngine;

public class Noeud : MonoBehaviour
{
    public int Id;
    public Dictionary<Noeud, float> Liens = new Dictionary<Noeud, float>();

    public void CreerLien(Noeud noeud, float distance)
    {
        Liens[noeud] = distance;
    }
}
