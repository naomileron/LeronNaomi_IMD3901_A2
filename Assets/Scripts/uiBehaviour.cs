using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uiBehaviour : MonoBehaviour
{
    public Image crosshair;
    public Color defaultColour = Color.white;
    public Color interactColour = Color.green;

    public TextMeshPro catchText;
    public TextMeshPro colourChangeText;
    public TextMeshPro releaseText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInteract(bool canInteract)
    {
      crosshair.color = canInteract ? interactColour : defaultColour;
    }
}
