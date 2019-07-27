using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv4Console : MonoBehaviour
{
	public GameObject[] girls;
	public GameObject tvScreen;
	public GameObject tvNoise;
	
	public int index;
	
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<girls.Length; i++)
		{
			girls[i].SetActive(false);
		}
		// index = -1;
		// StartCoroutine(TVShow());
		SetNoise(false);
    }
	
	
	void SetNoise(bool val)
	{
      tvScreen.SetActive(!val);
	  tvNoise.SetActive(val);
	}

   IEnumerator TVShow()
   {
	  
	  int i = 0;
	  
	  SetNoise(false);
      yield return new WaitForSeconds(2.0f);
	  
	  SetNoise(true);
	  // girls[index].SetActive(false);
      yield return new WaitForSeconds(1.0f);
	  girls[i].SetActive(true);
	  
	  SetNoise(false);
      yield return new WaitForSeconds(2.0f);
	  
	  SetNoise(true);
	  girls[i].SetActive(false);
	  i++;
      yield return new WaitForSeconds(1.0f);
	  girls[i].SetActive(true);
	  
	  SetNoise(false);
      yield return new WaitForSeconds(2.0f);
	  
	  SetNoise(true);
	  girls[i].SetActive(false);
	  i++;
      yield return new WaitForSeconds(1.0f);
	  girls[i].SetActive(true);
	  
	  SetNoise(false);
      yield return new WaitForSeconds(2.0f);
	  
	  SetNoise(true);
	  girls[i].SetActive(false);
	  i++;
      yield return new WaitForSeconds(1.0f);
	  girls[i].SetActive(true);
	  
	  SetNoise(false);
      yield return new WaitForSeconds(2.0f);
     
   }
	

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") )
		{
			/*if(index >= 0 )
				girls[index].SetActive(false);
			
			
			if(index < girls.Length )
			{
				index++;
				girls[index].SetActive(true);
			}*/
			
			StartCoroutine(TVShow());
		}
    }
}
