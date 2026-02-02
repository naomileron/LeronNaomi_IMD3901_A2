using UnityEngine;

public class playModeSelection : MonoBehaviour
{
    public void KeyboardSelected()
    {
        Debug.Log("KEYBOARD MODE SELECTED");
        PlayerPrefs.SetInt("PlayerMode", 0);
        PlayerPrefs.Save();
    }

    public void HMDSelected()
    {
        Debug.Log("HMD MODE SELECTED");
        PlayerPrefs.SetInt("PlayerMode", 1);
        PlayerPrefs.Save();
    }
}
