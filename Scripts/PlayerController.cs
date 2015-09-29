using UnityEngine;
using System.Collections;
/* This script will control players.  As of 9/17/15 this is a very rudimentary controler.  In this first version there will be no alt. mapping.
 * This script will take the mouse movement and WASD input, and a few other keyes to look around, move and jump.  This script will also reference 
 * the firing script.
 * This script is only for use in the COP 4331C project at UCF.  The team that created this script has the designation team 30 and includes Ernest Wheaton,
 * Fred Gravil, Micheal Cowen and Clayton Barham.  
 * */
public class PlayerController : MonoBehaviour {
    public CharacterController control;
    public float speed = 8.0f;
    public float jump = 10.0f;
    public float lookSpeed = 2.0f;
    public float mass = 40.0f;
    public float g = -9.8f;
    float z = 0;
    bool Double = true;
    Vector3 moveDir = Vector3.zero;
	// Use this for initialization
	void Start () {
        control = GetComponent<CharacterController>();
        
	}
	
	// Update is called once per frame
	void Update () {
        z = 0;
        if (Input.GetAxis("Mouse X") >= 0 || Input.GetAxis("Mouse X") < 0)
        {
           // lookDir += new Vector3(, 0, 0);
            control.gameObject.transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * lookSpeed,Space.Self);//rotate on the x axis
        }
        if (Input.GetAxis("Mouse Y") >= 0 || Input.GetAxis("Mouse Y") < 0)
        {
            //if(
            //lookDir += new Vector3(0,Input.GetAxis("Mouse Y"), 0);
            control.gameObject.transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * lookSpeed, Space.Self);//rotate on the y axis
        }
        z = control.gameObject.transform.eulerAngles.z;//this is how we will lock the rotation, unitl we find a more robust solution
        control.gameObject.transform.Rotate(new Vector3(0,0,-z));
        //This next block gets movement input and updates the position
        if (control.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
            Double = true;
        }
        if (Input.GetButton("Jump") && Double)
        {
            moveDir.y = jump;
            if (!control.isGrounded) Double = false;
        }
        moveDir.y += (g*mass) * Time.deltaTime;
        control.Move(moveDir * Time.deltaTime);
	}
}
