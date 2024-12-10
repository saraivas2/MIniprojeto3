using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lensFlareEffects : MonoBehaviour
{
    public Transform esfera1; 
    public Transform esfera2; 
    public Transform esfera3; 
    public Transform sun; 
    public Transform nave; 
    public float maxDistance; 
    public float minDistance; 
    public float offset1 = 0.2f; 
    public float offset2 = 0.5f; 
    public float offset3 = 0.9f; 


    private void Start()
    {
        maxDistance = (float)(GetDistanceFactor() * 0.9f);
        minDistance = (float)(GetDistanceFactor() * 0.05f);
    }
    void Update()
    {
        Vector3 shipToSun = (sun.position - nave.position).normalized;

        UpdateSpherePosition(esfera1, shipToSun, offset1);
        UpdateSpherePosition(esfera2, shipToSun, offset2);
        UpdateSpherePosition(esfera3, shipToSun, offset3);
    }

    private void UpdateSpherePosition(Transform sphere, Vector3 direction, float offsetFactor)
    {
        Vector3 targetPosition = nave.position + direction * Mathf.Clamp(GetDistanceFactor() * offsetFactor, minDistance, maxDistance);

        sphere.position = Vector3.Lerp(sphere.position, targetPosition, Time.deltaTime * 8f); 
    }

    private float GetDistanceFactor()
    {
        float distanceToSun = Vector3.Distance(nave.position, sun.position);
        return distanceToSun;
    }
}
