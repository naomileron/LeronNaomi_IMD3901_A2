using UnityEngine;
using UnityEngine.InputSystem;

public class ButterflyInputManager : MonoBehaviour
{
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
