using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : MonoBehaviour
{
    public static Dijkstra Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Noeud[] TrouverCheminsPlusCourts(Noeud depart, Noeud arrivee)
    {
        Dictionary<Noeud, float> distances = new Dictionary<Noeud, float>();
        HashSet<Noeud> noeudsNonVisites = new HashSet<Noeud>();

        // Initialisation
        foreach (Noeud noeud in Graphe.Instance.Noeuds)
        {
            distances[noeud] = float.PositiveInfinity;
            noeudsNonVisites.Add(noeud);
        }

        distances[depart] = 0;

        while (noeudsNonVisites.Count > 0)
        {
            Noeud noeudCourant = ObtenirNoeudAvecDistanceMinimale(distances, noeudsNonVisites);

            if (noeudCourant == null)
            {
                Debug.LogError("Erreur : Le nœud courant est null.");
                return new Noeud[0];
            }

            noeudsNonVisites.Remove(noeudCourant);

            foreach (var lien in noeudCourant.Liens)
            {
                if (lien.Key == null)
                {
                    Debug.LogError("Erreur : Une clé de lien est null.");
                    return new Noeud[0];
                }

                float distancePotentielle = distances[noeudCourant] + lien.Value;

                if (distancePotentielle < distances[lien.Key])
                {
                    distances[lien.Key] = distancePotentielle;
                }
            }
        }

        // Reconstruction du chemin
        List<Noeud> cheminReversed = new List<Noeud>();
        Noeud noeudActuel = arrivee;

        while (noeudActuel != depart)
        {
            cheminReversed.Add(noeudActuel);

            if (noeudActuel.Liens == null)
            {
                Debug.LogError("Erreur : La liste de Liens pour le nœud actuel est null.");
                return new Noeud[0];
            }

            float distanceMinimale = float.PositiveInfinity;
            Noeud prochainNoeud = null;

            foreach (var lien in noeudActuel.Liens)
            {
                if (lien.Key == null)
                {
                    Debug.LogError("Erreur : Une clé de lien est null.");
                    return new Noeud[0];
                }

                float distance = distances[lien.Key];
                if (distance < distanceMinimale)
                {
                    distanceMinimale = distance;
                    prochainNoeud = lien.Key;
                }
            }

            noeudActuel = prochainNoeud;
        }

        cheminReversed.Add(depart);

        // Inverser le chemin pour l'obtenir dans l'ordre correct
        cheminReversed.Reverse();

        return cheminReversed.ToArray();
    }

    private Noeud ObtenirNoeudAvecDistanceMinimale(Dictionary<Noeud, float> distances, HashSet<Noeud> noeudsNonVisites)
    {
        Noeud noeudMin = null;
        float distanceMin = float.PositiveInfinity;

        foreach (Noeud noeud in noeudsNonVisites)
        {
            if (distances[noeud] < distanceMin)
            {
                noeudMin = noeud;
                distanceMin = distances[noeud];
            }
        }

        return noeudMin;
    }

}
