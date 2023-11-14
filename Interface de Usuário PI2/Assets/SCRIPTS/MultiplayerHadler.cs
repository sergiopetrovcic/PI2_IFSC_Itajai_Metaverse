using UnityEngine;
using Photon.Pun;

public class InteractiveObject : MonoBehaviourPunCallbacks, IPunObservable
{
    private void Start()
    {
        if (photonView.IsMine)
        {
            // Configura��es espec�ficas do jogador local, se necess�rio
        }
        else
        {
            // Configura��es espec�ficas para outros jogadores
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Envie dados para outros jogadores
            // Exemplo: stream.SendNext(transform.position);
        }
        else
        {
            // Receba dados de outros jogadores
            // Exemplo: transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
