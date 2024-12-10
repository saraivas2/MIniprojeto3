using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_1 : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var speed = 0f;
        transform.Rotate(Vector3.up, (float)(Time.deltaTime * speed));
    }
}
