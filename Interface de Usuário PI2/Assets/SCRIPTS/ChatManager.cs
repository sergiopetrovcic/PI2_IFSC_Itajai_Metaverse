using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class ChatManager : MonoBehaviour, IPunObservable
{
    public PhotonView photonView;
    public GameObject BubbleSpeechObject;
    public TextMeshProUGUI UpdateText;

    public InputField ChatInputField;
    private bool DisableSend;

    private void Update()
    {
        if (photonView.IsMine)
        {
            if (ChatInputField != null && ChatInputField.isFocused)
            {
                // Debug: Verifica se o ChatInputField está focado
                Debug.Log("ChatInputField is focused.");

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // Debug: Verifica se a tecla Enter foi pressionada
                    Debug.Log("Enter key is pressed.");

                    if (!string.IsNullOrEmpty(ChatInputField.text))
                    {
                        // Debug: Verifica se o texto não está vazio
                        Debug.Log("Sending message: " + ChatInputField.text);

                        photonView.RPC("SendMessage", RpcTarget.AllBuffered, ChatInputField.text);
                        BubbleSpeechObject.SetActive(true);
                        BubbleSpeechObject.transform.position = GetSpeechPosition();

                        ChatInputField.text = "";
                        DisableSend = true;
                    }
                }
            }
        }
    }

    private Vector3 GetSpeechPosition()
    {
        return transform.position + Vector3.up * 2.0f;
    }

    [PunRPC]
    private void SendMessage(string message)
    {
        UpdateText.text = message;
        StartCoroutine("Remove");
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(4f);
        BubbleSpeechObject.SetActive(false);
        DisableSend = false;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(BubbleSpeechObject.active);
        }
        else if (stream.IsReading)
        {
            BubbleSpeechObject.SetActive((bool)stream.ReceiveNext());
        }
    }
}
