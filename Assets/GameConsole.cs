using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConsole : MonoBehaviour
{
	public static GameConsole instance;
	public float targetTime;
	public float startTime;
	
	public bool hasResult;
	public GameObject successPanel;
	public string successSce;
	public GameObject failPanel;
	public string failSce;
	
	public bool isFocus = true;
	
    // Start is called before the first frame update
    void Start()
    {
		GameConsole.instance = this;
        startTime = Time.time;
		successPanel.SetActive(false);
		failPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasResult && Time.time - startTime > targetTime)
		{
			hasResult = true;
			
			if(isFocus)
			{
				successPanel.SetActive(true);
				Invoke("NextStage", 3f);
			}
			else
			{
				GameFail();
			}
		}
    }
	
	public void GameSuccess()
	{
		if(!hasResult)
		{
			hasResult = true;
			successPanel.SetActive(true);
			Invoke("NextStage", 3f);
		}
	}
	
	public void GameFail()
	{
		if(!hasResult)
		{
			hasResult = true;
			failPanel.SetActive(true);
			Invoke("RestartStage", 3f);
		}
	}
	
	public void NextStage()
	{
		SceneManager.LoadScene(successSce);
	}
	
	public void RestartStage()
	{
		SceneManager.LoadScene(failSce);
	}
}
