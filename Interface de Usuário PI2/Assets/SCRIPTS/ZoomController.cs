using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public float zoomSpeed = 0.5f; // Velocidade de zoom
    public float targetZoom = 0.5f; // Zoom alvo
    public float minZoom = 0f; // Zoom mínimo

    private Camera mainCamera;
    private Transform characterTransform;

    private void Start()
    {
        mainCamera = Camera.main;
        characterTransform = transform;

        
        mainCamera.transform.position = new Vector3(characterTransform.position.x, characterTransform.position.y, mainCamera.transform.position.z);
    }

    private void Update()
    {
        
        float currentZoom = mainCamera.orthographicSize;
        float newZoom = Mathf.Lerp(currentZoom, targetZoom, zoomSpeed * Time.deltaTime);
        newZoom = Mathf.Max(newZoom, minZoom); 

        mainCamera.orthographicSize = newZoom;
    }
}
