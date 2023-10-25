using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public float moveSpeed = 2.0f;  // Velocidade de movimento da c�mera
    public float zoomSpeed = 1.0f;  // Velocidade de zoom da c�mera
    public float initialZoom = 10.0f;  // N�vel de zoom inicial
    public float startDelay = 3.0f;  // Tempo de atraso para ativar o movimento da c�mera

    private Camera mainCamera;
    private Transform playerTransform; // Transform do jogador

    private bool isZooming = true;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        mainCamera.orthographicSize = initialZoom;

        // Encontre o objeto do jogador com base no script "PlayerInstantiate"
        playerTransform = FindObjectOfType<PlayerInstanciate>().transform;

        // Desativar o movimento da c�mera no in�cio
        enabled = false;

        // Iniciar um temporizador para ativar o movimento da c�mera ap�s o atraso
        Invoke("EnableCameraMovement", startDelay);
    }

    private void Update()
    {
        if (isZooming)
        {
            float newZoom = Mathf.Lerp(mainCamera.orthographicSize, 5.0f, Time.deltaTime * zoomSpeed);
            mainCamera.orthographicSize = newZoom;

            if (newZoom <= 5.1f)
            {
                isZooming = false;
            }
        }
        else
        {
            Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        }
    }

   
    private void EnableCameraMovement()
    {
        enabled = true;
    }
}
