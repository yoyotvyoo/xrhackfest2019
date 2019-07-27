using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lv3 : MonoBehaviour
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
        animator.Play("male_act_strafing_loop");
        Debug.Log("[Lv3] Yor are fucked.");
		GameConsole.instance.GameFail();
    }

    private IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(3.0f);
        // SceneManager.LoadScene("Lv2_Interview");
    }
}
