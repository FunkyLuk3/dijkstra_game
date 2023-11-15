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

        // Liste des nœuds à explorer
        List<Noeud> ouverts = new List<Noeud> { depart };

        // Liste des nœuds déjà explorés
        HashSet<Noeud> fermes = new HashSet<Noeud>();

        // Dictionnaire pour stocker le coût total de chaque nœud depuis le départ
        Dictionary<Noeud, float> coutTotal = new Dictionary<Noeud, float>();
        coutTotal[depart] = 0;

        // Dictionnaire pour stocker le nœud parent de chaque nœud dans le chemin optimal
        Dictionary<Noeud, Noeud> parents = new Dictionary<Noeud, Noeud>();

        while (ouverts.Count > 0)
        {
            // Trouver le nœud avec le coût total le plus bas
            Noeud nCourant = TrouverNoeudMoinsCher(ouverts, coutTotal);

            // Ajouter le nœud courant à la liste fermée
            ouverts.Remove(nCourant);
            fermes.Add(nCourant);

            // Si on atteint le nœud d'arrivée, reconstruire le chemin et le retourner
            if (nCourant == arrivee)
            {
                return ReconstruireChemin(parents, arrivee);
            }

            // Explorer les voisins du nœud courant
            foreach (var voisin in nCourant.Liens.Keys)
            {
                // Ignorer les nœuds déjà explorés
                if (fermes.Contains(voisin))
                {
                    continue;
                }

                // Calculer le coût total du nœud voisin
                float nouveauCoutTotal = coutTotal[nCourant] + nCourant.Liens[voisin];

                // Si le nœud voisin n'est pas dans la liste ouverte ou s'il a un coût total inférieur
                if (!ouverts.Contains(voisin) || nouveauCoutTotal < coutTotal[voisin])
                {
                    coutTotal[voisin] = nouveauCoutTotal;
                    parents[voisin] = nCourant;

                    // Ajouter le nœud voisin à la liste ouverte s'il n'y est pas déjà
                    if (!ouverts.Contains(voisin))
                    {
                        ouverts.Add(voisin);
                    }
                }
            }
        }

        // Aucun chemin trouvé
        Debug.LogError("A* : Aucun chemin trouvé.");
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
