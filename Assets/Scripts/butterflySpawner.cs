using UnityEngine;

public class butterflySpawner : MonoBehaviour
{
    public GameObject butterflyPrefab;
    public int butterflyCount = 10;
    public float spawnRadius = 10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < butterflyCount; i++)
        {
            Vector3 spawnPos = transform.position +
                               Random.insideUnitSphere * spawnRadius;

            spawnPos.y = Mathf.Abs(spawnPos.y);

            Instantiate(butterflyPrefab, spawnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
