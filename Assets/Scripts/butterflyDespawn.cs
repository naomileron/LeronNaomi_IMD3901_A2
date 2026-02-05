using System.Collections;
using UnityEngine;

public class butterflyDespawn : MonoBehaviour
{
    public float minLifeSpan = 45.0f;
    public float maxLifeSpan = 120.0f;

    private butterflySpawner spawner; //reference to the butterfly spawner script

    float lifespan;

    private void Awake()
    {
        spawner = FindFirstObjectByType<butterflySpawner>();
        
        lifespan = Random.Range(minLifeSpan, maxLifeSpan); // assigns a random lifetime within the range
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LifeCycle(lifespan));
    }

    IEnumerator LifeCycle(float lifespan)
    {
        //waits for the butterfly's lifetime to be up and then calls the destroy function
        yield return new WaitForSeconds(lifespan);
        Destroy();
    }

    private void Destroy()
    {
        butterflyWander wander = GetComponent<butterflyWander>();

        //Do not destroy the butterfly if it is currently being held by the player
        if (wander != null && wander.IsCaught)
        {
            return;
        }

        //communicates the count to the butterfly spawner script so it can accurately keep track of how many butterflies are in the scene
        if (spawner != null)
        {
            spawner.butterflyDespawn();     
        }

        Destroy(gameObject);
    }
}
