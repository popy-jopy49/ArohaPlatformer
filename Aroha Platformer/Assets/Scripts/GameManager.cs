using SWAssets;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private Transform Respawn;
    [HideInInspector] public Collider2D[] PlayerCollisions;
    [SerializeField] private PlayerMovement Player;

    public PlayerMovement GetPlayerMovement() => Player;
    public Vector2 GetRespawnPos() => Respawn.position;
    public void Indicate(float xPos)
    {
    }

}
