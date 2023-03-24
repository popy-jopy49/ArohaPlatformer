
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    [SerializeField] private int levelToLoad;
    private BoxCollider2D bCol;

    private void Awake()
    {
        bCol = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Collider2D[] hits = GameManager.I.PlayerCollisions;

        print(hits.Length);
        foreach (Collider2D hit in hits)
        {
            print(bCol + " " + hit);
            if (hit == bCol)
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
}
