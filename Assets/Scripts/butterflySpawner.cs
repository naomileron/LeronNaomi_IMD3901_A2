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

    //generates a random number within the range to determine when the next butterfly will be spawned
    float spawnIntervalGenerator()
    {
        return Random.Range(3.0f, 10.0f);
    }

    void SpawnButterfly()
    {
        //spawn in random x and z position within the limit of the spawn radius
        Vector3 spawnPos = transform.position +
                               Random.insideUnitSphere * spawnRadius;

        //spawns in a random absolute value of a y position
        spawnPos.y = Mathf.Abs(spawnPos.y);

        Instantiate(butterflyPrefab, spawnPos, Quaternion.identity); //spawn logic
        currentButterflyCount++; //keep track of how many butterflies there are in the scene

        Debug.Log("Butterflies spawned: " + currentButterflyCount);
    }

    IEnumerator GradualSpawn()
    {
        //while the butterfly population is below the max, spawn another butterfly after waiting for the random interval established in spawnIntervalGenerator()
        while (currentButterflyCount < maxButterflies)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnButterfly();
        }
    }

    // keeps track of when butterflies despawn, keeping the debug count accurate
    public void butterflyDespawn()
    {
        currentButterflyCount--;
        Debug.Log("Butterfly gone, Count: " + currentButterflyCount);
    }
}
