using UnityEngine;

public class PerformanceManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Screen.SetResolution(256, 240, false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Screen.SetResolution(512, 480, false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Screen.SetResolution(1024, 960, false);
        }
    }
}
