using UnityEngine;

public class PlayerKnockback : MonoBehaviour, IKnockbackable
{
    //Variables
    private Rigidbody2D rb;
    private PlayerStates _playerStates;
    private PlayerHealth _playerHealth;

    private float tempKnockbackTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerStates = GetComponent<PlayerStates>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _playerHealth.PlayerDamaged += StartKnockback;
    }

    private void OnDisable()
    {
        _playerHealth.PlayerDamaged -= StartKnockback;
    }

    private void Update()
    {
        if (_playerStates.currentPlayerState == PlayerMovementStates.InKnockback)
        {
            tempKnockbackTimer -= Time.deltaTime;

            if (tempKnockbackTimer <= 0)
            {
                rb.linearVelocityY = 0;
                _playerStates.currentPlayerState = PlayerMovementStates.Idle;
            }
        }
    }

    public void StartKnockback(Vector2 enemyPos)
    {
        TakeKnockback(750, enemyPos, 0.125f);
    }

    private Vector2 knockbackDir;
    public void TakeKnockback(float knockbackForce, Vector2 otherObjPos, float knockbackTimer)
    {
        _playerStates.currentPlayerState = PlayerMovementStates.InKnockback;
        rb.linearVelocity = Vector2.zero;

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
    }
}
