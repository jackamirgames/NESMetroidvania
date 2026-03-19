using UnityEngine;

public class RoomTransitionZone : MonoBehaviour
{
    [Header("Room to the left")]
    [SerializeField] private RoomDataSO roomLeft;
    [SerializeField] private BoxCollider2D roomLeftBorder;
    [Header("Room to the right")]
    [SerializeField] private RoomDataSO roomRight;
    [SerializeField] private BoxCollider2D roomRightBorder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (IsPlayerMovingRight(collision))
            {
                CameraManager.instance.MoveToNextRoom(roomRight, roomRightBorder);
            }
            else
            {
                CameraManager.instance.MoveToNextRoom(roomLeft, roomLeftBorder);
            }

            collision.gameObject.GetComponent<PlayerMovement>().SetCutsceneMovement(true);
        }
    }

    private bool IsPlayerMovingRight(Collider2D collision)
    {
        return collision.gameObject.GetComponent<PlayerStates>().IsFacingRight;
    }
}
