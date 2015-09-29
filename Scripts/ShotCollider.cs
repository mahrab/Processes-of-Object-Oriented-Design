using UnityEngine;
using System.Collections;

public class ShotCollider : MonoBehaviour {
    public GameObject projectile;
	// Use this for initialization
	void Start () {
	
	}
    void onCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            Destroy(projectile);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
