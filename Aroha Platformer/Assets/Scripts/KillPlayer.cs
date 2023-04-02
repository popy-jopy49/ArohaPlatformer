using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    void Update()
    {
        Collider2D[] hits = GameManager.I.PlayerCollisions;

        if (hits == null || hits.Length <= 0)
            return;

        foreach (Collider2D hit in hits)
        {
            if (!hit)
                continue;

            if (hit.CompareTag(tag))
            {
                GameManager.I.GetPlayerMovement().Respawn(GameManager.I.GetRespawnPos());
            }
        }
    }

}
