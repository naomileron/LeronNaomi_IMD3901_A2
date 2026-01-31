using UnityEngine;
using UnityEngine.InputSystem;

public class keyboardPlayerInteraction : MonoBehaviour
{
    public float interactRange = 20.0f;
    public Camera playerCamera;
    public uiBehaviour uiBehaviourScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        //RaycastHit hit;

        float sphereRadius = 0.2f;

        if (Physics.SphereCast(playerCamera.transform.position, sphereRadius, playerCamera.transform.forward, out RaycastHit hit, interactRange))
        {
            if(hit.collider.CompareTag("Interactable"))
            {
                uiBehaviourScript.SetInteract(true);

                return;
            }
        }

        uiBehaviourScript.SetInteract(false);

    //    Debug.DrawRay(
    //        playerCamera.transform.position,
    //        playerCamera.transform.forward * interactRange,
    //        Color.green
    //        );
    //    Debug.DrawLine(
    //playerCamera.transform.position,
    //playerCamera.transform.position + playerCamera.transform.forward * interactRange,
    //Color.green
//);
    }
}
