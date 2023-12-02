using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonNetWork : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions { MaxPlayers = 20 }, TypedLobby.Default);
    }
    
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("masculinoCharacterPrefab", new Vector2(Random.Range(-5f, 7f), transform.position.y), Quaternion.identity);
        PhotonNetwork.Instantiate("femininoCharacterPrefab", new Vector2(Random.Range(-5f, 7f), transform.position.y), Quaternion.identity);
    }
    
}
