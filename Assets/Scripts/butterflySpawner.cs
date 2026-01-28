using UnityEngine;

public class butterflySpawner : MonoBehaviour
{
    public GameObject butterflyPrefab;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject butterfly = Instantiate(butterflyPrefab, transform.position, transform.rotation);
        butterfly.GetComponent<butterflyWander>().startPos = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
