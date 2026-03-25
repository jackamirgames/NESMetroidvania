using UnityEngine;

public class EnemyCeilingHang : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb;

    [SerializeField] private float fallSpeed;
    [SerializeField] private float climbSpeed;

    private enum HangStates 
    {
        fall,
        climb,
        idle
    }
    [SerializeField] private HangStates currentState;

    [SerializeField] private LayerMask groundMask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case HangStates.fall:
                rb.linearVelocity = new Vector2(rb.linearVelocityX, fallSpeed * Time.fixedDeltaTime * 10f);
                CheckForGroundBelow();
                break;
            case HangStates.climb:
                rb.linearVelocity = new Vector2(rb.linearVelocityX, climbSpeed * Time.fixedDeltaTime * 10f);
                CheckForGroundAbove();
                break;
            case HangStates.idle:

                break;
        }
    }

    private void CheckForGroundBelow()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), -Vector2.up, 1f, groundMask);

        if (hit)
        {
            currentState = HangStates.climb;
        }
    }

    private void CheckForGroundAbove()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.5f), Vector2.up, 1f, groundMask);

        if (hit)
        {
            currentState = HangStates.fall;
        }
    }
}
