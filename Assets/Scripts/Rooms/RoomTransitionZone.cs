using UnityEngine;

public class RoomTransitionZone : MonoBehaviour
{
    [SerializeField] private RoomDataSO roomLeft;
    [SerializeField] private RoomDataSO roomRight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (IsPlayerMovingRight(collision))
            {
                CameraManager.instance.MoveToNextRoom(roomRight);
            }
            else
            {
                CameraManager.instance.MoveToNextRoom(roomLeft);
            }

            collision.gameObject.GetComponent<PlayerMovement>().SetCutsceneMovement(true);
        }
    }

    private bool IsPlayerMovingRight(Collider2D collision)
    {
        return collision.gameObject.GetComponent<PlayerMovement>().IsFacingRight;
    }
}
