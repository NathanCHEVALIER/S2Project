using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetScript : MonoBehaviour
{
    public GameObject lobbyCam;
    public Transform spawnPoint;
    public Text NetStatus;

    public const string Version = "1.101";
    public const string RoomName = "Multiplayer";

    public string playerPrefabName = "Player";

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(Version);
    }

    void Update()
    {
        NetStatus.text = PhotonNetwork.connectionStateDetailed.ToString();
    }

    public override void OnConnectionFail(DisconnectCause cause)
    {
        print("Connection failed!" + cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions() {IsVisible = false, MaxPlayers = 2};
        PhotonNetwork.JoinOrCreateRoom(RoomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        lobbyCam.SetActive(false);
        GameObject player = PhotonNetwork.Instantiate(playerPrefabName, spawnPoint.position, spawnPoint.rotation, 0);
    }
    
    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        print("New Player Connected");
    }
    
    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        print("Player DISconnected");
    }
}
