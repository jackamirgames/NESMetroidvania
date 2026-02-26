using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance { get; private set; }

    public CinemachineCamera mainCam1;
    public CinemachineCamera mainCam2;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than 1 Camera Manager. FIX IT NOW");
        }
        instance = this;
    }

    private void Start()
    {
        SetupCams();
    }

    private void SetupCams()
    {
        mainCam1.Priority = 1;
        mainCam2.Priority = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwapCams();
        }
    }

    public void SwapCams()
    {
        if (mainCam1.Priority == 0) //Make Cam1 Active
        {
            mainCam1.Priority = 1;
            mainCam2.Priority = 0;
        }
        else //Make Cam2 Active
        {
            mainCam1.Priority = 0;
            mainCam2.Priority = 1;
        }
    }
}
