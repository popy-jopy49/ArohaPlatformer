using SWAssets;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private Transform Respawn;
    [HideInInspector] public Collider2D[] PlayerCollisions;
    [SerializeField] private PlayerMovement Player;
    private Transform canvas;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas").transform;
    }

    public PlayerMovement GetPlayerMovement() => Player;
    public Vector2 GetRespawnPos() => Respawn.position;
    public void Indicate(float xPos)
    {
        Destroy(Instantiate(GameAssets.I.IndicatorPrefab, Camera.main.WorldToScreenPoint(new Vector3(xPos, 10)), Quaternion.identity, canvas), 5);
    }

}
