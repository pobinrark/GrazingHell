using UnityEngine;
using System.Collections;

public class enemyProjectile : MonoBehaviour
{
    float speed;
    bool isReady;
    Vector3 mDirection;
	private Animator animator;


    // Use this for initialization
    void Start()
    {
		animator = GetComponent<Animator>();
        //speed = 10.0f;
		animator.SetInteger("FireballFlash", 0);

    }
    void Awake()
    {
        speed = 10.5f;
        isReady = false;

    }
    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            //projectile moving
            Vector3 position = transform.position;
            position += mDirection * speed * Time.deltaTime;
            transform.position = position;

            //once projectile out of viewspace remove it from gamex
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if((transform.position.x < min.x || transform.position.y < min.y) || 
                (transform.position.x > max.x || transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }

    }
    public void SetDirection(Vector3 direction)
    {
        mDirection = direction.normalized;
        isReady = true;
    }

    public void OnCollisionEnter()
    {
        //Destroy(this.gameObject);
    }
}
