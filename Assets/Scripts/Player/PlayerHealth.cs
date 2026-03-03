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

    private void Start()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log(Health);

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
