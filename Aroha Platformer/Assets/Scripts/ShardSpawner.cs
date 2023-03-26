using System.Collections.Generic;
using UnityEngine;

public class ShardSpawner : MonoBehaviour
{

    private float minPos;
    private float maxPos;
    private float fixedOffset = 10;
    [SerializeField] private float offsetFromPlayer;
    [SerializeField] private float deathInterval;
    [SerializeField] private float spawnInterval;

    List<float> shards = new List<float>();
    Transform shardParent;
    Transform player;

    private void Awake()
    {
        shardParent = GameObject.Find("Shards").transform;
        player = GameManager.I.GetPlayerMovement().transform;
        InvokeRepeating(nameof(Spawn), 0, spawnInterval);
    }

    private void Update()
    {
        foreach (float shard in shards)
        {
            GameManager.I.Indicate(shard);
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < Random.Range(0, 10); i++)
        {
            SpawnSingular();
        }
    }

    private void SpawnSingular()
    {
        minPos = player.position.x - offsetFromPlayer;
        maxPos = player.position.x + offsetFromPlayer;

        float xPos = Random.Range(minPos, maxPos) + fixedOffset;
        shards.Add(xPos);
        Destroy(Instantiate(GameAssets.I.ShardPrefab, new Vector2(xPos, 100), Quaternion.identity, shardParent), deathInterval);
    }

}
