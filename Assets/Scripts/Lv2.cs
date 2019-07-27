using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lv2 : MonoBehaviour
{
    public Animator animator;

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
        animator.Play("female_emotion_angry_loop");
        Debug.Log("[Lv2] Yor are fucked.");
		GameConsole.instance.GameFail();
    }

}
