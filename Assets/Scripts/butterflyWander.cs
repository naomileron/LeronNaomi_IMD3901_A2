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

    bool isCaught;

    public bool IsCaught => isCaught;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //butterflies are assigned a random start position at when play is pressed
        targetPosition = transform.position;
        PickNewTarget();

        moveSpeed *= Random.Range(0.8f, 1.2f); //butterflies move at varying speeds

        isCaught = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCaught)
        {
            return;
        }

        Vector3 direction = targetPosition - transform.position; //fly towards target

        transform.position += Vector3.up * Mathf.Sin(Time.time * 2f) * 0.001f; //up and down movement

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

    public void Catch(Transform hand)
    {
        isCaught = true;

        Collider collider = GetComponent<Collider>();
        if (collider)
        {
            collider.enabled = false;
        }

        transform.position = hand.position;
        transform.rotation = hand.rotation;

        transform.SetParent(hand);
    }

    public void Release()
    {
        isCaught = false;

        transform.SetParent(null);

        Collider collider = GetComponent<Collider>();
        if (collider)
        {
            collider.enabled = true;
        }

        PickNewTarget();
    }

}
