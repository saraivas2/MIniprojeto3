using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coletaObjetos : MonoBehaviour
{
    private GameObject objetos;
    [SerializeField] private int countObj = 0;
    private bool coleta = false;
    private TextMeshPro texto;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("objeto"))
        {
            coleta = true;
            Destroy(objetos.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        objetos = GameObject.FindWithTag("objetos");
    }

    // Update is called once per frame
    void Update()
    {
       if (coleta)
        {
            countObj++;
            texto.text = "Objetos coletados: " + countObj.ToString();
            coleta=false;
        }
    }
}
