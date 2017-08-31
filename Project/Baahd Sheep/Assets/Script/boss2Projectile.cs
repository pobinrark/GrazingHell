using UnityEngine;
using System.Collections;

public class boss2Projectile : MonoBehaviour {
    public bool isSafe;
    Vector3 landingSpot;
    float destroyTime = 0.0f;
    public int direction = 1;
    Vector3 directionVector;
    Vector3 oldPosition;
    Vector3 originalPosition;
	// Use this for initialization
	void Start () {
        isSafe = false;
        oldPosition = new Vector3(1,0,0);
        originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if ((transform.position.x < min.x || transform.position.y < min.y) ||
                (transform.position.x > max.x || transform.position.y > max.y))
        {
            //Destroy(gameObject);
        }
        destroyTime += Time.deltaTime;
        if(destroyTime > 10.0f)
        {
            Destroy(gameObject);
        }
        directionVector = transform.position - oldPosition;
        directionVector.Normalize();
        oldPosition = transform.position;
        
    }
    public Vector3 SetDirection(Vector3 target, float angle)
    {
        Vector3 dir = target - transform.position;  // get target direction
        landingSpot = target;
        float h = dir.y;  // get height difference
        dir.y = 0;  // retain only the horizontal direction
        float dist = dir.magnitude;  // get horizontal distance
        float a = angle * Mathf.Deg2Rad;  // convert angle to radians
        dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
        dist += h / Mathf.Tan(a);  // correct for small height differences
                                   // calculate the velocity magnitude
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return vel * dir.normalized;
    }
    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.CompareTag("floor"))
        {
            if(this.CompareTag("hostile"))
            {
                Destroy(gameObject);
            }
            else if(this.CompareTag("safe"))
            {
                
            }
        }
        if(coll.gameObject.CompareTag("dummy"))
        {
            Destroy(gameObject);
        }
        else if(coll.gameObject.CompareTag("Player"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(directionVector.x * 3, 5, 0);
            isSafe = true;
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("floor"))
        {
            if (this.CompareTag("hostile"))
            {
                //Destroy(gameObject);
            }
            else if (this.CompareTag("safe"))
            {

            }
        }
    }
    public void SetSafety(bool safe)
    {
        isSafe = safe;   
    }
}
