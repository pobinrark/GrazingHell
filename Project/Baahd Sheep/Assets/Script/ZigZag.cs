using UnityEngine;
using System.Collections;

public class ZigZag : MonoBehaviour {
    float yPosition;
    public GameObject zigzag;
	// Use this for initialization
	void Start () {
        yPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        yPosition -= 0.15f;
       transform.position = new Vector3(transform.position.x, yPosition, 0);
        if(transform.position.y < -20f)
        {
            Destroy(this.gameObject);
        }
	}
}
