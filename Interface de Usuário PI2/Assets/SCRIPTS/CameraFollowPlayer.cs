using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public float moveSpeed = 2.0f;  // Velocidade de movimento da câmera
    public float zoomSpeed = 1.0f;  // Velocidade de zoom da câmera
    public float initialZoom = 10.0f;  // Nível de zoom inicial
    public float startDelay = 3.0f;  // Tempo de atraso para ativar o movimento da câmera

    private Camera mainCamera;
    private Transform playerTransform; // Transform do jogador

    private bool isZooming = true;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        mainCamera.orthographicSize = initialZoom;

        // Encontre o objeto do jogador com base no script "PlayerInstantiate"
        playerTransform = FindObjectOfType<PlayerInstanciate>().transform;

        // Desativar o movimento da câmera no início
        enabled = false;

        // Iniciar um temporizador para ativar o movimento da câmera após o atraso
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
