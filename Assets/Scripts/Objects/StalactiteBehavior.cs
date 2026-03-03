using UnityEngine;

public class StalactiteBehavior : MonoBehaviour
{
    [SerializeField] private int damageDealt;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IDamageable>() != null)
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(damageDealt);
        }

        Destroy(gameObject);
    }
}
