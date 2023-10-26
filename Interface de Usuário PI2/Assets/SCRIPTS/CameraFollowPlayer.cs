using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject femininoCharacterPrefab;
    public GameObject masculinoCharacterPrefab;
    public float moveSpeed = 2.0f;
    public float zoomSpeed = 1.0f;
    public float initialZoom = 10.0f;
    public float startDelay = 3.0f;

    private Camera mainCamera;
    private GameObject target;
    private bool isZooming = true;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        mainCamera.orthographicSize = initialZoom;

        // Determine qual personagem seguir com base na escolha do jogador

        int selectedGender = PlayerPrefs.GetInt("SelectedGender", 0);

        if (selectedGender == 0)
        {
            target = femininoCharacterPrefab;
        }
        else
        {
            target = masculinoCharacterPrefab;
        }

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
            Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        }
    }

    private void EnableCameraMovement()
    {
        enabled = true;
    }
}