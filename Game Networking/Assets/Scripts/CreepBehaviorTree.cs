using UnityEngine;
using System.Collections;

public class CreepBehaviorTree : MonoBehaviour
{

    public GameObject creep;
    public string enemy1;
    public string enemy2;
    public string enemy3;
    CharacterController creep_controller;
    float creep_health;
    float creep_speed;
    float creep_vision_radius;
    float creep_damage;
    float creep_RoF;
    float creep_range;
    public Vector3[] waypoint_path;
    Vector3 zero_vector;
    int waypoint_helper;
    GameObject current_target;
    GameObject temp;
    public GameObject projectile;
    //Transform target_transform;
    bool attack_flag;

	// Use this for initialization
	void Start ()
    {
        creep_controller = creep.GetComponent<CharacterController>();
        creep_health = 50;
        creep_speed = 1;
        creep_vision_radius = creep_range = 50;
        creep_damage = 10;
        waypoint_helper = 0;
        zero_vector = new Vector3(0, 0, 0);
        current_target = null;
        attack_flag = false;
	}
	
    // if a bullet collides with the creep, deduct 25 health (will likely need to change this after a conversation with Ernie)
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "bullet")
        {
            creep_health -= 25;
            Debug.Log("creep shot");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if an enemy enters the trigger collider attached to the creep, designate them as the current target to be fired
        // upon when the update function is called
        if (other.CompareTag(enemy1))
        {
            if(current_target == null)
            {
                current_target = other.gameObject;
            }
            attack_flag = true;
        }
        else if (other.CompareTag(enemy2))
        {
            if (current_target == null)
            {
                current_target = other.gameObject;
            }
            attack_flag = true;
        }
        else if (other.CompareTag(enemy3))
        {
            Debug.Log("Found you!");
            if (current_target == null)
            {
                current_target = other.gameObject;
                Debug.Log("Target acquired");
            }
            attack_flag = true;
        }
    }

    // Update is called once per frame
    void Update ()
    {
	    if(creep_health <= 0)
        {
            Destroy(creep.gameObject);
        }
        else if(attack_flag == true)
        {
            // reset attack flag
            attack_flag = false;

            // face target
            creep.transform.Rotate((current_target.transform.position - creep.transform.position).normalized);
            // fire
            temp = (GameObject)Instantiate(projectile, creep.transform.position, creep.transform.rotation);
            temp.GetComponent<Rigidbody>().AddForce(creep.transform.forward * 1500.0f);
        }
        else
        {
            // since there is no target in sight, reset current target to null
            current_target = null;
            // creep is alive and no threats detected, so face the next waypoint and move towards it
            if (((waypoint_path[waypoint_helper] - creep.transform.position) == zero_vector) && (waypoint_helper < (waypoint_path.Length - 1)))
            {
                waypoint_helper++;
            }
            creep.transform.Rotate((waypoint_path[waypoint_helper] - creep.transform.position).normalized);
            creep_controller.Move((waypoint_path[waypoint_helper] - creep.transform.position).normalized * creep_speed);
        }
	}
}
