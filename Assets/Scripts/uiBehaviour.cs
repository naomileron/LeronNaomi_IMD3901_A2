using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uiBehaviour : MonoBehaviour
{
    public Image crosshair;
    public Color defaultColour = Color.white;
    public Color interactColour = Color.green;

    public TMP_Text catchText;
    public TMP_Text colourChangeText;
    public TMP_Text releaseText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInteract(bool canInteract)
    {
      crosshair.color = canInteract ? interactColour : defaultColour;
    }

    public void HideAll()
    {
        catchText.gameObject.SetActive(false);
        colourChangeText.gameObject.SetActive(false);
        releaseText.gameObject.SetActive(false);
    }

    public void ShowCatchPrompt()
    {
        catchText.gameObject.SetActive(true);
        colourChangeText.gameObject.SetActive(false);
        releaseText.gameObject.SetActive(false);
    }

    public void ShowHoldingPrompts()
    {
        catchText.gameObject.SetActive(false);
        colourChangeText.gameObject.SetActive(true);
        releaseText.gameObject.SetActive(true);
    }

}
