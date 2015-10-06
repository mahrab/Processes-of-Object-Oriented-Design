using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    public GameObject projectile;
    public float speed = 1500.0f;
    public Transform shootDir;
    //Vector3 moveDir = Vector3.zero;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            shootDir.GetComponents<Transform>();
            GameObject temp;
            //shootDir = transform.parent;
            temp = (GameObject)Instantiate(projectile, shootDir.position, shootDir.rotation);
            //Debug.Log(temp);
            Physics.IgnoreCollision(temp.GetComponent<Collider>(),shootDir.GetComponentInParent<Collider>());
            temp.GetComponent<Rigidbody>().AddForce(shootDir.forward* speed);
            
        }
	}
}
