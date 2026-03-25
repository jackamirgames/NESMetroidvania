using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb;

    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float walkSpeed;
    private float raycastXOffset;
    private bool isWalkingRight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (walkSpeed >= 0)
        {
            isWalkingRight = true;
            raycastXOffset = 0.5f;
        }
        else
        {
            isWalkingRight = false;
            raycastXOffset = -0.5f;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(walkSpeed * Time.fixedDeltaTime * 10f, rb.linearVelocity.y);

        GroundCheck();
    }

    public void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + raycastXOffset, transform.position.y), -Vector2.up, 1f, groundMask);

        if (!hit)
        {
            walkSpeed = -walkSpeed;
            raycastXOffset = -raycastXOffset;
        }
    }
}
