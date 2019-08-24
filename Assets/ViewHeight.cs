using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewHeight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		#if UNITY_EDITOR
			transform.localPosition = Vector3.up * 1.7f;
		#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
