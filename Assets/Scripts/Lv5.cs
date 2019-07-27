using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lv5 : MonoBehaviour
{
    public Animator animator;

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
        animator.Play("Atk4_wing_loop");
        Debug.Log("[Lv5] Yor are fucked.");
        StartCoroutine(DelayLoadScene());
        // Debug.Log("Enter the target.");
    }

    private void LeaveGazeTarget()
    {
        // Debug.Log("Leave the target.");
    }

    private IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(3.0f);
        // SceneManager.LoadScene("Lv2_Interview");
    }
}
