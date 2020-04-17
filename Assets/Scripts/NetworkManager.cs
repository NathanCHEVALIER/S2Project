using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : Photon.PunBehaviour
{
    public Camera lobbyCam;
    public Transform[] spawnPoints = new Transform[4];
    public Text NetStatus;
    public string playerPrefabName = "Player";

    public const string Version = "1.101";
    public const string RoomName = "Multiplayer";

    private int playerID;
    private GameObject player;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(Version);
        playerID = PhotonNetwork.countOfPlayers;
        PhotonNetwork.automaticallySyncScene = true;
    }

    void Update()
    {
        NetStatus.text = "Player" + playerID + ": " + PhotonNetwork.connectionStateDetailed.ToString();
    }

    public override void OnConnectionFail(DisconnectCause cause)
    {
        print("Connection failed!" + cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions() {IsVisible = false, MaxPlayers = 4};
        PhotonNetwork.JoinOrCreateRoom(RoomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        playerID = PhotonNetwork.playerList.Length;
        lobbyCam.enabled = true;
        player = PhotonNetwork.Instantiate(playerPrefabName, spawnPoints[playerID - 1].position, spawnPoints[playerID - 1].rotation, 0);
        DontDestroyOnLoad(player);
    }
    
    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        print("New Player Connected");
    }
    
    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        print("Player DISconnected");
    }

    public void LaunchLevel()
    {
        NetworkPlayer NetPlayer = player.GetComponent<NetworkPlayer>();
        bool res = NetPlayer.setStatus(true);
        if (res)
        {
            if(PhotonNetwork.isMasterClient)
            {
                PhotonNetwork.LoadLevel("Test Multi");
            }
            lobbyCam.enabled = false;
            player.transform.position = new Vector3((float)-24.5, 4, (float)-0.5);
        }
    }
}