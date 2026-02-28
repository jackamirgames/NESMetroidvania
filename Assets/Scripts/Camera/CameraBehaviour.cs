using UnityEngine;
using Unity.Cinemachine;

public class CameraBehaviour : MonoBehaviour
{
    public RoomDataSO currentRoomData;

    public LockCamera _lockCamera;

    private void Awake()
    {
        _lockCamera = GetComponent<LockCamera>();
    }

    public void AssignCameraDetails(RoomDataSO newRoom)
    {
        currentRoomData = newRoom;

        _lockCamera.lockXPos = currentRoomData.lockXPos;
        _lockCamera.m_XPosition = currentRoomData.xCamPos;

        _lockCamera.lockYPos = currentRoomData.lockYPos;
        _lockCamera.m_YPosition = currentRoomData.yCamPos;
    }
}
