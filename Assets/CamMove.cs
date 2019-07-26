using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {
	public float scaleH;
	public float scaleV;
	public float scaleL;
	public float scaleR;
	public float scaleRv;
	public Transform childCam;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		float l = Input.GetAxis("Lift");
		transform.Translate(Vector3.right * h * Time.deltaTime * scaleH + Vector3.forward * v * Time.deltaTime * scaleV + Vector3.up * l * Time.deltaTime *  scaleL);
		
		float r = Input.GetAxis("Turn");
		transform.Rotate(Vector3.up * r * Time.deltaTime * scaleR);
		float rv = Input.GetAxis("TurnV");
		childCam.Rotate(Vector3.right * rv * Time.deltaTime * scaleRv);
	}
}
