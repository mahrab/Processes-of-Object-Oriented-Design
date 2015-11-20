using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class NetworkManager : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField]
    GameObject LobbyWindow;
    [SerializeField]
    InputField UserName;
    [SerializeField]
    InputField RoomName;
    [SerializeField]
    InputField RoomList;
    [SerializeField]
    InputField messageWindow;

=======
    [SerializeField] GameObject LobbyWindow;
    [SerializeField] InputField UserName;
    [SerializeField] InputField RoomName;
    [SerializeField] InputField RoomList;
    [SerializeField] InputField messageWindow;
>>>>>>> 137a33f859d885ac810ff38fdd79fe080e493570

    public GameObject displayCam;
    SpawnSpot[] spawnSpots;
    Queue<string> messages;
    const int messageCount = 6;
    PhotonView photonView;
    // Use this for initialization
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        messages = new Queue<string>(messageCount);

        PhotonNetwork.ConnectUsingSettings("FPS v001");
        spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
    }


    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());

    }

    void OnJoinedLobby()
    {
        //PhotonNetwork.logLevel = PhotonLogLevel.Full;
        LobbyWindow.SetActive(true);
<<<<<<< HEAD
        messageWindow.enabled = true;
        
=======
>>>>>>> 137a33f859d885ac810ff38fdd79fe080e493570
    }

    public void OnReceivedRoomListUpdate()
    {
        Debug.Log("Update Error");
        RoomList.text = "";
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
<<<<<<< HEAD
        foreach (RoomInfo room in rooms)
=======
        foreach(RoomInfo room  in rooms)
>>>>>>> 137a33f859d885ac810ff38fdd79fe080e493570
        {
            RoomList.text += room.name + "\n";
        }
    }

    public void JoinRoom()
    {
<<<<<<< HEAD
        Debug.Log("Joining");
=======
        Debug.Log("Join Error");
>>>>>>> 137a33f859d885ac810ff38fdd79fe080e493570
        PhotonNetwork.player.name = UserName.text;
        RoomOptions roomOptions = new RoomOptions { isVisible = true, maxPlayers = 10 };
        PhotonNetwork.JoinOrCreateRoom(RoomName.text, roomOptions, TypedLobby.Default);
    }

<<<<<<< HEAD
    //public void OnPhotonRandomJoinFailed()
    //{
    //    Debug.Log("Errrorrr1!");
    //    PhotonNetwork.CreateRoom(null);
    //}
    void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
=======
    void  OnJoinedRoom()
    {
         Debug.Log("OnJoinedRoom");
>>>>>>> 137a33f859d885ac810ff38fdd79fe080e493570
        SpawnPlayer();
        LobbyWindow.SetActive(false);
    }

    void SpawnPlayer()
    {
<<<<<<< HEAD
        if (spawnSpots == null)
=======
        if(spawnSpots == null)
>>>>>>> 137a33f859d885ac810ff38fdd79fe080e493570
        {
            Debug.Log("Error: null spawnSpot");
        }

<<<<<<< HEAD
        //picks from a random list of spawnspots
        SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];

        GameObject myPlayer = PhotonNetwork.Instantiate("Player", mySpawnSpot.transform.position, Quaternion.identity, 0);
=======
        SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];

        GameObject myPlayer = PhotonNetwork.Instantiate("PlayerControl", mySpawnSpot.transform.position, Quaternion.identity, 0);
>>>>>>> 137a33f859d885ac810ff38fdd79fe080e493570
        displayCam.SetActive(false);

        //Allows only one character to move on user's inputs
        myPlayer.GetComponent<PlayerController>().enabled = true;
        myPlayer.GetComponent<Shooting>().enabled = true;
        myPlayer.GetComponent<CharacterController>().enabled = true;
<<<<<<< HEAD
        myPlayer.transform.FindChild("PlayerCamera").gameObject.SetActive(true);

        AddMessage("Spawned player : " + PhotonNetwork.player.name);


    }

    void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {

        AddMessage(player.name + " has left the game.");
=======
        myPlayer.transform.FindChild("Camera").gameObject.SetActive(true);

        AddMessage("Spawned player : " + PhotonNetwork.player.name );
>>>>>>> 137a33f859d885ac810ff38fdd79fe080e493570
    }

    void AddMessage(string message)
    {
        photonView.RPC("AddMessage_RPC", PhotonTargets.All, message);
    }

    [PunRPC]
    void AddMessage_RPC(string message)
    {
        messages.Enqueue(message);

        if (messages.Count > messageCount)
        {
            messages.Dequeue();
        }

        messageWindow.text = "";
<<<<<<< HEAD
        foreach (string m in messages)
=======
        foreach(string m in messages)
>>>>>>> 137a33f859d885ac810ff38fdd79fe080e493570
        {
            messageWindow.text += m + "\n";
        }
    }


<<<<<<< HEAD

=======
   
>>>>>>> 137a33f859d885ac810ff38fdd79fe080e493570
}
