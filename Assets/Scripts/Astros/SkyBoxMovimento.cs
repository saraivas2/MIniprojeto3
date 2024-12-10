using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxMover : MonoBehaviour
{
    public float rotationSpeed = 1f; // Velocidade da rotação

    void Update()
    {
        // Gira o Skybox ao longo do tempo
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
