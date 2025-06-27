using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] string _sceneName;
    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
