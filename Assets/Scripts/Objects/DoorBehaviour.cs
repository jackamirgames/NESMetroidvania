using UnityEditor.Scripting;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour, IDamageable
{
    [SerializeField] private int _doorHits;
    public int DoorHits
    {
        get { return _doorHits; }
        set { _doorHits = value; }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Here");

        DoorHits--;

        if (DoorHits <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Make it deactivate, and then reactivate after a certain amount of time/new room
        Destroy(gameObject);
    }
}
