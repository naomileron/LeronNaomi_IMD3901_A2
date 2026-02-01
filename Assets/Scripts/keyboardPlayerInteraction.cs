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
    public AudioSource changeCol;

    public Animator handAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //handAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (heldButterfly != null)
        {
            uiBehaviourScript.SetInteract(false);

            handAnimator.SetBool("CanCatch", false);

            if(Keyboard.current.qKey.wasPressedThisFrame)
            {
                butterflyColourChange colourChange = heldButterfly.GetComponent<butterflyColourChange>();

                if (colourChange != null)
                {
                    colourChange.CycleColour();
                    changeCol.Play();
                }
            }

            if(Keyboard.current.eKey.wasPressedThisFrame)
            {
                handAnimator.SetTrigger("Release");
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

        handAnimator.SetBool("CanCatch", canInteract);

        if (currentButterfly != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            handAnimator.SetTrigger("Grab");

            heldButterfly = currentButterfly;
            currentButterfly.Catch(handTransform);
            capture.Play();
        }

    }

           
}
