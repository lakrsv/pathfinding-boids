using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkManager : Photon.MonoBehaviour
{
    private const string roomName = "RoomName";
    private RoomInfo[] roomsList;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Don't worry, it runs!");
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnServerInitialized()
    {
        Debug.Log("Server Initialized");
    }
    void OnJoinedLobby()
    {
        Debug.Log("Connected to lobby!");
    }
    
    void OnReceivedRoomListUpdate()
    {
        Debug.Log("Got room update!");
        roomsList = PhotonNetwork.GetRoomList();
        if (roomsList.Length == 0)
        {
            PhotonNetwork.CreateRoom(roomName + System.Guid.NewGuid().ToString("N"));
        }
        else
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }
    void OnJoinedRoom()
    {
        Debug.Log("Connected to Room");
        PhotonNetwork.automaticallySyncScene = true;
    }
}
