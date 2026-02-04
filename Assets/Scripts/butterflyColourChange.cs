using UnityEngine;
using UnityEngine.InputSystem;

public class butterflyColourChange : MonoBehaviour
{
    public Material[] colours;
    public InputActionReference changeColourAction;
    public Renderer[] renders;

    int colourIndex = -1;

    public void Awake()
    {
        renders = GetComponentsInChildren<Renderer>();
    }

    public void OnEnable()
    {
        if (changeColourAction == null)
        {
            Debug.LogError("Change Colour Action is NOT assigned!", this);
            return;
        }

        changeColourAction.action.performed += OnChangeColour;
        changeColourAction.action.Enable();
    }

    public void OnDisable()
    {
        if (changeColourAction == null) return;

        changeColourAction.action.performed -= OnChangeColour;
        changeColourAction.action.Disable();
    }

    public void OnChangeColour(InputAction.CallbackContext context)
    {
        CycleColour();
    }

    public void CycleColour()
    {
        if (colours == null || colours.Length == 0) return;

        colourIndex = (colourIndex + 1) % colours.Length;

        foreach (Renderer r in renders)
        {
            r.material = colours[colourIndex];
        }
    }
}
