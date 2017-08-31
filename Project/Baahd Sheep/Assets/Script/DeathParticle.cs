using UnityEngine;
using System.Collections;

public class DeathParticle : MonoBehaviour {
    public ParticleSystem deathParticle;
	// Use this for initialization
	void Start () {
        GetComponent<ParticleSystem>().enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(enemyBehavior.health <= 0 || boss2Behavior.health <= 0)
        {
            GetComponent<ParticleSystem>().enableEmission = true;
        }
	}

    public void PlayDeathParticle()
    {
        deathParticle.Play();
    }
}
