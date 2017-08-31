using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {
//
//	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
//	private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	public Transform mainMenu, instructionsMenu, creditsMenu;
	public GameObject mainMenuDefault, instructionsMenuDefault, creditsMenuDefault;

//	void Awake ()
//	{
//		// Set the texture so that it is the the size of the screen and covers it.
//		GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
//	}

	public void LoadScene (string name)
	{
        playerControls.health = 5;
        playerControls.lives = 3;
        enemyBehavior.health = 10;
        boss2Behavior.health = 10;
		Application.LoadLevel (name);
        
//		EndScene ();
	}

	public void QuitGame (){
        Application.Quit();
        Debug.Log("Quitting");
	}

	private void SetSelected(GameObject myObject)
	{
		EventSystem.current.SetSelectedGameObject (myObject);
	}

	public void InstructionsMenu(bool clicked)
	{
		if (clicked == true) {
			instructionsMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (false);
			SetSelected (instructionsMenuDefault);
		} else {
			instructionsMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (true);
			SetSelected (mainMenuDefault);
		}
	}
		
	public void CreditsMenu(bool clicked){
		if (clicked == true) {
			creditsMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (false);
			SetSelected (creditsMenuDefault);
		} else {
			creditsMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (true);
			SetSelected (mainMenuDefault);
		}
	}
}
