using System.Collections;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Moving,
    Attacking,
    Jumping,
}

public class PlayerStates : MonoBehaviour
{
    [SerializeField] private bool _canControl;
    public bool CanControl
    {
        get { return _canControl; }
        set { _canControl = value; }
    }

    public PlayerState currentPlayerState;

    public IEnumerator TimeToGiveBackControl(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        CanControl = true;
        Debug.Log("Here");
    }
}
