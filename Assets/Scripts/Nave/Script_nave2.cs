using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Script_nave2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensibilidade = 1.2f;
    private float velocidade;
    private float aceleracao = 3.0f;
    private float turbo = 1.0f;
    private Vector3 direcao;
    [SerializeField] private Camera camera;
    public float field;


    void Start()
    {
        velocidade = 2;
        direcao = Vector3.zero;
        camera = camera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPersonagem();
        transform.Translate(direcao * velocidade * Time.deltaTime);

        field = camera.fieldOfView;
        if (field > 50f)
        {
            camera.fieldOfView = 50f;
        }
        if (field < 35f)
        {
            camera.fieldOfView = 35f;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
        Quaternion rotacao = Quaternion.identity;
    }

     void aproxima()
    {
        if (camera.fieldOfView > 35f)
        {
            camera.fieldOfView = field - 0.1f;
        }
    }

    void afasta()
    {
        if (camera.fieldOfView < 50f)
        {
            field = camera.fieldOfView;
            camera.fieldOfView = field + 0.1f;
        }
    }
    void InputPersonagem()
    {

        direcao = Vector3.zero;

        if (Input.GetKey(KeyCode.P))
        {
            turbo = 4.0f;
        }
        else
        {
            turbo = 1.0f;
        }
        
        
        
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direcao += Vector3.forward * aceleracao * turbo;
            if (field <= 50f)
            {
                afasta();
            }
            if (aceleracao < 50)
            {
                aceleracao += 0.5f;
            }
        }
        else
        {
            if (aceleracao > 5)
            {
                aceleracao -= 0.2f;
            }
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f,-1f, 0f), (float)(Time.deltaTime * 20));
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0f,1f,0f),(float)(Time.deltaTime * 20));
            
        }
       
        if (Input.GetKey(KeyCode.RightShift))
        {
            direcao += Vector3.down*10;
        }


        if (Input.GetKey(KeyCode.Return))
        {
            direcao+=Vector3.up*10;
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direcao += Vector3.back * aceleracao * turbo;

            if (aceleracao < 50)
            {
                aceleracao += 0.5f;
            }
        }
        else
        {
            if (aceleracao > 5)
            {
                aceleracao -= 0.2f;
            }
        }

        if ((field >= 34 & field < 51) & !Input.GetKey(KeyCode.UpArrow))    
        {
            aproxima();
        }

    }
}
