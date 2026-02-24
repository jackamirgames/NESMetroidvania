using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    public int Health
    {
        get { return _health; }
        set { _health = value; }
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
