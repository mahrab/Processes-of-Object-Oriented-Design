using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Move : NetworkBehaviour
{
    public string axis = "Horizontal";
    public float speed = 1.0f;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if this script is runnin on a local player, send this information.
        if(isLocalPlayer)
        {
            //moves the player to the right based on input and time is based on seconds
            transform.position += Input.GetAxis(axis) * Vector3.right * speed * Time.deltaTime;
        }
        
	}
}
