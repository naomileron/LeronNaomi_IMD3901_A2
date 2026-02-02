using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour
{
    [SerializeField]
    public string scene;

    public void next(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
}
