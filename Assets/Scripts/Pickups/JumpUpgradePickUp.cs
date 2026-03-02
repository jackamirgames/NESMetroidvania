using UnityEngine;

public class JumpUpgradePickUp : MonoBehaviour, IUnlockable
{
    [SerializeField] private PlayerUpgrades.JumpUpgrades thisJumpUpgrade;

    public void AbilityUnlock(PlayerUpgrades _playerUpgrades)
    {
        _playerUpgrades.CurrentJump = thisJumpUpgrade;
    }
}
