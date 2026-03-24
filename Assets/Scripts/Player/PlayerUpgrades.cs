using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    //JUMPING UPGRADES
    public enum JumpUpgrades
    {
        Low = 5,
        Normal = 11,
    }

    [SerializeField] private JumpUpgrades _currentJump;
    public JumpUpgrades CurrentJump
    {
        get { return _currentJump; }
        set { _currentJump = value; }
    }

    public int GetJumpPower()
    {
        return (int)CurrentJump;
    }

    //ATTACK UPGRADES
    [SerializeField] private bool _attackUnlocked;
    public bool AttackUnlocked
    {
        get { return _attackUnlocked; }
        set { _attackUnlocked = value; }
    }
}
