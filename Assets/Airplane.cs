using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
	public Rigidbody rb;
	public bool isNew;
	public float speed;
	public Transform cam;
	public Transform paint;
	
	public float hitTime;
	
	public Quaternion rot;
	
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
		// rot = paint.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
		if(!isNew)
			Time.timeScale = Mathf.Lerp(0.1f, 0.3f, (Time.time - hitTime)/3f );
    }
	
	void OnCollisionEnter(Collision collision)
    {
		if(isNew)
		{
			// Time.timeScale = 0.1f;
			rb.useGravity = true;
			paint.parent = cam;
			paint.localPosition = new Vector3(0, -0.122f, 1.6f);
			paint.localRotation = rot;
			
			paint.SendMessage("SetSpeed", 60f);
			
			isNew = false;
			hitTime = Time.time;
		}
    }
}
