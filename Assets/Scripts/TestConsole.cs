﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestConsole : MonoBehaviour
{
	public Text camPos;
	public Transform cam;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // camPos.text = System.String.Format("Cam: {0}", cam.position);
		if(Input.GetButtonDown("Jump") )
		{
			Debug.Log("Time stall");
			Time.timeScale = 0.1f;
		}
		
		if(Input.GetButtonUp("Jump") )
		{
			Time.timeScale = 1f;
			Debug.Log("Time return");
		}
    }
}
