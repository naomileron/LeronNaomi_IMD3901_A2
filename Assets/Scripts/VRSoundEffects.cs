using UnityEngine;
using UnityEngine.XR;

public class XRButtonSFX : MonoBehaviour
{
    public AudioSource grab;
    public AudioSource splash;

    private InputDevice rightHand;
    private bool primarywasPressedLastFrame = false;
    private bool gripWasPressedLastFrame = false;

    void Start()
    {
        rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    void Update()
    {
        if (!rightHand.isValid)
        {
            rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            return;
        }

        if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryPressed))
        {
            // Button DOWN (edge detection)
            if (primaryPressed && !primarywasPressedLastFrame)
            {
                grab.Play();
            }

            primarywasPressedLastFrame = primaryPressed;
        }

        if (rightHand.TryGetFeatureValue(CommonUsages.gripButton, out bool gripPressed))
        {
            if (gripPressed && !gripWasPressedLastFrame)
            {
                if (splash != null)
                    splash.Play();
            }

            gripWasPressedLastFrame = gripPressed;
        }
    }
}
