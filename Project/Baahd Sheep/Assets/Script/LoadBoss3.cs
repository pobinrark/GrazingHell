using UnityEngine;
using System.Collections;

public class LoadBoss3 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerExit (Collider Bean)
		{
		if(Bean.gameObject.CompareTag("Player")){
			print ("trigger boss 3");

			Application.LoadLevel ("boss3");
			}
		}
}
