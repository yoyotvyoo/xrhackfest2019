using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lv1 : MonoBehaviour
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
        animator.Play("male_emotion_angry_loop");
        Debug.Log("[Lv1] Yor are fucked.");
        StartCoroutine(DelayLoadScene());
    }

    private IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(3.0f);
        // SceneManager.LoadScene("Lv1_Interview");
    }
}
