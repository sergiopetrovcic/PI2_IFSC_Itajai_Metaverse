using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PhotonNetWork : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void SearchRoom()
    {
        Debug.Log("Searching for a random room...");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server");
        CreateRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Join Random Failed. Creating a new room. Reason: " + message);
        CreateRoom();
    }

    private void CreateRoom()
    {
        Debug.Log("Creating or joining a room...");
        PhotonNetwork.JoinOrCreateRoom("Campus 3D interativo", new RoomOptions { MaxPlayers = 20 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);

        PhotonNetwork.Instantiate("masculinoCharacterPrefab 2", new Vector2(Random.Range(-5f, 7f), transform.position.y), Quaternion.identity);
        PhotonNetwork.Instantiate("femininoCharacterPrefab 2", new Vector2(Random.Range(-5f, 7f), transform.position.y), Quaternion.identity);
    }

    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        PhotonNetwork.IsMessageQueueRunning = true;
    }

    void ChangeScene()
    {
        
        PhotonNetwork.IsMessageQueueRunning = false;


    }

}
