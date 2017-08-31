using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour{

	private GameObject soundObject = null;
    public string level;
    void Start()
	{   

    }

    void Update()
    {

    }

    void OnTriggerExit(Collider bean)
    {
        if(bean.gameObject.CompareTag("Player"))
        {
            Level(level);
        }
    }

	public void Level(string levelName)
 	{
		soundObject = new GameObject ("SelfDestructSound") as GameObject;
		soundObject.AddComponent<SoundSelfDestruct> ();
		//soundObject = new GameObject(Resources.Load<GameObject> ("SelfDestructSound") as GameObject);
		soundObject.GetComponent<SoundSelfDestruct> ().PlaySound ("Portal", 2.5f);
        Application.LoadLevel(levelName);
    }
}
