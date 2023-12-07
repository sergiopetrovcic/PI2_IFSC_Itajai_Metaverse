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
        Debug.Log("Conectado ao Master Server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Entrou no Lobby");
        PhotonNetwork.JoinOrCreateRoom("Campus 3D interativo", new RoomOptions { MaxPlayers = 20 }, TypedLobby.Default);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Entrou na Sala");
        // Restante do seu código...

        PhotonNetwork.Instantiate("masculinoCharacterPrefab 2", new Vector2(Random.Range(-5f, 7f), transform.position.y), Quaternion.identity);
        PhotonNetwork.Instantiate("femininoCharacterPrefab 2", new Vector2(Random.Range(-5f, 7f), transform.position.y), Quaternion.identity);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Join Random Failed. Creating a new room.");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }

}
