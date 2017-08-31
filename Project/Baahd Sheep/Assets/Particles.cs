using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {
	private Renderer rend;

	public AudioSource[] sounds;
	public AudioSource magic;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		gameObject.GetComponent<ParticleSystem>().enableEmission = false;

		sounds = GetComponents<AudioSource>();
		magic = sounds [0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col){
		if(col.gameObject.CompareTag("Player")){
		Debug.Log ("hit health");
		gameObject.GetComponent<SphereCollider> ().enabled = false;
		rend.enabled = false;
        if (playerControls.lives == 3)
            playerControls.health += 2;
        else if (playerControls.lives == 2)
            playerControls.health += 3;
        else if (playerControls.lives == 1)
            playerControls.health += 5;
		gameObject.GetComponent<ParticleSystem>().enableEmission = true;
		magic.Play ();
		}
	}

}
