using UnityEngine;

public class PlayerKnockback : MonoBehaviour, IKnockbackable
{
    //Variables
    private Rigidbody2D rb;
    private PlayerStates _playerStates;

    private float tempKnockbackTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerStates = GetComponent<PlayerStates>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeKnockback(100, Vector2.zero, 1f);
        }

        if (_playerStates.currentPlayerState == PlayerMovementStates.InKnockback)
        {
            tempKnockbackTimer -= Time.deltaTime;

            if (tempKnockbackTimer <= 0)
            {
                _playerStates.currentPlayerState = PlayerMovementStates.Idle;
            }
        }
    }

    private Vector2 knockbackDir;
    public void TakeKnockback(float knockbackForce, Vector2 otherObjPos, float knockbackTimer)
    {
        //Calculate the direction the player will be hit in
        if (transform.position.x >= otherObjPos.x)
        {
            knockbackDir = new Vector2(1, 1);
        }
        else
        {
            knockbackDir = new Vector2(-1, 1);
        }

        rb.AddForce(knockbackDir * knockbackForce);

        tempKnockbackTimer = knockbackTimer;
        _playerStates.currentPlayerState = PlayerMovementStates.InKnockback;
    }
}
