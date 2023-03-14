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

    private void Awake()
    {
        groundCheck = transform.Find("GroundCheck");
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
    }

    private bool IsGrounded() => Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

}
