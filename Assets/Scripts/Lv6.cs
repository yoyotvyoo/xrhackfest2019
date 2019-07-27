using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv6 : MonoBehaviour
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
        // animator.Play("Atk4_wing_loop");
        // Debug.Log("Enter the target.");
    }

    private void LeaveGazeTarget()
    {
        // Debug.Log("Leave the target.");
        Debug.Log("[Lv6] Yor are fucked.");
		GameConsole.instance.GameFail();
    }
}
