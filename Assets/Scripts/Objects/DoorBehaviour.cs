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

    [Space]
    [SerializeField] private GameObject DoorPair;

    public void TakeDamage(int damage)
    {
        DoorHits--;

        if (DoorHits <= 0)
        {
            if (DoorPair != null) DoorPair.GetComponent<IDamageable>().Die();
            Die();
        }
    }

    public void Die()
    {
        //Make it deactivate, and then reactivate after a certain amount of time/new room
        Destroy(gameObject);
    }
}
