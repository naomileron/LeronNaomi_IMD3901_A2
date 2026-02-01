using UnityEngine;
using UnityEngine.InputSystem;

public class keyboardPlayerInteraction : MonoBehaviour
{
    public float interactRange = 20.0f;
    public Camera playerCamera;
    public uiBehaviour uiBehaviourScript;

    public Transform handTransform;
    private butterflyWander currentButtefly;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentButtefly = null;
        bool canInteract = false;

        float sphereRadius = 0.2f;

        if (Physics.SphereCast(playerCamera.transform.position, sphereRadius, playerCamera.transform.forward, out RaycastHit hit, interactRange))
        {
            if(hit.collider.CompareTag("Interactable"))
            {
                //uiBehaviourScript.SetInteract(true);
                currentButtefly = hit.collider.GetComponent<butterflyWander>();
                canInteract = currentButtefly != null;
            }
        }
      
        uiBehaviourScript.SetInteract(canInteract);

        if (currentButtefly != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            currentButtefly.Catch(handTransform);
        }

    }

           
}
