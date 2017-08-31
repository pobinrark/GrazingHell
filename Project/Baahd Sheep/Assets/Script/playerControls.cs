using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerControls : MonoBehaviour {

	// Use this for initialization

	private GameObject soundObject = null;

    public AudioSource[] sounds;
    public AudioSource batgrowl;

    public float speed;
    public float airSpeed;
    public float jumpSpeed;
    public float gravity;
    public static int health = 5;
    public static int lives = 3;
    public static int BossesLeft = 2;
	public static bool facingRight = true;
    RaycastHit hit;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject hearts;
    GameObject beanHealth;
    public Text healthText;
    public Material mat1;
    public Material mat2;
    public GameObject enemy;
    bool enemyStunned;
    float immuneTime, blinkRate;
    bool red = false;
    bool beanImmune = false;
    public MetricManagerScript mms;
    public static float timeAlive;
    public HealthBehavior healthBehavior;
    bool isHit = false;
    bool redBean = false;
    float beanImmuneTime;
    float blinkRateBean;
    public bool isBoss1;
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        batgrowl = sounds[5];

        enemyStunned = false;
        beanImmuneTime = 1.0f;
        immuneTime = 2.0f;
        blinkRate = 0.0f;
        blinkRateBean = 0.0f;
        healthText = GetComponent<Text>();
        //healthText.text = "Bean Health: " + health.ToString();
        //hearts.GetComponent<HealthBehavior>().AddHearts(health);
        //transform.position = new Vector3(0, 0, 0);

    }
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if(BossesLeft <= 0)
        {
            Application.LoadLevel("Win Screen");
            health = 5;
            lives = 3;
            enemyBehavior.health = 10;
            boss2Behavior.health = 10;
            BossesLeft = 2;
        }
        if(lives <= 0)
        {
			//Destroy(gameObject);
			Application.LoadLevel ("Game Over");
            Debug.Log("Loading Game Over");
            health = 5;
            lives = 3;
            enemyBehavior.health = 10;
            boss2Behavior.health = 10;
            BossesLeft = 2;

        }
		if(health <= 0)
        {
            lives -= 1;
            health = 5;
            Debug.Log("loading new scene");
            Application.LoadLevel("Safe Zone");

			soundObject = new GameObject ("SoundBeanDeath") as GameObject;
			soundObject.AddComponent<SoundBeanDeath> ();
			//soundObject = new GameObject(Resources.Load<GameObject> ("SelfDestructSound") as GameObject);
			soundObject.GetComponent<SoundBeanDeath> ().PlaySound ("PlayerDeath", 3.5f);

        }
        else if (health > 0)
        {
            timeAlive += Time.deltaTime;
            mms.AddToSample1(Time.deltaTime);
        }
//        if(Input.GetKeyDown(KeyCode.P))
//        {
//            Debug.Log("Hit QUit");
//            //mms.AddToSample1(timeAlive);
//            //mms.AddToSample2(enemyBehavior.timeAlive);
//			Application.Quit ();
//        }
//		if (Input.GetKeyDown (KeyCode.R)) 
//		{
//			Application.LoadLevel ("boss1");
//		}
        if(transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				facingRight = false;
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				facingRight = true;
			}
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;

            }
        }
        else if(!controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveDirection.x = -airSpeed;
				facingRight = false;
                //transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moveDirection.x = airSpeed;
				facingRight = true;

                //transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (isBoss1)
                mms.NumberOfSwingsBoss1(1);
            else
                mms.NumberOfSwingsBoss2();
            Debug.Log("pressed w");
			if (facingRight) 
			{
                Debug.Log("facing right");
                Swing(Vector3.right);
				
			} 
			else if (!facingRight) 
			{
                Swing(Vector3.left);
                
            }
        }
        if(enemy != null && enemyStunned)
        {
            immuneTime -= Time.deltaTime;
            //enemy.GetComponent<SpriteRenderer>().material = mat1;
            blinkRate += Time.deltaTime;
            
            if(blinkRate > 0.5f)
            {
                if(red)
                {
                    enemy.GetComponent<SpriteRenderer>().material = mat2;
                    red = false;
                }
                else
                {
                    enemy.GetComponent<SpriteRenderer>().material = mat1;
                    red = true;
                }
                blinkRate = 0.0f;
            }
            if (immuneTime < 0.0f)
            {
                blinkRate = 0.0f;
                immuneTime = 2.0f;
                enemyStunned = false;
                red = false;
            }
            
        }
        if (isHit)
        {
            beanImmuneTime -= Time.deltaTime;
            blinkRateBean += Time.deltaTime;
            beanImmune = true;
            if (blinkRateBean > 0.25f)
            {
                if (!redBean)
                {
                    GetComponentInChildren<SpriteRenderer>().material = mat1;
                    redBean = true;
                }
                else
                {
                    GetComponentInChildren<SpriteRenderer>().material = mat2;
                    redBean = false;
                }
                blinkRateBean = 0.0f;
            }
            if (beanImmuneTime < 0.0f)
            {
                GetComponentInChildren<SpriteRenderer>().material = mat2;
                blinkRateBean = 0.0f;
                beanImmuneTime = 60.0f;
                isHit = false;
                redBean = false;
                beanImmune = false;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    void OnApplicationQuit()
    {
        mms.AddToSample1(timeAlive);
    }
    void OnCollisionEnter(Collision col)
	{

		//MAKE THE CHILD COMPONENT FLASH RED FOR .5 SECONDS
		//print ("I got hit");
        if(col.gameObject.CompareTag("projectile") || col.gameObject.CompareTag("hostile") || col.gameObject.CompareTag("Enemy"))
        {
            print("I got hit");
            GetComponentInChildren<SpriteRenderer>().material = mat1;
            isHit = true;
            redBean = true;
            if(!beanImmune)
                health--;
            //healthBehavior.LoseHearts(1, true);
            Destroy(col.gameObject);
        }
    }
    void Swing(Vector3 vector)
    {
        if (Physics.Raycast(transform.position, vector, out hit, 2.7f))
        {
            Debug.Log("in raycast");
            Debug.DrawRay(transform.position, vector, Color.white);
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log(hit.collider.gameObject);
                enemyStunned = true;
                hit.collider.gameObject.GetComponentInChildren<SpriteRenderer>().material = mat1;
                red = true;
                enemyBehavior.health--;
                batgrowl.Play();
            }
            else if (hit.collider.CompareTag("dummy"))
            {
                Debug.Log("hit");
            }
            if (hit.collider.CompareTag("Enemy2") && hit.collider.gameObject.GetComponent<boss2Behavior>().isDizzy)
            {
                boss2Behavior.health--;
            }
            HitSafeProjectile(hit.collider.gameObject);
        }

    }
    public int GetHealth()
    {
        return health;
    }
    public int GetLives()
    {
        return lives;
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.CompareTag("health"))
        {
            //health += 2;
//            Destroy(coll.gameObject);
        }
        if(coll.gameObject.CompareTag("Enemy2") || coll.gameObject.CompareTag("Enemy") || coll.gameObject.CompareTag("hostile") || coll.gameObject.CompareTag("projectile"))
        {
            if(!beanImmune)
                health--;
			GetComponentInChildren<SpriteRenderer>().material = mat1;
			isHit = true;
			redBean = true;
				//healthBehavior.LoseHearts(1, true);
			}
        }
    
    void HitSafeProjectile(GameObject projectile)
    {
        if(projectile.CompareTag("safe"))
        {
            projectile.GetComponent<boss2Projectile>().direction = -1;
            projectile.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            projectile.GetComponent<boss2Projectile>().isSafe = true;
            Physics.IgnoreCollision(projectile.GetComponent<Collider>(), GetComponent<Collider>(), false);
            projectile.GetComponent<Rigidbody>().velocity = new Vector3(-20, 0, 0);
        }
    }
    /*void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }*/
}

