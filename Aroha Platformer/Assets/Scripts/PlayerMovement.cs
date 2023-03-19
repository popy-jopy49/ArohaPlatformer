using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float terminalDownwardVelocity;
    [SerializeField] private float drag;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius;
    Vector2 velocity;
    Transform groundCheck;
    BoxCollider2D boxCollider;
    Collider2D[] hits;

    private void Awake()
    {
        groundCheck = transform.Find("GroundCheck");
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float h = InputManager.INPUT_ACTIONS.Main.Movement.ReadValue<float>();
        velocity.x += h * movementSpeed / 10f;
        velocity.x *= drag;

        float v = Mathf.Ceil(InputManager.INPUT_ACTIONS.Main.Jump.ReadValue<float>());
        
        if (IsGrounded())
        {
            velocity.y = 0f;

            if (v != 0)
            {
                // Jump
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }
        else
        {
            // Apply gravity
            velocity.y += gravity * Time.deltaTime;
            if (velocity.y <= terminalDownwardVelocity)
            {
                velocity.y = terminalDownwardVelocity;
            }
        }

        transform.Translate(velocity * Time.deltaTime, Space.World);

        hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        foreach (Collider2D hit in hits)
        {
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
            }
        }
    }

    public void Respawn(Vector2 pos)
    {
        transform.position = pos;
    }

    public Collider2D[] GetHits() => hits;

    private bool IsGrounded() => Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

}
