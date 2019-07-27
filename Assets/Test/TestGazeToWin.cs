using UnityEngine;

public class TestGazeToWin : MonoBehaviour
{
    void OnEnable()
    {
        GazeRaycaster.initialGazeState = GazeRaycaster.GazeState.OnTarget;
        GazeRaycaster.LeaveGazeTarget.AddListener(LeaveGazeTarget);
        GazeRaycaster.EnterGazeTarget.AddListener(EnterGazeTarget);
    }

    void OnDisable()
    {
        GazeRaycaster.LeaveGazeTarget.RemoveListener(LeaveGazeTarget);
        GazeRaycaster.EnterGazeTarget.RemoveListener(EnterGazeTarget);
    }

    private void EnterGazeTarget()
    {
        // Debug.Log("Enter the target.");
    }

    private void LeaveGazeTarget()
    {
        Debug.Log("[LeaveGazeTarget] Sorry. You are fucked.");
    }
}
