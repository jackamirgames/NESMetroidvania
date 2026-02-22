using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField] private float moveSpeed;
    private Vector2 movementDir;
    [SerializeField] private float jumpForce;

    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0.5f);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementDir.x * moveSpeed * Time.fixedDeltaTime * 10f, rb.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementDir = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            rb.AddForce(new Vector2(0f, 100f * jumpForce), ForceMode2D.Force);
        }

        if (context.canceled)
        {
            if (rb.linearVelocity.y <= 0f) return;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        }
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
