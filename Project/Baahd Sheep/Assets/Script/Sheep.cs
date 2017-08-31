using UnityEngine;
using System.Collections;

public class Sheep : MonoBehaviour {

	public Vector3 PlayPosition = new Vector3(0.0f,0.0f,0.0f);
	public Vector3 InstructionsPosition = new Vector3(0.0f,0.0f,0.0f);

	// Use this for initialization
	void Start () {
		
}
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			transform.position = InstructionsPosition;
		}

		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			transform.position = PlayPosition;
		}
	}


	void OnTriggerEnter(Collider col)
	{
			
		if (col.gameObject.CompareTag ("Play")) {
			print ("I am on Play");
			Play ();
		}
				

		if (col.gameObject.CompareTag ("Instructions")) {
			print ("I am on Instructions");
			Instructions ();
		}
	}

	void Play ()
	{
		if (Input.GetKeyDown (KeyCode.Return)) {
			//Application.LoadLevel ("boss1");
			print ("i hit enter on play");

		}
	}

	void Instructions (){
		if (Input.GetKeyDown (KeyCode.Return)) {
			print ("i hit enter on instructions");
			//Application.LoadLevel ("Instructions");
		}
	}

}


			