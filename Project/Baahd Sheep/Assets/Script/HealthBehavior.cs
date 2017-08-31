using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBehavior : MonoBehaviour {

    public GameObject hearts;
    int startingHealth;
    GameObject [] healthArray;
    public Text healthText;
    public Text livesText;
    public Text bossText;
    public bool boss1;
    public bool boss2;
    //public playerControls player;
    //public enemyBehavior boss;
    private int playerLives;
    private int playerHealth;
    private int bossHealth;

    public string thing;
	// Use this for initialization
	void Start () {
        //AddHearts(3);
        //healthArray = new GameObject[3];
        playerHealth = playerControls.health;
        playerLives = playerControls.lives;
        if (boss1)
            bossHealth = enemyBehavior.health;
        else if (boss2)
            bossHealth = boss2Behavior.health;
        //healthText.text = "Bean Health: " + playerHealth.ToString();
        //livesText.text = "Lives: " + playerLives.ToString();
       // bossText.text = "Boss Health " + bossHealth.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (healthText != null)
        {
            healthText.text = "Bean Health: " + playerControls.health.ToString();
        }
        if(livesText != null)
        {
            livesText.text = "Lives: " + playerControls.lives.ToString();
        }
        if(bossText != null)
        {
            if (boss1)
            {
                bossText.text = "Boss Health: " + enemyBehavior.health.ToString();
            }
            else if (boss2)
            {
                bossText.text = "Boss Health: " + boss2Behavior.health.ToString();
            }
        }

	}
    public void AddHearts(int n)
    {
        
    }
    public void LoseHearts(int n, bool isPlayer)
    {
        if(isPlayer)
        {
            playerHealth -= n;
        }
        else
        {
            bossHealth -= n;
        }
    }
}
