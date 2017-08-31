using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {
    public GameObject[] Fire;
    public int count = 0;
    public int count2 = 16;
    float timeActive = 0.0f;
    float delay = 0.0f;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < Fire.Length; i++)
        {
            Fire[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            Fire[i].GetComponent<BoxCollider>().enabled = false;
        }
        Debug.Log(Fire.Length);
	}
	
	// Update is called once per frame
	void Update () {
        
	    if(enemyBehavior.health <= 3)
        {
            
        }

	}
    public void ShootFire(bool startRight)
    {
        if (!startRight)
        {
            timeActive += Time.deltaTime;
            Fire[count].GetComponentInChildren<SpriteRenderer>().enabled = true;
            Fire[count].GetComponent<BoxCollider>().enabled = true;
            if (timeActive > 0.1f)
            {
                if (count == Fire.Length - 1)
                {
                    Fire[count].GetComponentInChildren<SpriteRenderer>().enabled = false;
                    Fire[count].GetComponent<BoxCollider>().enabled = false;
                    count = 0;
                }
                Debug.Log("Shoot");
                Fire[count].GetComponentInChildren<SpriteRenderer>().enabled = false;
                Fire[count].GetComponent<BoxCollider>().enabled = false;
                count++;
                timeActive = 0.0f;
            }
        }
        else
        {
            timeActive += Time.deltaTime;
            Fire[count2].GetComponentInChildren<SpriteRenderer>().enabled = true;
            Fire[count2].GetComponent<BoxCollider>().enabled = true;
            if (timeActive > 0.1f)
            {
                Debug.Log("Shoot");
                Fire[count2].GetComponentInChildren<SpriteRenderer>().enabled = false;
                Fire[count2].GetComponent<BoxCollider>().enabled = false;
                if (count2 <= 0)
                {
                    Fire[count2].GetComponentInChildren<SpriteRenderer>().enabled = false;
                    Fire[count2].GetComponent<BoxCollider>().enabled = false;
                    count = 17;
                }
                count2--;
                timeActive = 0.0f;
            }
        }

        
    }
    public void DisableAllFire()
    {
        for(int i = 0; i < Fire.Length; i++)
        {
            Fire[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            Fire[i].GetComponent<BoxCollider>().enabled = false;
        }
        count = 0;
        count2 = 16;
    }
}
