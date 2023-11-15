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
            Debug.LogError("Erreur : Définissez le nœud de départ pour le bot.");
            return;
        }

        // Générer un nœud d'arrivée aléatoire parmi les nœuds du graphe
        NoeudArrivee = ChoisirNoeudAleatoire();
        obj = Instantiate(prefab, NoeudArrivee.transform.position, Quaternion.identity);

        // Utilisez A* pour trouver le chemin
        chemin = AStar.Instance.TrouverChemin(NoeudDepart, NoeudArrivee);

        if (chemin != null && chemin.Length > 0)
        {
            // Commencez le mouvement vers le premier nœud du chemin
            DeplacerVersProchainNoeud();
        }
        else
        {
            Debug.LogError("Aucun chemin trouvé.");
        }
    }

    void Update()
    {
        // Vérifiez si le bot a atteint la fin du chemin
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

        // Déplacez le bot vers le prochain nœud dans le chemin
        DeplacerVersProchainNoeud();
    }

    void DeplacerVersProchainNoeud()
    {
        Noeud prochainNoeud = chemin[indexChemin];

        // Déplacez le bot vers le prochain nœud
        transform.position = Vector3.MoveTowards(transform.position, prochainNoeud.transform.position, Vitesse * Time.deltaTime);

        // Vérifiez si le bot est arrivé au nœud
        if (Vector3.Distance(transform.position, prochainNoeud.transform.position) < 0.1f)
        {
            // Passez au prochain nœud dans le chemin
            indexChemin++;

            // Si le bot n'a pas atteint la fin du chemin, mettez à jour la cible
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
            Debug.LogError("Erreur : Le graphe ou la liste de nœuds n'a pas été initialisé.");
            return null;
        }

        // Choisissez un nœud aléatoire parmi la liste des nœuds du graphe
        int indexAleatoire = Random.Range(0, Graphe.Instance.Noeuds.Count);
        return Graphe.Instance.Noeuds[indexAleatoire];
    }
}
