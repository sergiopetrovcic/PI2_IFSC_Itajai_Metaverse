using UnityEngine;
using Photon.Pun;

public class PlayerInteraction : MonoBehaviourPun
{
    private void Update()
    {
        if (photonView.IsMine)
        {
            // L�gica de intera��o local
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Execute a intera��o (envie uma RPC, por exemplo)
                photonView.RPC("Interact", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    private void Interact()
    {
        // L�gica de intera��o que ser� executada em todos os clientes
    }
}
