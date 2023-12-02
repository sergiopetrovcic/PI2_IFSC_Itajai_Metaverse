using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ChatManager : MonoBehaviour, IPunObservable
{
    public Player plMove;
    public PhotonView photonView;
    public GameObject BubbleSpeechObject;
    public Text UpdateText;

    public InputField ChatInputField;
    private bool DisableSend;

    private void Awake()
    {
        ChatInputField = GameObject.Find("ChatInputField").GetComponent<InputField>();

        if (ChatInputField == null)
        {
            Debug.LogError("ChatInputField not found or does not have InputField component.");
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            // Verifica se o ChatInputField não é nulo e está focado
            if (ChatInputField != null && ChatInputField.isFocused)
            {
                // Verifica se a tecla Enter foi pressionada
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // Verifica se o texto não está vazio
                    if (!string.IsNullOrEmpty(ChatInputField.text))
                    {
                        // Chama a RPC para enviar a mensagem
                        photonView.RPC("SendMessage", RpcTarget.AllBuffered, ChatInputField.text);
                        BubbleSpeechObject.SetActive(true);

                        // Limpa o texto do ChatInputField
                        ChatInputField.text = "";
                        DisableSend = true;
                    }
                }
            }
        }
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
        }else if (stream.IsReading)
        {
            BubbleSpeechObject.SetActive((bool)stream.ReceiveNext());
        }
    }
}
