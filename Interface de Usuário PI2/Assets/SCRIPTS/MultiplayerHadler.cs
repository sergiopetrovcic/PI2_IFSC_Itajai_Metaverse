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
            stream.SendNext(transform.position);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
