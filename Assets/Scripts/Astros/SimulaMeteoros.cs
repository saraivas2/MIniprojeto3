using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    private GameObject meteoroPrefab; 
    public GameObject nave; 
    public float spawnRadius = 180f; 
    public float safeDistance = 800f; 
    public int spawnCount = 15; 
    public float parabolaHeight = 18f; 
    public float speed = 10f; 

    void Start()
    {
        // Gera meteoros em intervalos regulares
        InvokeRepeating(nameof(SpawnMeteors), 5f, 10f);
        nave = GameObject.FindWithTag("nave");
        meteoroPrefab = Resources.Load("cometas") as GameObject;
    }

    void SpawnMeteors()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = GenerateSpawnPosition();
            GameObject meteoro = Instantiate(meteoroPrefab, spawnPosition, Quaternion.identity);

            // Trajetória parabólica
            Vector3 targetPosition = nave.transform.position + Random.onUnitSphere * safeDistance; 
            StartCoroutine(MoveMeteorParabolic(meteoro, spawnPosition, targetPosition));
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        // Gera uma posição ao redor da nave fora da safeDistance
        Vector3 offset = Random.onUnitSphere * spawnRadius;
        return nave.transform.position + offset;
    }

    System.Collections.IEnumerator MoveMeteorParabolic(GameObject meteoro, Vector3 start, Vector3 end)
    {
        float time = 0;
        float duration = Vector3.Distance(start, end) / speed;

        while (time < 1)
        {
            time += Time.deltaTime / duration;

            // Fórmula para a parábola
            Vector3 midPoint = Vector3.Lerp(start, end, time);
            midPoint.y += Mathf.Sin(time * Mathf.PI) * parabolaHeight;

            meteoro.transform.position = midPoint;
            yield return null;
        }

        Destroy(meteoro); // Remove o meteoro após o movimento
    }
}
