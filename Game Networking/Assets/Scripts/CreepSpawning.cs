using UnityEngine;
using System.Collections;

public class CreepSpawning : MonoBehaviour
{

    public GameObject obj;
    public Transform spawn;
    float time;

	// Use this for initialization
	void Start ()
    {

        time = 30.0f;
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        time -= Time.deltaTime;

        if(time < 0)
        {
            Debug.Log("Creep Spawn Timer Elapsed");

            spawn.GetComponents<Transform>();

            GameObject temp;

            time = 30.0f;

            temp = (GameObject)Instantiate(obj, spawn.position, spawn.rotation);
        }
	
	}
}
