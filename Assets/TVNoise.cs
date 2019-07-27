﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVNoise : MonoBehaviour
{
	public Renderer myRen;
	public Material mat;
	public Vector2 range;
	
	public float startTime;
	
    // Start is called before the first frame update
    void Start()
    {
        mat = myRen.material;
    }
	
	void OnEnable()
	{
		startTime = Time.time;
	}

    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("_Factor2", Mathf.Lerp(range.x, range.y, (Time.time - startTime)/1f ) );
    }
}
