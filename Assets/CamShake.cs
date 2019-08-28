using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CamShake : MonoBehaviour
{
	public float magnitude;
	public float roughness;
	public float fadeInTime;
	public float fadeOutTime;
	public Vector3 posInfluence;
	public Vector3 rotInfluence;
	
	public Transform cam;
	public Transform camShell;
	
	public AudioSource myAudio;
	
    // Start is called before the first frame update
    void Start()
    {
        // Invoke("AttackShell", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2") )
		{
			Shake();
		}
    }
	
	public void AttackShell()
	{
		// camShell.position = cam.position;
		// cam.parent = camShell;
	}
	
	public void Shake()
	{
		CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime, posInfluence, rotInfluence);
		myAudio.Play();
	}
}
