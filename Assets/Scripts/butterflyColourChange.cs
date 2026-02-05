using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class butterflyColourChange : MonoBehaviour
{
    public Material[] colours;
    public Renderer[] renders;

    private XRGrabInteractable grabInteractable;
    int colourIndex = -1;

    void Awake()
    {
        renders = GetComponentsInChildren<Renderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

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
        if (grabInteractable != null && !grabInteractable.isSelected) return;

        if (colours == null || colours.Length == 0) return;

        colourIndex = (colourIndex + 1) % colours.Length;

        foreach (Renderer r in renders)
        {
            r.material = colours[colourIndex];
        }
    }
}
