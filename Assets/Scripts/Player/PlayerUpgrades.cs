using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    public enum JumpUpgrades
    {
        None = 3,
        Upgrade1 = 6,
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
}
