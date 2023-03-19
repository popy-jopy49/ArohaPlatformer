using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject Player;
    public Transform respawnPoint;

    void Update()
    {
        Collider2D[] hits = Player.GetComponent<PlayerMovement>().GetHits();

        if (hits == null || hits.Length <= 0)
            return;

        print(hits.Length);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(tag))
            {
                Player.GetComponent<PlayerMovement>().Respawn(respawnPoint.position);
            }
        }
    }

}
