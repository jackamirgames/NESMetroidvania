using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Other Player scripts
    private PlayerStates _playerStates;

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

    //Cutscene Stuff
    private Vector2 cutsceneMovementDir;

    private Rigidbody2D rb;
    private void Awake()
    {
        _playerStates = GetComponent<PlayerStates>();

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
            
        }
    }

    private void FixedUpdate()
    {
        if (_playerStates.CanControl)
        {
            rb.linearVelocity = new Vector2(movementDir.x * moveSpeed * Time.fixedDeltaTime * 10f, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(cutsceneMovementDir.x * moveSpeed * Time.fixedDeltaTime * 10f, rb.linearVelocity.y);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementDir = context.ReadValue<Vector2>();
        
        if (movementDir != Vector2.zero)
        {
            latestDir = movementDir;
        }

        CheckFacedDirection();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!_playerStates.CanControl) return;

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

    public void SetCutsceneMovement(bool canMove)
    {
        _playerStates.CanControl = false;
        if (!canMove) cutsceneMovementDir = Vector2.zero;
        else 
        {
            cutsceneMovementDir = movementDir;
        }
        StartCoroutine(_playerStates.TimeToGiveBackControl(1.5f));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
