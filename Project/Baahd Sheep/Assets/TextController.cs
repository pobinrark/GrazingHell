using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour {

	public MeshRenderer PressRight;

	public MeshRenderer TextOne;
	public MeshRenderer TextTwo;
	public MeshRenderer TextThree;
	public MeshRenderer TextFour;
	public MeshRenderer TextFive;
	public MeshRenderer TextSix;
	public MeshRenderer TextSeven;

	public int pressed;
	public BoxCollider collider;

	// Use this for initialization
	void Start () {
		pressed = 0;
		PressRight.enabled = true;
		TextOne.enabled = true;
		TextTwo.enabled = false;
		TextThree.enabled = false;
		TextFour.enabled = false;
		TextFive.enabled = false;
		TextSix.enabled = false;
		TextSeven.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Text ();
	}

	void Text(){

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			pressed = pressed + 1;
		}

		if (pressed == 1) {
			TextOne.enabled = false;
			TextTwo.enabled = true;
			TextThree.enabled = false;
			TextFour.enabled = false;
			TextFive.enabled = false;
			TextSix.enabled = false;
			TextSeven.enabled = false;
		}

		if (pressed == 2) {
			TextOne.enabled = false;
			TextTwo.enabled = false;
			TextThree.enabled = true;
			TextFour.enabled = false;
			TextFive.enabled = false;
			TextSix.enabled = false;
			TextSeven.enabled = false;
		}

		if (pressed == 3) {
			TextOne.enabled = false;
			TextTwo.enabled = false;
			TextThree.enabled = false;
			TextFour.enabled = true;
			TextFive.enabled = false;
			TextSix.enabled = false;
			TextSeven.enabled = false;
		}


		if (pressed == 4) {
			TextOne.enabled = false;
			TextTwo.enabled = false;
			TextThree.enabled = false;
			TextFour.enabled = false;
			TextFive.enabled = true;
			TextSix.enabled = false;
			TextSeven.enabled = false;
		}

		if (pressed == 5) {
			TextOne.enabled = false;
			TextTwo.enabled = false;
			TextThree.enabled = false;
			TextFour.enabled = false;
			TextFive.enabled = false;
			TextSix.enabled = true;
			TextSeven.enabled = false;
		}

		if (pressed == 6) {
			TextOne.enabled = false;
			TextTwo.enabled = false;
			TextThree.enabled = false;
			TextFour.enabled = false;
			TextFive.enabled = false;
			TextSix.enabled = false;
			TextSeven.enabled = true;
			MovePlayer ();
		}

		if (pressed > 7) {
			TextOne.enabled = false;
			TextTwo.enabled = false;
			TextThree.enabled = false;
			TextFour.enabled = false;
			TextFive.enabled = false;
			TextSix.enabled = false;
			TextSeven.enabled = false;
			
			PressRight.enabled = false;
			
			}

		}


	void MovePlayer(){	
		collider.enabled = false;
	}

}
