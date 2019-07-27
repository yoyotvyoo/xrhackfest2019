using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv5Medusa : MonoBehaviour
{
	public Transform player;
	public Transform movingTarget;
	public float speed;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
		transform.position = Vector3.Lerp(transform.position, movingTarget.position, speed * Time.deltaTime);
    }
}
