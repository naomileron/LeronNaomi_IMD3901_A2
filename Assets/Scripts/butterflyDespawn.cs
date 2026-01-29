using System.Collections;
using UnityEngine;

public class butterflyDespawn : MonoBehaviour
{
    public float minLifeSpan = 45.0f;
    public float maxLifeSpan = 120.0f;

    private butterflySpawner spawner;

    float lifespan;

    private void Awake()
    {
        spawner = FindFirstObjectByType<butterflySpawner>();
        
        lifespan = Random.Range(minLifeSpan, maxLifeSpan);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LifeCycle(lifespan));
    }

    IEnumerator LifeCycle(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        Destroy();
    }

    private void Destroy()
    {
       if (spawner != null)
        {
            spawner.butterflyDespawn();

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
