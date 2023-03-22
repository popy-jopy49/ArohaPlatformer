using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject Player;
    public Transform respawnPoint;

    void Update()
    {
        Collider2D[] hits = GameManager.I.PlayerCollisions;

        if (hits == null || hits.Length <= 0)
            return;

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(tag))
            {
                Player.GetComponent<PlayerMovement>().Respawn(GameManager.I.GetRespawnPos());
            }
        }
    }

}
