using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private int _health;
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    [SerializeField] private int _maxHealth;
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public event System.Action<Vector2> PlayerDamaged;

    private void Start()
    {
        Health = MaxHealth;
        UIManager.instance.UpdateHealthText(Health);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        UIManager.instance.UpdateHealthText(Health);

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnPlayerDamaged(Vector2 enemyPos)
    {
        PlayerDamaged?.Invoke(enemyPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnPlayerDamaged(collision.transform.position);
            TakeDamage(2);
        }
    }
}
