using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField] private float moveSpeed;
    private Vector2 movementDir;
    [SerializeField] private float jumpForce;

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
        Debug.Log(rb.linearVelocity);
        //rb.linearVelocity = new Vector2 (movementDir.x, rb.linearVelocity.y) * moveSpeed * Time.fixedDeltaTime * 10f;
        //rb.MovePosition(transform.position + new Vector3(movementDir.x * moveSpeed * Time.fixedDeltaTime, 0f, 0f));
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementDir = context.ReadValue<Vector2>();
        //Debug.Log(movementDir);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jumped");
            //rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            rb.AddForce(new Vector2(0f, 10f * jumpForce), ForceMode2D.Force);
        }
    }
}
