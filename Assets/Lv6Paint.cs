using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv6Paint : MonoBehaviour
{
	public float rotateSpeed;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
	
	public void SetSpeed(float val)
	{
		rotateSpeed = val;
	}
}
