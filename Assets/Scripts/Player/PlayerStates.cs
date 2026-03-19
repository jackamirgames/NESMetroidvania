using System.Collections;
using UnityEngine;

public enum PlayerMovementStates
{
    Idle,
    Moving,
    Jumping,
    Ducking
}

public class PlayerStates : MonoBehaviour
{
    [SerializeField] private bool _canControl;
    public bool CanControl
    {
        get { return _canControl; }
        set { _canControl = value; }
    }

    [SerializeField] private bool isFacingRight;
    public bool IsFacingRight
    {
        get { return isFacingRight; }
        set { isFacingRight = value; }
    }

    public PlayerMovementStates currentPlayerState;

    public IEnumerator TimeToGiveBackControl(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        CanControl = true;
    }
}
