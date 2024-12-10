using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandaSpotLight : MonoBehaviour
{
    private Light spotlight;
    private GameObject Nave;
    public bool travarMouse = true;
    private float mouseX = 0.0f, mouseY = 0.0f;
    public float sensibilidade = 1.2f;
    private Vector3 vetor;

    // Start is called before the first frame update
    void Start()
    {
     spotlight=GameObject.FindWithTag("spot").GetComponent<Light>();
     Nave = GameObject.FindWithTag("nave");
     spotlight.enabled = false;
     vetor = spotlight.transform.position - Nave.transform.position;
     if (!travarMouse)
     {
          return;
      }
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            spotlight.enabled=true;
            // Smoothly tilts a transform towards a target rotation.
        }
        if (Input.GetMouseButton(1))
        {
            spotlight.enabled = false;
        }

        if (spotlight.enabled)
        {
            spotlight.spotAngle += Input.GetAxis("Mouse ScrollWheel")*5;
            spotlight.intensity -= Input.GetAxis("Mouse ScrollWheel")/2;
            mouseY += Input.GetAxis("Mouse X") * sensibilidade;
            mouseX += Input.GetAxis("Mouse Y") * sensibilidade;
            transform.eulerAngles = new Vector3(mouseX, mouseY, 0);
        }
        else
        {
            spotlight.transform.position = Nave.transform.position + vetor;
            spotlight.transform.rotation = Nave.transform.rotation;
        }
    }
}
