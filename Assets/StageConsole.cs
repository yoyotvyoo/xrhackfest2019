using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageConsole : MonoBehaviour
{
	public string[] scenes;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1) )
		{
			SceneManager.LoadScene(scenes[0]);
		}
		else if(Input.GetKeyDown(KeyCode.F2) )
		{
			SceneManager.LoadScene(scenes[1]);
		}
		else if(Input.GetKeyDown(KeyCode.F3) )
		{
			SceneManager.LoadScene(scenes[2]);
		}
		else if(Input.GetKeyDown(KeyCode.F4) )
		{
			SceneManager.LoadScene(scenes[3]);
		}
		else if(Input.GetKeyDown(KeyCode.F5) )
		{
			SceneManager.LoadScene(scenes[4]);
		}
		else if(Input.GetKeyDown(KeyCode.F6) )
		{
			SceneManager.LoadScene(scenes[5]);
		}
		else if(Input.GetKeyDown(KeyCode.F7) )
		{
			SceneManager.LoadScene(scenes[6]);
		}
		else if(Input.GetKeyDown(KeyCode.F8) )
		{
			SceneManager.LoadScene("Lv8_pre");
		}
		else if(Input.GetKeyDown(KeyCode.F12) )
		{
			SceneManager.LoadScene("entrance");
		}
    }
	
}
