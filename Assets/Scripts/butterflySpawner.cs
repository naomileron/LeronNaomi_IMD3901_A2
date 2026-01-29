using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class butterflySpawner : MonoBehaviour
{
    //initial spawning behaviour variables
    public GameObject butterflyPrefab;
    public int InitialbutterflyCount = 10;
    public float spawnRadius = 10.0f;

    //variables for spawning during runtime
    public float spawnInterval;
    public int maxButterflies = 30;

    //Debugging (keeping track of how many butterflies are in the scene)
    private int currentButterflyCount = 0;

    private void Awake()
    {
        spawnInterval = spawnIntervalGenerator(); //length between first runtime spawn is random
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < InitialbutterflyCount; i++)
        {
            SpawnButterfly();
        }

        StartCoroutine(GradualSpawn());
    }

    private void Update()
    {
        spawnInterval = spawnIntervalGenerator(); //keep updating the length between spawns
    }

    float spawnIntervalGenerator()
    {
        return Random.Range(3.0f, 10.0f);
    }

    void SpawnButterfly()
    {
        Vector3 spawnPos = transform.position +
                               Random.insideUnitSphere * spawnRadius;

        spawnPos.y = Mathf.Abs(spawnPos.y);

        Instantiate(butterflyPrefab, spawnPos, Quaternion.identity);
        currentButterflyCount++;

        Debug.Log("Butterflies spawned: " + currentButterflyCount);
    }

    IEnumerator GradualSpawn()
    {
        while (currentButterflyCount < maxButterflies)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnButterfly();
        }
    }
}
