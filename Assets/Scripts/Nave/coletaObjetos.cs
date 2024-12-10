using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coletaObjetos : MonoBehaviour
{
    private GameObject objetos;
    [SerializeField] private int countObj = 0;
    public bool coleta = false;
    private TextMeshProUGUI texto;


    
    // Start is called before the first frame update
    void Start()
    {
        texto = GameObject.FindWithTag("TextCanvas").GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("objeto"))
        {
            coleta = true;
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
       if (coleta)
        {
            countObj++;
            coleta=false;
        }
        texto.text = "Objetos coletados: " + countObj.ToString();
    }
    

}
