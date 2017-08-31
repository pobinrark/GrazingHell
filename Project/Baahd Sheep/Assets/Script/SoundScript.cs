using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

	public AudioSource[] sounds;
	public AudioSource swing;
	public AudioSource grunt;
	public AudioSource sizzle;
	public AudioSource jump;
	public AudioSource hit;
	public AudioSource batgrowl;
	public AudioSource squish;
	public AudioSource blobgrowl;
//	public AudioSource portal;

	public bool GotHit;

	// Use this for initialization
	void Start () {
	
		sounds = GetComponents<AudioSource>();
		swing = sounds [0];
		grunt = sounds [1];
		sizzle = sounds [2];
		jump = sounds [3];
		hit = sounds [4];
		batgrowl = sounds [5];
		squish = sounds [8];
		blobgrowl = sounds [7];
//		portal = sounds [8];

		GotHit = false;

//		DontDestroyOnLoad(portal);

	}
	
	// Update is called once per frame
	void Update () {

		if (GotHit == true) {
		
			hit.Play ();

			GotHit = false;
		}

//		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
//			footsteps.Play ();
//		} else if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)){
//			footsteps.Stop ();
//		}
//
		if (Input.GetKeyDown (KeyCode.Z)){
            int swingType = Random.Range(0, 10);
            if (swingType % 3 == 0)
                swing = sounds[0];
            else if (swingType % 3 == 1)
                swing = sounds[6];
            else if (swingType % 3 == 2)
                swing = sounds[7];
            swing.Play();
		    grunt.Play ();
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)){
			jump.Play ();
		}

	}

	void OnCollisionEnter (Collision col){
			if(col.gameObject.layer == 8){
				sizzle.Play ();
				GotHit = true;
			}
		}

	void OnTriggerEnter (Collider trigCol){
		if (trigCol.gameObject.layer == 8) {
			sizzle.Play ();
			GotHit = true;
		}

		if (trigCol.gameObject.tag == "hostile") {
			squish.Play ();
			GotHit = true;
		}
//
//		if (trigCol.gameObject.tag == "portal") {
//			portal.Play ();
//		}
	}


	}
    
 
