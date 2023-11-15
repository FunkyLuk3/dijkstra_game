using UnityEngine;

public class Bot_Astar : MonoBehaviour
{
    public float Vitesse = 5f;
    public Noeud NoeudDepart;
    public Noeud NoeudArrivee;
    private Noeud[] chemin;
    private int indexChemin = 0;
    public int score = 0;
    public GameObject prefab;
    GameObject obj;

    void Start()
    {
        if (NoeudDepart == null)
        {
            Debug.LogError("Erreur : D�finissez le n�ud de d�part pour le bot.");
            return;
        }

        // G�n�rer un n�ud d'arriv�e al�atoire parmi les n�uds du graphe
        NoeudArrivee = ChoisirNoeudAleatoire();
        obj = Instantiate(prefab, NoeudArrivee.transform.position, Quaternion.identity);

        // Utilisez A* pour trouver le chemin
        chemin = AStar.Instance.TrouverChemin(NoeudDepart, NoeudArrivee);

        if (chemin != null && chemin.Length > 0)
        {
            // Commencez le mouvement vers le premier n�ud du chemin
            DeplacerVersProchainNoeud();
        }
        else
        {
            Debug.LogError("Aucun chemin trouv�.");
        }
    }

    void Update()
    {
        // V�rifiez si le bot a atteint la fin du chemin
        if (indexChemin >= chemin.Length)
        {
            Destroy(obj);
            NoeudDepart = NoeudArrivee;
            NoeudArrivee = ChoisirNoeudAleatoire();
            obj = Instantiate(prefab, NoeudArrivee.transform.position, Quaternion.identity);
            indexChemin = 0;
            chemin = AStar.Instance.TrouverChemin(NoeudDepart, NoeudArrivee);
            score++;
        }

        // D�placez le bot vers le prochain n�ud dans le chemin
        DeplacerVersProchainNoeud();
    }

    void DeplacerVersProchainNoeud()
    {
        Noeud prochainNoeud = chemin[indexChemin];

        // D�placez le bot vers le prochain n�ud
        transform.position = Vector3.MoveTowards(transform.position, prochainNoeud.transform.position, Vitesse * Time.deltaTime);

        // V�rifiez si le bot est arriv� au n�ud
        if (Vector3.Distance(transform.position, prochainNoeud.transform.position) < 0.1f)
        {
            // Passez au prochain n�ud dans le chemin
            indexChemin++;

            // Si le bot n'a pas atteint la fin du chemin, mettez � jour la cible
            if (indexChemin < chemin.Length)
            {
                prochainNoeud = chemin[indexChemin];
            }
        }
    }

    Noeud ChoisirNoeudAleatoire()
    {
        if (Graphe.Instance == null || Graphe.Instance.Noeuds == null || Graphe.Instance.Noeuds.Count == 0)
        {
            Debug.LogError("Erreur : Le graphe ou la liste de n�uds n'a pas �t� initialis�.");
            return null;
        }

        // Choisissez un n�ud al�atoire parmi la liste des n�uds du graphe
        int indexAleatoire = Random.Range(0, Graphe.Instance.Noeuds.Count);
        return Graphe.Instance.Noeuds[indexAleatoire];
    }
}
