﻿using UnityEngine;
using System.Collections;

public class FireTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit");
            playerControls.health--;
        }
    }
}
