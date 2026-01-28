using UnityEngine;

public class butterflyWander : MonoBehaviour
{

    public float moveSpeed = 2.0f;
    public float turnSpeed = 2.0f;

    public float wanderRadius = 10.0f;
    public float changeTargetDistance = 0.5f;

    public float minHeight = 2.0f;
    public float maxHeight = 5.0f;

    private Vector3 targetPosition;

    public GameObject startPos; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (startPos != null)
        {
            transform.position = startPos.transform.position;
        }
        
        targetPosition = transform.position;
        PickNewTarget();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = targetPosition - transform.position;

        //if the butterfly gets within this distance of its target, it will pick a new target to fly towards
        if (direction.magnitude < changeTargetDistance)
        {
            PickNewTarget();
            return;
        }

        //Rotation towards target **used chatGPT to figure this part out
        Quaternion targetRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
        targetRotation *= Quaternion.Euler(0.0f, 0.0f, 0.0f);
        targetRotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        transform.rotation = targetRotation;

        //transform movement
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    //picks a random target for the butterfly (**also used chatGPT to help figure out this)
    void PickNewTarget()
    {
        Vector2 randomXZ = Random.insideUnitCircle * wanderRadius;
        float targetY = Random.Range(minHeight, maxHeight);


        targetPosition = new Vector3(transform.position.x + randomXZ.x, targetY, transform.position.z + randomXZ.y);
    }
}
