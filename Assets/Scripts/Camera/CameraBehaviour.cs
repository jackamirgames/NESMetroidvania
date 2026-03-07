using UnityEngine;
using Unity.Cinemachine;

public class CameraBehaviour : MonoBehaviour
{
    public RoomDataSO currentRoomData;

    public LockCamera _lockCamera;
    public CinemachineConfiner2D _cinemachineConfiner2D;

    private void Awake()
    {
        _lockCamera = GetComponent<LockCamera>();
        _cinemachineConfiner2D = GetComponent<CinemachineConfiner2D>();
    }

    private void Start()
    {
        GetComponent<CinemachineCamera>().Target.TrackingTarget = GameObject.Find("Player").transform;
    }

    public void AssignCameraDetails(RoomDataSO newRoom, BoxCollider2D newRoomBorder)
    {
        currentRoomData = newRoom;

        _lockCamera.lockXPos = currentRoomData.lockXPos;
        _lockCamera.m_XPosition = currentRoomData.xCamPos;

        _lockCamera.lockYPos = currentRoomData.lockYPos;
        _lockCamera.m_YPosition = currentRoomData.yCamPos;

        _cinemachineConfiner2D.BoundingShape2D = newRoomBorder;
    }
}
