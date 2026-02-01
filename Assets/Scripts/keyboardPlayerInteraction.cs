using UnityEngine;
using UnityEngine.InputSystem;

public class keyboardPlayerInteraction : MonoBehaviour
{
    public float interactRange = 20.0f;
    public Camera playerCamera;
    public uiBehaviour uiBehaviourScript;

    public Transform handTransform;
    private butterflyWander currentButterfly;
    private butterflyWander heldButterfly;

    public AudioSource capture;
    public AudioSource release;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (heldButterfly != null)
        {
            uiBehaviourScript.SetInteract(false);

            if(Keyboard.current.eKey.wasPressedThisFrame)
            {
                heldButterfly.Release();
                heldButterfly = null;
                release.Play();
            }

            return;
        }

        currentButterfly = null;
        bool canInteract = false;

        float sphereRadius = 0.2f;

        if (Physics.SphereCast(playerCamera.transform.position, sphereRadius, playerCamera.transform.forward, out RaycastHit hit, interactRange))
        {
            if(hit.collider.CompareTag("Interactable"))
            {
                //uiBehaviourScript.SetInteract(true);
                currentButterfly = hit.collider.GetComponent<butterflyWander>();
                canInteract = currentButterfly != null;
            }
        }
      
        uiBehaviourScript.SetInteract(canInteract);

        if (currentButterfly != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            heldButterfly = currentButterfly;
            currentButterfly.Catch(handTransform);
            capture.Play();
        }

    }

           
}
