using UnityEngine;
using System.Collections;

public class SoundBeanDeath : MonoBehaviour {

	private void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
	}

	public void PlaySound (string soundFileName, float selfDestructTime)
	{
		AudioSource myAudioSource = gameObject.AddComponent<AudioSource> ();
		myAudioSource.clip = Resources.Load<AudioClip> (soundFileName);
		myAudioSource.Play ();
		DestroyObject (this.gameObject, selfDestructTime);
	}
}
