using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
	public Text myText;
	public float startFadeIn;
	public float delay;
	public float fadeLength = 0.5f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Time.time - startFadeIn < fadeLength)
		{
			Color temp = myText.color;
			temp.a = Mathf.Lerp(0f, 1f, (Time.time - startFadeIn)/fadeLength  );
			myText.color = temp;			
		}
    }
	
	void OnEnable()
	{
		startFadeIn = Time.time + delay;
	}
}
