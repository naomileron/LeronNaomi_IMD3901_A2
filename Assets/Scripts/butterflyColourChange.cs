using UnityEngine;

public class butterflyColourChange : MonoBehaviour
{
    public Material[] colours;
    public Renderer[] renders;

    int colourIndex = -1;

    void Awake()
    {
        renders = GetComponentsInChildren<Renderer>();
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
        if (colours == null || colours.Length == 0) return;

        colourIndex = (colourIndex + 1) % colours.Length;

        foreach (Renderer r in renders)
        {
            r.material = colours[colourIndex];
        }
    }
}
