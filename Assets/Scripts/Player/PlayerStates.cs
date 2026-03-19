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

    public PlayerMovementStates currentPlayerState;

    public IEnumerator TimeToGiveBackControl(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        CanControl = true;
    }
}
