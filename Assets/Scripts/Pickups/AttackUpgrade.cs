using UnityEngine;

public class AttackUpgrade : MonoBehaviour, IUnlockable
{
    public void AbilityUnlock(PlayerUpgrades _playerUpgrades)
    {
        _playerUpgrades.AttackUnlocked = true;
    }
}
