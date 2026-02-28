using UnityEngine;

[CreateAssetMenu(fileName = "RoomDataSO", menuName = "Scriptable Objects/RoomDataSO")]
public class RoomDataSO : ScriptableObject
{
    [Header("Camera Data")]
    public bool lockXPos;
    public float xCamPos;
    public bool lockYPos;
    public float yCamPos;
}
