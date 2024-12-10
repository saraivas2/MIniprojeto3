using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras1_2 : MonoBehaviour
{
    [SerializeField] private Camera cam1;
    [SerializeField] private Camera cam2;

    private void Start()
    { 
     cam1 = cam1.GetComponent<Camera>();
     cam2 = cam2.GetComponent<Camera>();
     ligarCamera1();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ligarCamera1();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            ligarCamera2();
        }

        if (Input.GetKey(KeyCode.T))
        {
            viewPortCam1();
            viewPortCam2();
            ligarCamera1();
        }

        if (Input.GetKey(KeyCode.U))
        {
            DesligarCameras();
        }
        if (Input.GetKey(KeyCode.Y))
        {
            viewPortCam12();
            ligarCamera1();
            ligarCamera2();
        }
    }

    void ligarCamera1()
    {
        cam1.enabled = true;
        cam2.enabled = false;   
    }

    void ligarCamera2()
    {
        cam1.enabled = false;
        cam2.enabled = true;
    }

    void DesligarCameras()
    {
        cam1.enabled = false;
        cam2.enabled = false;
    }

    void viewPortCam1()
    {
        cam1.rect = new Rect(0, 0, 1, 1);
    }

    void viewPortCam2()
    {
        cam2.rect = new Rect(0, 0, 1, 1);
    }

    void viewPortCam12()
    {
        cam1.rect = new Rect(0, 0, 0.5f, 1);
        cam2.rect = new Rect(0, 0, 0.5f, 1);
    }
}
