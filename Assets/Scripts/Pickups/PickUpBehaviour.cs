using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    private IUnlockable _unlockable;

    private void Awake()
    {
        _unlockable = GetComponent<IUnlockable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _unlockable.AbilityUnlock(collision.GetComponent<PlayerUpgrades>());
        }
    }
}
