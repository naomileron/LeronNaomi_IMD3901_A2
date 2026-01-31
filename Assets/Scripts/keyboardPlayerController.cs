using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;

    public CharacterController controller;
    public Transform cameraTransform;

    float xRotation = 0f;

    //Head bob variables
    public float bobFrequency = 8.0f;
    public float bobStrength = 0.08f;
    private float bobTimer = 0.0f;
    private Vector3 cameraStartPos;
    bool walking;

    //footsteps
    public AudioSource footsteps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Scene has started!");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cameraStartPos = cameraTransform.localPosition;

        footsteps.volume = 0.0f;
        footsteps.Play();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveInput = Keyboard.current != null ? new Vector2
            (
                (Keyboard.current.aKey.isPressed ? -1 : 0) + (Keyboard.current.dKey.isPressed ? 1 : 0),
                (Keyboard.current.sKey.isPressed ? -1 : 0) + (Keyboard.current.wKey.isPressed ? 1 : 0)
            ) : Vector2.zero;

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);


        walking = moveInput.magnitude > 0.1f;

        if (walking)
        {
            bobTimer += Time.deltaTime * bobFrequency;
            float bobOffset = Mathf.Sin(bobTimer) * bobStrength;

            cameraTransform.localPosition = cameraStartPos + Vector3.up * bobOffset;

        }
        else
        {
            bobTimer = 0.0f;
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, cameraStartPos, Time.deltaTime * 5.0f);

        }

        //fades in footstep sfx when the player is moving
        float targetVolume = walking ? 0.6f : 0.0f;
        footsteps.volume = Mathf.Lerp(footsteps.volume, targetVolume, Time.deltaTime * 8.0f);
    }
}
