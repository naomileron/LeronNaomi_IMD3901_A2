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

    // Update is called once per frame
     void Update()
    {
        //if a butterfly is being held...
        if (heldButterfly != null)
        {
            uiBehaviourScript.SetInteract(false);//...change the crosshair back to white..
            uiBehaviourScript.ShowHoldingPrompts();//..and show instructions on changing colour and releasing the butterfly

            handAnimator.SetBool("CanCatch", false);//animator logic (turns off the anticipate animation)

            //calling colour cycling logic from the butterflyColourChange script when q is pressed
            if(Keyboard.current.qKey.wasPressedThisFrame)
            {
                butterflyColourChange colourChange = heldButterfly.GetComponent<butterflyColourChange>();

                //checks again that a butterfly is being held
                if (colourChange != null)
                {
                    colourChange.CycleColour();
                    changeCol.Play();//play sfx
                }
            }

            //if a butterfly is being held, release the butterfly when the e key is pressed (using logic from butterfly wander)
            if(Keyboard.current.eKey.wasPressedThisFrame)
            {
                handAnimator.SetTrigger("Release");//use releasing animation
                heldButterfly.Release();//function from butterfly wander
                heldButterfly = null; //keep track of the fact that no butterfly is held anymore
                release.Play(); //play sfx
                uiBehaviourScript.HideAll(); //hide all instructions
            }

            return;
        }

        currentButterfly = null; //until told otherwise, no butterfly is being held
        bool canInteract = false; //until told otherwise, the player cannot interact with the butterfly

        float sphereRadius = 0.2f;

        if (Physics.SphereCast(playerCamera.transform.position, sphereRadius, playerCamera.transform.forward, out RaycastHit hit, interactRange))
        {
            if(hit.collider.CompareTag("Interactable"))
            {
                
                currentButterfly = hit.collider.GetComponent<butterflyWander>();
                canInteract = currentButterfly != null;
            }
        }
      
        //ui behaviour based on the player interaction
        uiBehaviourScript.SetInteract(canInteract);

        if(canInteract)
        {
            uiBehaviourScript.ShowCatchPrompt();
        }
        else
        {
            uiBehaviourScript.HideAll();
        }

            handAnimator.SetBool("CanCatch", canInteract);

        if (currentButterfly != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            handAnimator.SetTrigger("Grab");

            heldButterfly = currentButterfly;
            currentButterfly.Catch(handTransform);
            capture.Play();

            uiBehaviourScript.HideAll();
        }

    }

           
}
