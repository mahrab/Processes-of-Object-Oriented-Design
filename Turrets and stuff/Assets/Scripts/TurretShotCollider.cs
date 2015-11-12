using UnityEngine;
using System.Collections;

public class TurretShotCollider : MonoBehaviour {
	public GameObject projectile;
	// Use this for initialization
	float time;
	void Start () {
		time = 5.0f;
	}
	void OnCollisionEnter(Collision col)
	{
		Destroy(projectile);
	}
	// Update is called once per frame
	void Update () {
		time -=Time.deltaTime;
		if(time < 0)
		{
			Destroy(projectile);
		}
	}
}