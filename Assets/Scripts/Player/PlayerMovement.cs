using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField] private float moveSpeed;
    private Vector2 movementDir;
    private Vector2 latestDir;
    private bool isFacingRight;
    [SerializeField] private float jumpForce;

    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private GameObject attackPos;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        isFacingRight = true;
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
        
        if (movementDir != Vector2.zero)
        {
            latestDir = movementDir;
        }

        CheckFacedDirection();

        Debug.Log(latestDir);
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

    public void CheckFacedDirection()
    {
        if (latestDir.x >= 0) //Facing Right
        {
            isFacingRight = true;
            attackPos.transform.localPosition = new Vector2(1f, 1.5f);
        }
        else if (latestDir.x < 0) //Facing Left
        {
            isFacingRight = false;
            attackPos.transform.localPosition = new Vector2(-1f, 1.5f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
