using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    public static AStar Instance { get; private set; }

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

    public Noeud[] TrouverChemin(Noeud depart, Noeud arrivee)
    {
        List<Noeud> chemin = new List<Noeud>();

        // Liste des n�uds � explorer
        List<Noeud> ouverts = new List<Noeud> { depart };

        // Liste des n�uds d�j� explor�s
        HashSet<Noeud> fermes = new HashSet<Noeud>();

        // Dictionnaire pour stocker le co�t total de chaque n�ud depuis le d�part
        Dictionary<Noeud, float> coutTotal = new Dictionary<Noeud, float>();
        coutTotal[depart] = 0;

        // Dictionnaire pour stocker le n�ud parent de chaque n�ud dans le chemin optimal
        Dictionary<Noeud, Noeud> parents = new Dictionary<Noeud, Noeud>();

        while (ouverts.Count > 0)
        {
            // Trouver le n�ud avec le co�t total le plus bas
            Noeud nCourant = TrouverNoeudMoinsCher(ouverts, coutTotal);

            // Ajouter le n�ud courant � la liste ferm�e
            ouverts.Remove(nCourant);
            fermes.Add(nCourant);

            // Si on atteint le n�ud d'arriv�e, reconstruire le chemin et le retourner
            if (nCourant == arrivee)
            {
                return ReconstruireChemin(parents, arrivee);
            }

            // Explorer les voisins du n�ud courant
            foreach (var voisin in nCourant.Liens.Keys)
            {
                // Ignorer les n�uds d�j� explor�s
                if (fermes.Contains(voisin))
                {
                    continue;
                }

                // Calculer le co�t total du n�ud voisin
                float nouveauCoutTotal = coutTotal[nCourant] + nCourant.Liens[voisin];

                // Si le n�ud voisin n'est pas dans la liste ouverte ou s'il a un co�t total inf�rieur
                if (!ouverts.Contains(voisin) || nouveauCoutTotal < coutTotal[voisin])
                {
                    coutTotal[voisin] = nouveauCoutTotal;
                    parents[voisin] = nCourant;

                    // Ajouter le n�ud voisin � la liste ouverte s'il n'y est pas d�j�
                    if (!ouverts.Contains(voisin))
                    {
                        ouverts.Add(voisin);
                    }
                }
            }
        }

        // Aucun chemin trouv�
        Debug.LogError("A* : Aucun chemin trouv�.");
        return new Noeud[0];
    }

    private Noeud TrouverNoeudMoinsCher(List<Noeud> ouverts, Dictionary<Noeud, float> coutTotal)
    {
        Noeud moinsCher = ouverts[0];
        float coutMin = coutTotal[moinsCher];

        foreach (var n in ouverts)
        {
            float cout = coutTotal[n];
            if (cout < coutMin)
            {
                moinsCher = n;
                coutMin = cout;
            }
        }

        return moinsCher;
    }

    private Noeud[] ReconstruireChemin(Dictionary<Noeud, Noeud> parents, Noeud arrivee)
    {
        List<Noeud> chemin = new List<Noeud>();
        Noeud nCourant = arrivee;

        while (parents.ContainsKey(nCourant))
        {
            chemin.Add(nCourant);
            nCourant = parents[nCourant];
        }

        chemin.Reverse();
        return chemin.ToArray();
    }
}
