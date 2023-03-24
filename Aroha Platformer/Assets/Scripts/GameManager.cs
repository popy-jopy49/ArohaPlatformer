using SWAssets;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private PlayerMovement player;
    public PlayerMovement GetPlayerMovement() => player;

    [SerializeField] private Transform Respawn;
    [HideInInspector] public Collider2D[] PlayerCollisions;

    public Vector2 GetRespawnPos() => Respawn.position;

}
