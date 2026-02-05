using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class butterflyColourChange : MonoBehaviour
{
    public Material[] colours; //stores the different colours for the butterfly change to
    public Renderer[] renders; //stores the meshes on the inputed object

    private XRGrabInteractable grabInteractable;
    int colourIndex = -1; //-1 so that the index starts at 0

    public playModeManager modemanager;

    void Awake()
    {
        renders = GetComponentsInChildren<Renderer>(); //get the individual meshes in the butterfly fbx
        grabInteractable = GetComponent<XRGrabInteractable>(); //component to check if the butterfly is being held
    }

    //VR controls
    void OnEnable()
    {
        ButterflyInputManager.OnChangeColour += CycleColour;
    }

    void OnDisable()
    {
        ButterflyInputManager.OnChangeColour -= CycleColour;
    }

    public void CycleColour()
    {
        //if not held by the VR control, do nothing
        //if (grabInteractable != null && !grabInteractable.isSelected) return; //****This line fixes all the butterflies changing in vr mode, but breaks the keyboard logic*****

        //if the matierial index is empty, do nothing
        if (colours == null || colours.Length == 0) return;

        //Allows player to cycle through all the colours endlessly. It restarts back at 0 once it gets to the last item in the array
        colourIndex = (colourIndex + 1) % colours.Length;

        //cycling logic
        foreach (Renderer r in renders)
        {
            r.material = colours[colourIndex];
        }
    }
}
