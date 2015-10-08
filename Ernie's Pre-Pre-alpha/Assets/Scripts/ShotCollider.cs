using UnityEngine;
using System.Collections;

public class ShotCollider : MonoBehaviour {
    public GameObject projectile;
	// Use this for initialization
    float time;
	void Start () {
        time = 20.0f;
	}
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Hit");
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
