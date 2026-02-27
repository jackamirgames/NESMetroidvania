using UnityEngine;

public class RoomTransitionZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraManager.instance.SwapCams();

            collision.gameObject.GetComponent<PlayerMovement>().SetCutsceneMovement(true);
        }
    }
}
