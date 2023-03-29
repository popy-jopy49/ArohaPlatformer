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
    [SerializeField] private int shardAmount = 3;

    List<Transform> shards = new List<Transform>();
    Transform shardParent;
    Transform player;
    Transform canvas;

    private void Awake()
    {
        shardParent = GameObject.Find("Shards").transform;
        player = GameManager.I.GetPlayerMovement().transform;
        canvas = GameObject.Find("Canvas").transform;

        InvokeRepeating(nameof(Spawn), 0, spawnInterval);
    }

    private void Spawn()
    {
        for (int i = 0; i < Random.Range(1, shardAmount + 1); i++)
        {
            SpawnSingular();
        }
    }

    private void SpawnSingular()
    {
        minPos = player.position.x - offsetFromPlayer;
        maxPos = player.position.x + offsetFromPlayer;

        float xPos = Random.Range(minPos, maxPos) + fixedOffset;
        Vector2 iPos = new Vector2(Camera.main.WorldToScreenPoint(new Vector2(xPos, 0)).x, 540);
        Indicator i = Instantiate(GameAssets.I.IndicatorPrefab, canvas, false).GetComponent<Indicator>();
        i.transform.localPosition = iPos;
        Transform s = Instantiate(GameAssets.I.ShardPrefab, new Vector2(xPos, 100), Quaternion.identity, shardParent).transform;
        i.Assign(s);
        Destroy(s.gameObject, deathInterval);
    }

}
