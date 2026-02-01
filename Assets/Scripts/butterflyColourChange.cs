using UnityEngine;

public class butterflyColourChange : MonoBehaviour
{
    [SerializeField] private Material[] colours;

    private Renderer[] renders;

    private int colourIndex = -1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        renders = GetComponentsInChildren<Renderer>();
    }

    public void CycleColour()
    {
        if(colours == null || colours.Length == 0)
        {
            return;
        }

        colourIndex = (colourIndex + 1) % colours.Length;

        foreach (Renderer r in renders)
        {
            r.material = colours[colourIndex];
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
