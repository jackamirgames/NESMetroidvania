using Unity.Cinemachine;
using UnityEngine;

public class LockCamera : CinemachineExtension
{
    [Header("X-Pos")]
    public bool lockXPos;
    [Tooltip("Lock the camera's X position to this value")]
    public float m_XPosition = 0;

    [Header("Y-Pos")]
    public bool lockYPos;
    [Tooltip("Lock the camera's Y position to this value")]
    public float m_YPosition = 0;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        LockXAxis(vcam, stage, ref state, deltaTime);
        LockYAxis(vcam, stage, ref state, deltaTime);
    }

    private void LockXAxis(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (!lockXPos) return;

        if (enabled && stage == CinemachineCore.Stage.Finalize)
        {
            var pos = state.GetCorrectedPosition();
            pos.x = m_XPosition;
            state.RawPosition = pos;
            state.PositionCorrection = Vector3.zero;
        }
    }

    private void LockYAxis(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (!lockYPos) return;

        if (enabled && stage == CinemachineCore.Stage.Finalize)
        {
            var pos = state.GetCorrectedPosition();
            pos.y = m_YPosition;
            state.RawPosition = pos;
            state.PositionCorrection = Vector3.zero;
        }
    }
}
