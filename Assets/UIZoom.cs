using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIZoom : MonoBehaviour
{
    public Vector3 startScale;
	public Vector3 endScale;
	
	public float startZoom;
	public float zoomLength;
	public float zoomDelay;
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.localScale = Vector3.Lerp(transform.localScale, endScale, (Time.time - startZoom - zoomDelay)/zoomLength  );
    }

    void OnEnable()
    {
		transform.localScale = startScale;
        startZoom = Time.time;
    }
}
