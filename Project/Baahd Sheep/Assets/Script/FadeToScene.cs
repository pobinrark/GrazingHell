using UnityEngine;
using System.Collections;

public class FadeToScene : MonoBehaviour {
	float timeToFade = 1.5f;
	float fadeTime = 0.8f;
	public bool isUSC;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeToFade -= Time.deltaTime;
		if (timeToFade <= 0) {
			Debug.Log("in fade");
			GameObject.Find("Logo").GetComponent<Fading>().BeginFade(1);
			fadeTime -= Time.deltaTime;

			if(fadeTime <= 0)
			{
				if(isUSC)
					Application.LoadLevel("BerkleeLogo");
				else
					Application.LoadLevel("MainMenu_Good");
			}
		}
	}
}
