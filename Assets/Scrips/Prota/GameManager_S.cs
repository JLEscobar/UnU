using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager_S : MonoBehaviour
{
    public CinemachineVirtualCamera character1Camera;
    public CinemachineVirtualCamera character2Camera;

    private CinemachineVirtualCamera activeCamera;

    private void Start()
    {
        // Inicialmente, establecer la cámara activa en la del primer personaje
        SetActiveCamera(character1Camera);
    }

    private void Update()
    {
        // Cambiar entre personajes con una tecla (por ejemplo, la tecla Tab)
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Si la cámara activa es la del primer personaje, cambiar a la del segundo personaje y viceversa
            if (activeCamera == character1Camera)
                SetActiveCamera(character2Camera);
            else
                SetActiveCamera(character1Camera);
        }
    }

    private void SetActiveCamera(CinemachineVirtualCamera camera)
    {
        // Desactivar la cámara activa actual y activar la nueva cámara
        if (activeCamera != null)
            activeCamera.gameObject.SetActive(false);

        activeCamera = camera;
        activeCamera.gameObject.SetActive(true);
    }
}