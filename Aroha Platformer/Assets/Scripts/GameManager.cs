using SWAssets;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private Transform Respawn;
    [HideInInspector] public Collider2D[] PlayerCollisions;
    [SerializeField] private PlayerMovement player;

    public PlayerMovement GetPlayerMovement() => player;
    public Vector2 GetRespawnPos() => Respawn.position;

}
