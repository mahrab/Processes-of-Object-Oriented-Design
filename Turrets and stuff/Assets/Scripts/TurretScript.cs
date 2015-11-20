using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
	public Transform lookAtTarget;
	public Vector3 delta = new Vector3(10, 10, 10);
	public GameObject bulletprefab;
	public int savedTime;
	public Transform spawnpoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs ((lookAtTarget.position - transform.position).x) < delta.x && Mathf.Abs ((lookAtTarget.position - transform.position).y) < delta.y && Mathf.Abs ((lookAtTarget.position - transform.position).z) < delta.z) {
			transform.LookAt (lookAtTarget);
			int seconds = (int)Time.time;
			int modTwo = seconds%2;
			if(modTwo == 1)
				Shoot (seconds);
		}
		else
			;
	}

	void Shoot(int seconds){
		if (seconds != savedTime) {
			GameObject bullet = (GameObject)GameObject.Instantiate (bulletprefab, spawnpoint.position,
		                                            spawnpoint.rotation);
			Physics.IgnoreCollision(bullet.GetComponent<Collider>(),spawnpoint.GetComponentInParent<Collider>());
			bullet.GetComponent<Rigidbody> ().AddForce (transform.forward * 1);
		}
		savedTime = seconds;
	}
}