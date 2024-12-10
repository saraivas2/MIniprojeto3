using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_merc : MonoBehaviour
{


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var speed = 2f;
        transform.Rotate(Vector3.up, (float)(Time.deltaTime * speed));
    }
}
