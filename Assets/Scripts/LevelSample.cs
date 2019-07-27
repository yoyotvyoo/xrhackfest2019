using UnityEngine;

public class LevelSample : MonoBehaviour
{
    void OnEnable()
    {
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
        Debug.Log("Enter the target.");
    }

    private void LeaveGazeTarget()
    {
        Debug.Log("Leave the target.");
    }
}
