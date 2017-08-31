 using UnityEngine;
using System.Collections;

public class BeanAnimation : MonoBehaviour {

	// Use this for initialization

//	public AudioSource[] sounds;
//	public AudioSource footsteps;
//	public AudioSource swing;

	//anim state 0 = idle
	//anim state 1 = walk
	//anim state 2 = jump
	//anim state 3 = attack
	//anim state 4 = death

	public bool IdleState; 
	private Animator animator;

   // public GameObject player;
    bool WalkState;
    bool isLeft;
    enum State { Attack, Attack2, Walk, Idle, Jump, Death };

    State mState;
    void Start()
	{
		animator = GetComponent<Animator>();
		IdleState = true;
		
        WalkState = true;
        isLeft = false;

		mState = State.Idle;

//		sounds = GetComponents<AudioSource>();
//		footsteps = sounds[0];
//		swing = sounds[1];
//        

	}

	void Update()
	{
		if (mState == State.Idle) {
			animator.SetInteger ("AnimState", 0);
			StateOptions ();
		} else if (mState == State.Walk) {
//			footsteps.Play();
			animator.SetInteger ("AnimState", 1);

			StateOptions ();

		} else if (mState == State.Jump) {
			animator.SetInteger ("AnimState", 2);
			StateOptions ();
		} else if (mState == State.Attack) {
//			swing.Play ();
			animator.SetInteger ("AnimState", 3);
			StateOptions ();
		} else if (mState == State.Attack2) {
			//			swing.Play ();
			animator.SetInteger ("AnimState", 5);
			StateOptions ();
		} else if(mState == State.Death){
            animator.SetInteger("AnimState", 4);
            //StateOptions();
        }
		
	}
    void StateOptions()
    {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			mState = State.Walk;
			transform.localRotation = Quaternion.Euler (0, 180, 0);
			isLeft = true;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			mState = State.Walk;
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			isLeft = false;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			mState = State.Jump;
		} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
			mState = State.Idle;			
		}


        else if (Input.GetKeyDown(KeyCode.Z))
        {
			if (isLeft == true) {
				mState = State.Attack2;
				Debug.Log ("attack 2");

			} else if (isLeft == false) {
				mState = State.Attack;
				Debug.Log ("attack 1");
			}
        }
		else if(Input.GetKeyUp(KeyCode.Z))
        {
            mState = State.Idle;
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            mState = State.Idle;
        }
        /*else if(player.GetComponent<playerControls>().health == 0)
        {
            mState = State.Death;
        }*/
    }
    
//
}


