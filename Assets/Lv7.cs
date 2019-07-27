using UnityEngine;

public class Lv7 : MonoBehaviour
{
    void OnEnable()
    {
        GazeRaycaster.initialGazeState = GazeRaycaster.GazeState.OffTarget;
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
        Debug.Log("[EnterGazeTarget] Sorry. You are fucked.");
		GameConsole.instance.GameSuccess();
    }

    private void LeaveGazeTarget()
    {
        // Debug.Log("Leave the target.");
    }
}
