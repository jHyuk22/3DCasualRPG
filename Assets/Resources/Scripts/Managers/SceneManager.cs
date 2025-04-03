using UnityEngine;
public enum SceneName
{
    None = 0,
    Intro,
    Village,
}
public class SceneManager : MonoBehaviour
{
    private static SceneManager instance = null;
    public static SceneManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void OnClickOK(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(SceneName sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName.ToString());
    }
}
