using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv4 : MonoBehaviour
{
    public GameObject[] girls;
    public GameObject tvScreen;
    public GameObject tvNoise;

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < girls.Length; i++)
        {
            girls[i].SetActive(false);
        }
        // index = -1;
        // StartCoroutine(TVShow());
        SetNoise(false);

        StartCoroutine(TVShow());
    }


    void SetNoise(bool val)
    {
        tvScreen.SetActive(!val);
        tvNoise.SetActive(val);
    }

    IEnumerator TVShow()
    {

        int i = 0;

        SetNoise(false);
        yield return new WaitForSeconds(2.0f);

        SetNoise(true);
        // girls[index].SetActive(false);
        yield return new WaitForSeconds(1.0f);
        girls[i].SetActive(true);

        SetNoise(false);
        yield return new WaitForSeconds(2.0f);

        SetNoise(true);
        girls[i].SetActive(false);
        i++;
        yield return new WaitForSeconds(1.0f);
        girls[i].SetActive(true);

        SetNoise(false);
        yield return new WaitForSeconds(2.0f);

        SetNoise(true);
        girls[i].SetActive(false);
        i++;
        yield return new WaitForSeconds(1.0f);
        girls[i].SetActive(true);

        SetNoise(false);
        yield return new WaitForSeconds(2.0f);

        SetNoise(true);
        girls[i].SetActive(false);
        i++;
        yield return new WaitForSeconds(1.0f);
        girls[i].SetActive(true);

        //SetNoise(false);
        //yield return new WaitForSeconds(2.0f);

    }
	
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
        // animator.Play("male_emotion_angry_loop");
        Debug.Log("[Lv4] Yor are fucked.");
		GameConsole.instance.GameFail();
		
        // StartCoroutine(DelayLoadScene());
    }

}
