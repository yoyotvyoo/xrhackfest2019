using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDriving : MonoBehaviour
{
	public Transform destination;
    public float speed = 1;
	public float offset;
	public float freq;
	public Vector3 basePos;
	public Quaternion initRot;
	public float angleOffset;

    // Update is called once per frame
    void Update()
    {
        basePos = Vector3.MoveTowards(basePos, destination.position, speed * Time.deltaTime);
		// transform.position = basePos;
		transform.position = basePos + transform.right * (offset*-1f + 2 * Mathf.PingPong(Time.time * freq * offset, offset));
		transform.rotation = initRot;
		transform.Rotate(Vector3.up * (angleOffset*-1f + 2 * Mathf.PingPong( (Time.time * freq + 0.5f) * angleOffset, angleOffset)) );
    }
	
    // Start is called before the first frame update
    void Start()
    {
        basePos = transform.position;
        initRot = transform.rotation;
    }
}
