using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class NetworkManager : MonoBehaviour
{
    [SerializeField] GameObject LobbyWindow;
    [SerializeField] InputField UserName;
    [SerializeField] InputField RoomName;
    [SerializeField] InputField RoomList;
    [SerializeField] InputField messageWindow;

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
    }

    public void OnReceivedRoomListUpdate()
    {
        Debug.Log("Update Error");
        RoomList.text = "";
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        foreach(RoomInfo room  in rooms)
        {
            RoomList.text += room.name + "\n";
        }
    }

    public void JoinRoom()
    {
        Debug.Log("Join Error");
        PhotonNetwork.player.name = UserName.text;
        RoomOptions roomOptions = new RoomOptions { isVisible = true, maxPlayers = 10 };
        PhotonNetwork.JoinOrCreateRoom(RoomName.text, roomOptions, TypedLobby.Default);
    }

    void  OnJoinedRoom()
    {
         Debug.Log("OnJoinedRoom");
        SpawnPlayer();
        LobbyWindow.SetActive(false);
    }

    void SpawnPlayer()
    {
        if(spawnSpots == null)
        {
            Debug.Log("Error: null spawnSpot");
        }

        SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];

        GameObject myPlayer = PhotonNetwork.Instantiate("PlayerControl", mySpawnSpot.transform.position, Quaternion.identity, 0);
        displayCam.SetActive(false);

        //Allows only one character to move on user's inputs
        myPlayer.GetComponent<PlayerController>().enabled = true;
        myPlayer.GetComponent<Shooting>().enabled = true;
        myPlayer.GetComponent<CharacterController>().enabled = true;
        myPlayer.transform.FindChild("Camera").gameObject.SetActive(true);

        AddMessage("Spawned player : " + PhotonNetwork.player.name );
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
        foreach(string m in messages)
        {
            messageWindow.text += m + "\n";
        }
    }


   
}
