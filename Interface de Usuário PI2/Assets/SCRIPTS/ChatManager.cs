using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class ChatManager : MonoBehaviourPun
{
    public GameObject chatBubblePrefab;
    public Transform chatBubbleSpawnPoint;
    private TMP_InputField inputField;
    public float chatBubbleDuration = 4f;

    private void Start()
    {
        inputField = GetComponentInChildren<TMP_InputField>();

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        if (inputField != null)
        {
            inputField.onEndEdit.AddListener(OnEndEdit);
        }
        else
        {
            Debug.LogError("TMP_InputField n�o encontrado no objeto ou em seus filhos: " + gameObject.name);
        }
    }

    private void OnEndEdit(string text)
    {
        if (PhotonNetwork.InRoom)
        {
            // Se estiver em uma sala, voc� pode chamar o RPC.
            photonView.RPC("InstantiateChatBubble", RpcTarget.All, text);
        }
        else
        {
            // Lidar com a l�gica quando n�o estiver em uma sala.
            Debug.LogWarning("Voc� n�o est� em uma sala para enviar RPC.");
            // Adicione qualquer outra l�gica necess�ria aqui.
        }

        // Remova a chamada do RPC aqui para evitar chamadas duplicadas
        // ...

        // Limpe o campo de entrada ap�s o envio da mensagem
        inputField.text = "";
    }

    [PunRPC]
    private void InstantiateChatBubble(string text)
    {
        GameObject chatBubble = PhotonNetwork.Instantiate(chatBubblePrefab.name, chatBubbleSpawnPoint.position, Quaternion.identity);

        TextMeshProUGUI textMeshPro = chatBubble.GetComponent<TextMeshProUGUI>();
        if (textMeshPro != null)
        {
            textMeshPro.text = text;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI not found on chatBubble or its children.");
        }

        Destroy(chatBubble, chatBubbleDuration);
    }
}
