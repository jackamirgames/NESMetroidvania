using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    public enum JumpUpgrades
    {
        Low = 3,
        Normal = 6,
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
