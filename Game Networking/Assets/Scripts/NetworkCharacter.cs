using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Smoothes out the movements of the other character by capturing position and rotation
        if (!photonView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, this.realPosition, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.realRotation, Time.deltaTime);
        }
        
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //Debug.Log("SerializeView");
        //This is our player.Need to change position through the network.
        if(stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        //This is the other player which receives the position per milliseconds and updates
        else
        {
            this.realPosition = (Vector3)stream.ReceiveNext();
            this.realRotation = (Quaternion)stream.ReceiveNext();

        }
    }
}
