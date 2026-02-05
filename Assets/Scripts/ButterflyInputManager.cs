using UnityEngine;
using UnityEngine.InputSystem;

public class ButterflyInputManager : MonoBehaviour
{
    //Handles colour change action with VR controls (set up in the input action asset in unity)
    public static System.Action OnChangeColour;

    public InputActionReference changeColourAction;

    void OnEnable()
    {
        changeColourAction.action.performed += HandleChangeColour;
        changeColourAction.action.Enable();
    }

    void OnDisable()
    {
        changeColourAction.action.performed -= HandleChangeColour;
        changeColourAction.action.Disable();
    }

    void HandleChangeColour(InputAction.CallbackContext context)
    {
        OnChangeColour?.Invoke();
    }
}
