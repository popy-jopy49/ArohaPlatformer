using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject Player;
    public Transform respawnPoint;

    void Update()
    {
        Collider2D[] hits = Player.GetComponent<PlayerMovement>().GetHits();

        if (hits.Length <= 0)
            return;

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                Player.transform.position = respawnPoint.position;
            }
        }
    }

}
