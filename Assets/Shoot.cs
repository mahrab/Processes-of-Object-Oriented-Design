using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Shoot : NetworkBehaviour
{
    public GameObject bullet;
    public string button = "Fire1";

	// Use this for initialization
	void Start ()
    {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            //prevents spam shooting
            if (Input.GetButtonDown(button))
            {
                CmdShoot();
            }
        }
        
	}
    
    //command means the function is called on the server instead of locally
    [Command]
    void CmdShoot()
    {
        GameObject instance = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        NetworkServer.Spawn(instance);
    }
}
