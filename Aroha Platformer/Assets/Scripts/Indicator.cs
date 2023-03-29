using UnityEngine;

public class Indicator : MonoBehaviour
{

    private Transform shard;

    public void Assign(Transform shardToIndicate)
    {
        shard = shardToIndicate;
    }

    private void Update()
    {
        if (shard.position.y <= GameManager.I.GetPlayerMovement().transform.position.y)
        {
            Destroy(gameObject);
            return;
        }

        transform.localPosition = new Vector2(Camera.main.WorldToScreenPoint(new Vector2(shard.position.x, 0)).x - 960f, transform.localPosition.y);
    }

}
