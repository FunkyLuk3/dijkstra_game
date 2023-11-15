using System.Collections.Generic;
using UnityEngine;

public class Graphe : MonoBehaviour
{
    public static Graphe Instance { get; private set; }

    public List<Noeud> Noeuds = new List<Noeud>();

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

        // Appeler une méthode pour créer les liens entre les nœuds
        CreerLiensEntreNoeuds();
    }

    void CreerLiensEntreNoeuds()
    {
        // Ajoutez des liens entre les nœuds
        Noeud n_1 = Noeuds[0];
        Noeud n_2 = Noeuds[1];
        Noeud n_3 = Noeuds[2];
        Noeud n_4 = Noeuds[3];
        Noeud n_5 = Noeuds[4];
        Noeud n_6 = Noeuds[5];
        Noeud n_7 = Noeuds[6];
        Noeud n_8 = Noeuds[7];
        Noeud n_9 = Noeuds[8];
        Noeud n_10 = Noeuds[9];
        Noeud n_11 = Noeuds[10];
        Noeud n_12 = Noeuds[11];
        Noeud n_13 = Noeuds[12];
        Noeud n_14 = Noeuds[13];
        Noeud n_15 = Noeuds[14];
        Noeud n_16 = Noeuds[15];
        Noeud n_17 = Noeuds[16];
        Noeud n_18 = Noeuds[17];
        Noeud n_19 = Noeuds[18];
        Noeud n_20 = Noeuds[19];
        Noeud n_21 = Noeuds[20];
        Noeud n_22 = Noeuds[21];
        Noeud n_23 = Noeuds[22];
        Noeud n_24 = Noeuds[23];






        n_1.CreerLien(n_2, 5);
        n_1.CreerLien(n_17, 2);
        n_2.CreerLien(n_1, 5);
        n_2.CreerLien(n_3, 3);
        n_2.CreerLien(n_4, 3);
        n_3.CreerLien(n_2, 3);
        n_3.CreerLien(n_5, 3);
        n_3.CreerLien(n_18, 3);
        n_4.CreerLien(n_2, 3);
        n_4.CreerLien(n_6, 3);
        n_5.CreerLien(n_3, 3);
        n_5.CreerLien(n_6, 1);
        n_6.CreerLien(n_5, 1);
        n_6.CreerLien(n_4, 3);
        n_6.CreerLien(n_7, 5);
        n_7.CreerLien(n_6, 5);
        n_7.CreerLien(n_8, 6);
        n_8.CreerLien(n_7, 6);
        n_8.CreerLien(n_9, 3);
        n_9.CreerLien(n_8, 3);
        n_9.CreerLien(n_10, 4);
        n_10.CreerLien(n_9, 4);
        n_10.CreerLien(n_11, 5);
        n_11.CreerLien(n_10, 5);
        n_11.CreerLien(n_12, 3);
        n_12.CreerLien(n_11, 3);
        n_12.CreerLien(n_13, 2);
        n_13.CreerLien(n_12, 2);
        n_13.CreerLien(n_14, 2);
        n_13.CreerLien(n_16, 3);
        n_14.CreerLien(n_13, 2);
        n_14.CreerLien(n_15, 3);
        n_15.CreerLien(n_14, 3);
        n_15.CreerLien(n_16, 2);
        n_15.CreerLien(n_17, 1);
        n_16.CreerLien(n_15, 2);
        n_16.CreerLien(n_13, 3);
        n_17.CreerLien(n_15, 1);
        n_17.CreerLien(n_1, 2);
        n_18.CreerLien(n_3, 3);
        n_18.CreerLien(n_19, 8);
        n_18.CreerLien(n_20, 3);
        n_19.CreerLien(n_18, 8);
        n_20.CreerLien(n_18, 3);
        n_20.CreerLien(n_21, 6);
        n_20.CreerLien(n_23, 2);
        n_21.CreerLien(n_20, 6);
        n_21.CreerLien(n_22, 2);
        n_22.CreerLien(n_21, 2);
        n_22.CreerLien(n_23, 6);
        n_23.CreerLien(n_22, 6);
        n_23.CreerLien(n_20, 2);
        n_23.CreerLien(n_24, 3);
        n_24.CreerLien(n_23, 3);

    }

    void Update()
    {

    }
}
