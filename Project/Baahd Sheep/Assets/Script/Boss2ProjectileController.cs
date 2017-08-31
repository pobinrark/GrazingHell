using UnityEngine;
using System.Collections;

public class Boss2ProjectileController : MonoBehaviour {
    public GameObject projectile;
    GameObject projectile1, projectile2;
    public GameObject[] wave1, wave2, wave3, wave4, wave5, wave6;
    float timer1, timer2, timer3, timer4, timer5, timer6;
    float rate;
    bool spawnWave1, spawnWave2;
    // Use this for initialization
    void Start()
    {
        spawnWave1 = true;
        projectile1 = projectile;
        projectile2 = projectile;
        spawnWave1 = true;
        spawnWave2 = true;
        
    }
    // Update is called once per frame
    void Update()
    {
        if(boss2Behavior.boss2Alive == false)
        {
            GetComponent<Boss2ProjectileController>().enabled = false;
        }
        if(boss2Behavior.health > 5)
        { 
            rate += Time.deltaTime;
            if (rate > 5)
            {
                timer1 += Time.deltaTime;
                timer2 += Time.deltaTime;
                if (timer1 > 0.5f)
                {
                    if (spawnWave1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            wave1[i] = Instantiate<GameObject>(projectile1);
                            wave1[i].transform.position = new Vector3(-17.5f + i * 6f, 9, 0);
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            wave2[i] = Instantiate<GameObject>(projectile1);
                            wave2[i].transform.position = new Vector3(6.5f + i * 6f, 9, 0);
                        }
                        timer1 = 0;
                        spawnWave1 = !spawnWave1;
                    }
                    else
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            wave1[i] = Instantiate<GameObject>(projectile1);
                            wave1[i].transform.position = new Vector3(-14.5f + i * 6f, 9, 0);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            wave2[i] = Instantiate<GameObject>(projectile1);
                            wave2[i].transform.position = new Vector3(9.5f + i * 6f, 9, 0);
                        }
                        timer1 = 0;
                        spawnWave1 = !spawnWave1;
                    }

                }
                if (rate > 9)
                {
                    rate = 0;
                    timer1 = 0;
                    timer2 = 0;
                }
            }

        }
    }
    
}

