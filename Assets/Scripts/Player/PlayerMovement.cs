using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Other Player scripts
    private PlayerStates _playerStates;
    private PlayerUpgrades _playerUpgrades;

    //Variables
    [SerializeField] private float moveSpeed;
    private Vector2 movementDir;
    private Vector2 latestDir;
    [SerializeField] private bool isFacingRight;
    public bool IsFacingRight
    {
        get { return isFacingRight; }
        set { isFacingRight = value; }
    }

    [Header("Jump Checks")]
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private GameObject attackPos;

    private bool isDucking;
    private bool isCurrentlyOnGround;

    //Events
    public event Action<bool> PlayerJumped;
    public event Action<float> PlayerStartedMovement;
    public event Action<bool> PlayerChangedFacedDirection;
    public event Action<bool> PlayerChangedDuckingState;

    //Cutscene Stuff
    private Vector2 cutsceneMovementDir;

    private Rigidbody2D rb;
    private void Awake()
    {
        _playerStates = GetComponent<PlayerStates>();
        _playerUpgrades = GetComponent<PlayerUpgrades>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        isFacingRight = true;
        isDucking = false;
        isCurrentlyOnGround = isGrounded();
    }

    private void FixedUpdate()
    {
        if (isDucking) return;

        if (_playerStates.CanControl)
        {
            rb.linearVelocity = new Vector2(movementDir.x * moveSpeed * Time.fixedDeltaTime * 10f, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(cutsceneMovementDir.x * moveSpeed * Time.fixedDeltaTime * 10f, rb.linearVelocity.y);
        }

        //Prevents needing the event to be called every frame. Is now only called when the ground state changes
        if (isCurrentlyOnGround != isGrounded())
        {
            OnPlayerJumped(isGrounded());
            Debug.Log("Changed ground state: " + isGrounded());
        }
        isCurrentlyOnGround = isGrounded();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementDir = context.ReadValue<Vector2>();
        
        if (movementDir != Vector2.zero && movementDir != latestDir)
        {
            latestDir = movementDir;
        }

        CheckFacedDirection();

        OnPlayerChangedFacedDirection(isFacingRight);
        OnPlayerStartedMovement(Mathf.Abs(movementDir.x));
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!_playerStates.CanControl) return;

        if (context.performed && isGrounded())
        {
            rb.AddForce(new Vector2(0f, 100f * _playerUpgrades.GetJumpPower()), ForceMode2D.Force);
            OnPlayerJumped(true);
        }

        if (context.canceled)
        {
            if (rb.linearVelocity.y <= 0f) return;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        }
    }

    public void Duck(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            rb.linearVelocityX = 0f;
            isDucking = true;
            OnPlayerChangedDuckingState(isDucking);
        }
    }

    public void UnDuck(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isDucking = false;
            OnPlayerChangedDuckingState(isDucking);
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
        StartCoroutine(_playerStates.TimeToGiveBackControl(1f));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    private void OnPlayerJumped(bool inJump)
    {
        PlayerJumped?.Invoke(inJump);
    }

    private void OnPlayerStartedMovement(float dir)
    {
        PlayerStartedMovement?.Invoke(dir);
    }

    private void OnPlayerChangedFacedDirection(bool isFacingRight)
    {
        PlayerChangedFacedDirection?.Invoke(isFacingRight);
    }

    private void OnPlayerChangedDuckingState(bool isDucking)
    {
        PlayerChangedDuckingState?.Invoke(isDucking);
    }
}
