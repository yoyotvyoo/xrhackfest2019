using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv4Console : MonoBehaviour
{
	public GameObject[] girls;
	public int index;
	
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<girls.Length; i++)
		{
			girls[i].SetActive(false);
		}
		index = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") )
		{
			if(index >= 0 )
				girls[index].SetActive(false);
			
			
			if(index < girls.Length )
			{
				index++;
				girls[index].SetActive(true);
			}
		}
    }
}
