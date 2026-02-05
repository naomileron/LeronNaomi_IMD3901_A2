using UnityEngine;

public class VRSoundEffects : MonoBehaviour
{
    public AudioSource audioSource;

    public void play()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
