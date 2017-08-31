using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

    bool startTimers;
    float immuneTime = 0.0f;
    float blinkRate = 0.0f;
    // Use this for initialization
    void Start () {
        startTimers = false;
	}
	
	// Update is called once per frame
	void Update () {
        immuneTime += Time.deltaTime;
        blinkRate += Time.deltaTime;
        
	}
    public void blinking(Material mat1, Material mat2)
    {
        immuneTime = 0.0f;
        blinkRate = 0.0f;
        startTimers = true;
        gameObject.GetComponent<SpriteRenderer>().material = mat1;
        while (immuneTime < 10.0f)
        {   
            if (blinkRate > 5.0f)
            {
                Debug.Log("in blink");
                gameObject.GetComponent<SpriteRenderer>().material = mat2;
                blinkRate = 0.0f;
            }
        }
        //yield return new WaitForSeconds(1);
        //gameObject.GetComponent<SpriteRenderer>().material = mat2;
        
    }
}
