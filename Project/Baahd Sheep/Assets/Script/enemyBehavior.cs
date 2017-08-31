using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyBehavior : MonoBehaviour
{
	private GameObject soundObject = null;

	public AudioSource[] sounds;
	public AudioSource hit;
	public AudioSource ready;
	public AudioSource fire;
	public AudioSource flap;

	float mTimeSpentTraveling = 0.0f;
    float mTimeToDestination = 3f;
    float mTimeToDestination2 = 1.0f;
    float time;
    Vector3 startPosition;
    Vector3 endPosition;
    Vector3 positionA;
    Vector3 positionB;
    Vector3 positionC;
    bool leftA;
    bool reachedB;
    bool leftC;
    public GameObject projectile;
    public GameObject player;
    float shootDelay;
    float switchPositionDelay = 0.0f;
    //bool isReady;
	public static int health = 10;
    public Text healthText;
    public static float timeAlive = 0.0f;
    public GameObject healthBonus;
    public MetricManagerScript mms;
    bool spawnHealth = true;
    public FireController fc;
    float shootRate = 0;
    public static bool isAlive = true;
    ParticleSystem deathEffect;
    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        positionA = startPosition;
        positionB = new Vector3(0, 7, 0);
        endPosition = positionB;
        positionC = new Vector3(-transform.position.x, transform.position.y, 0);
        leftA = true;
        reachedB = false;
        leftC = false;
        time = 0.0f;
        shootDelay = 0.0f;
        deathEffect = gameObject.GetComponentInChildren<ParticleSystem>();
		sounds = GetComponents<AudioSource>();
		hit = sounds [0];
		ready = sounds [1];
		fire = sounds [2];
		flap = sounds [3];
        
        //isReady = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && isAlive == true) {
            deathEffect.Play();
            deathEffect.enableEmission = true;
            Debug.Log(deathEffect);
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            //GetComponent<enemyBehavior>().enabled = false;
            playerControls.BossesLeft--;
            isAlive = false;
			//Application.LoadLevel ("boss1");
		}
        else if(health <= 0)
        {
			soundObject = new GameObject ("SoundBoss1Death") as GameObject;
			soundObject.AddComponent<SoundBoss1Death> ();
			//soundObject = new GameObject(Resources.Load<GameObject> ("SelfDestructSound") as GameObject);
			soundObject.GetComponent<SoundBoss1Death> ().PlaySound ("DemonDeath", 3.5f);

            GetComponent<CapsuleCollider>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponent<enemyBehavior>().enabled = false;
        }
        else
        {
            timeAlive += Time.deltaTime;
            mms.Boss1Life(Time.deltaTime);
        }
        if(health == 5 && spawnHealth)
        {
            GameObject healthPowerUp = (GameObject)Instantiate(healthBonus, Vector3.zero, transform.rotation);
            spawnHealth = false;
        }
        Move();
            //mHasReachedDestination = false;
        
        //print("Start Position " + startPosition);
        //print("End Position " + endPosition);


    }
    void OnApplicationQuit()
    {
        
    }
    void Move()
    {
        mTimeSpentTraveling += Time.deltaTime;
        transform.position = Vector3.Lerp(startPosition, endPosition, (mTimeSpentTraveling / mTimeToDestination) * (mTimeSpentTraveling / mTimeToDestination));
        if (Vector3.Distance(transform.position, endPosition) < Mathf.Epsilon)
        {
            //mHasReachedDestination = true;

            if (endPosition == positionB)
            {
                
                time += Time.deltaTime;
                startPosition = positionB;
                //ShootProjectile();
                /* if(time > 1.0f)
                 {
                     isReady = true;
                 }
                 if(isReady)
                 {
                     ShootProjectile();
                     isReady = false;
                 }*/
                if (leftA)
                {
                    startPosition = positionB;
                    endPosition = positionC;
                    time = 0.0f;
                }
                else if (leftC)
                {
                    startPosition = positionB;
                    endPosition = positionA;
                    time = 0.0f;
                }

            }
            else if (endPosition == positionA)
            {
				ready.Play ();

				switchPositionDelay += Time.deltaTime;
                shootRate += Time.deltaTime;
                startPosition = positionA;
                if (health <= 5 && switchPositionDelay < 1.8f)
                {
                    fc.ShootFire(true);
                }
                if (switchPositionDelay >= 1.8f)
                    fc.DisableAllFire();
                if (switchPositionDelay > 1f)
                {
                    if (shootRate > 1f)
                    {
						ShootProjectile(-1);
                        shootRate = 0;
                    }
                }
                if (switchPositionDelay > 3.0f)
                {
                    fc.DisableAllFire();
                    reachedB = true;
                    leftC = false;
                    leftA = true;
                    startPosition = positionA;
                    endPosition = positionB;
                    switchPositionDelay = 0.0f;
                }

            }
            else if (endPosition == positionC)
            {
				ready.Play ();

                switchPositionDelay += Time.deltaTime;
                shootRate += Time.deltaTime;
                startPosition = positionC;
                if (health <= 5 && switchPositionDelay < 1.8f)
                    fc.ShootFire(false);
                if (switchPositionDelay >= 1.8f)
                    fc.DisableAllFire();
                if (switchPositionDelay > 1.0f)
                {
                    if (shootRate > 1f)
                    {
						ShootProjectile(1);
                        shootRate = 0;
                    }
                }
                if (switchPositionDelay > 3.0f)
                {
                    fc.DisableAllFire();
                    reachedB = true;
                    leftC = true;
                    leftA = false;
                    endPosition = positionB;
                    switchPositionDelay = 0.0f;
                }
            }

            mTimeSpentTraveling = 0.0f;
        }
    }
    void ShootProjectile(int j)
    {
		fire.Play ();

        for(int i = 0; i < 4; i++)
        {
            GameObject bullet = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            bullet.transform.position = transform.position; 
            Vector3 direction = new Vector3(1f * j,i * 1/4f,0f);
            bullet.GetComponent<enemyProjectile>().SetDirection(direction);
            
        }
    }
    public void LoseHealth(int n)
    {
        health-= n;
    }
    public int GetHealth()
    {
        return health;
    }
}