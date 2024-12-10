using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comandaLuz : MonoBehaviour
{
    private Light light1;
    public float timerLight = 5f;
    private float rangeTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
     light1 = GetComponent<Light>();   
    }

    // Update is called once per frame
    void Update()
    {

        TimerOff();
        TimerOn();


    }


    private void TimerOff()
    {
        timerLight -= Time.deltaTime;
        if (timerLight <= 0)
        {
            light1.intensity= 0;
            timerLight = rangeTimer;
        }
    }

    private void TimerOn()
    {
        timerLight -= Time.deltaTime;
        if (timerLight <= 0)
        {
            light1.intensity = 2;
            timerLight = rangeTimer;
        }
    }

}
