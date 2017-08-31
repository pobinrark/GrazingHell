using UnityEngine;
using System.Collections;

public class boss2Behavior : MonoBehaviour {

	public AudioSource[] sounds;
	public AudioSource growl;

	private GameObject soundObject = null;

	float shootDelay = 0.0f;
    public GameObject projectileSafe;
    public GameObject projectileHostile;
    public Material dizzyMat;
    public Material defaultMat;
    GameObject projectile;
    GameObject [] safeProjectilesOnField;
    float hostileTime = 0.0f;
    float safeTime = 0.0f;
    public enum State { Dizzy, Idle };
    public State mState;
    Vector3 positionA, positionB, positionC, positionD;
    float dizzyTime = 0;
    bool isSafe;
    public static int health = 5;
    public bool isDizzy = false;
    public MetricManagerScript mms;
    public GameObject bigProjectile;
    bool isAlive;
    float projectileTimer;
    int targetChoice = 0;
    float deathAnimLength;
    public static bool boss2Alive = true;
    public ParticleSystem deathParticle;
	// Use this for initialization

	void Start () {

		sounds = GetComponents<AudioSource>();
		growl = sounds [0];


        mState = State.Idle;
        positionA = new Vector3(-5.5f, 2f, 0.0f);
        positionB = new Vector3(-4.5f, 2f, 0.0f);
        positionC = new Vector3(4.9f, 2f, 0.0f);
        positionD = new Vector3(5.5f, 2f, 0f);
        isSafe = false;
        Physics.IgnoreCollision(projectileSafe.GetComponent<Collider>(), GetComponent<Collider>(), false);
        Physics.IgnoreCollision(projectileHostile.GetComponent<Collider>(), GetComponent<Collider>(), false);
        isAlive = true;
        deathAnimLength = 0;

		soundObject = new GameObject ("SoundBoss2Death") as GameObject;
		soundObject.AddComponent<SoundBoss2Death> ();

    }
	
	// Update is called once per frame
	void Update () {
        hostileTime += Time.deltaTime;
        safeTime += Time.deltaTime;
        if(hostileTime > 2.0f)
        {
            //Debug.Log("Shoot");
            //ShootProjectile(projectileHostile, false);
            hostileTime = 0.0f;
        }
        if(safeTime > 3.5f)
        {
            ShootSafeProjectile(projectileSafe, false, targetChoice);
            targetChoice++;
            safeTime = 0.0f;
        }
        if(mState == State.Dizzy)
        {
            gameObject.GetComponent<SpriteRenderer>().material = dizzyMat;
            dizzyTime += Time.deltaTime;
            if(dizzyTime > 3.0f)
            {
                gameObject.GetComponent<SpriteRenderer>().material = defaultMat;
                mState = State.Idle;
                isDizzy = false;
                dizzyTime = 0.0f;
            }
        }
        if(health <= 0)
		{	
            deathParticle.Play();
            boss2Alive = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
         
			soundObject.GetComponent<SoundBoss2Death> ().PlaySound ("BlobDeath", 3.5f);

            deathAnimLength += Time.deltaTime;
//            if(deathAnimLength > 3.0f)
//            {
//                Destroy(gameObject);
//            }
			//Destroy(gameObject);
			//put particle system for BOSS2 IN, but DONT DESTROY OBJECT. Discontninue all actions
        }
        if(health > 0)
        {
            mms.Boss2Life(Time.deltaTime);
        }
        if(health <= 5)
        {
            projectileTimer += Time.deltaTime;
            if (projectileTimer > 8.0f)
            {
                GameObject zigzag1 = (GameObject)Instantiate(bigProjectile);
                GameObject zigzag2 = (GameObject)Instantiate(bigProjectile);
                zigzag1.transform.position = new Vector3(9f, 30f, 0);
                zigzag2.transform.position = new Vector3(-17.7f, 30f, 0);
                projectileTimer = 0f;
            }
        }
        
	}
    void ShootSafeProjectile(GameObject projectileType, bool isSafe, int position)
    {

            projectile = projectileType;
            
            //bullet.transform.position = transform.position;
            Vector3 target = new Vector3();
        if(position % 4 == 0)
        {
            target = positionA;
        }
        else if(position % 4 == 1)
        {
            target = positionB;
        }
        else if(position % 4 == 2)
        {
            target = positionC;
        }
        else if(position % 4 == 3)
        {
            target = positionD;
        }
            
        GameObject bullet = (GameObject)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.GetComponent<boss2Projectile>().SetDirection(target, 30.0f);
            bullet.GetComponent<boss2Projectile>().isSafe = isSafe;
            shootDelay = 0.0f;
            //time = 0.0f;
    }

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("In TRIGGER");
        if (coll.gameObject.CompareTag("safe") && coll.gameObject.GetComponent<boss2Projectile>().isSafe)
        {
			int beenHit = Random.Range(0, 10);
			if (beenHit % 3 == 0)
				growl = sounds[0];
			else if (beenHit % 3 == 1)
				growl = sounds[1];
			else if (beenHit % 3 == 2)
				growl = sounds[2];

			growl.Play (); 
            mState = State.Dizzy;
            isDizzy = true;
            Destroy(coll.gameObject);
            health--;
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("in collide");
    }
    
}
