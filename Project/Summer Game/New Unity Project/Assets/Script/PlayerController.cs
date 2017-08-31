using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float MoveSpeed = 10.0f;
    float Health;
    Vector3 MousePos;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        MovementUpdate();
	}

    void SetHealth(int h)
    {
        Health = h;
    }

    void SetMoveSpeed(int s)
    {
        MoveSpeed = s;
    }

    void MovementUpdate()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            MousePos = Input.mousePosition;
            MousePos.z = 0.0f;   
        }
        transform.position = Vector3.Lerp(transform.position, MousePos, MoveSpeed * Time.deltaTime);
    }
}
