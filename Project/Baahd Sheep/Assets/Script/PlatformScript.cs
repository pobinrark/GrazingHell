using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {
    public BoxCollider platform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            platform.enabled = false;
        }
    }
    void OnTriggerExit()
    {
        platform.enabled = true;
    }
}
