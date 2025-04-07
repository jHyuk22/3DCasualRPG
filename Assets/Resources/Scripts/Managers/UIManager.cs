using UnityEngine;

public enum UIType
{
    None = 0,
    LoginPopUp,
    CharacterSelectPopUp,
}

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    public static UIManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public void Instantiate(UIType uiType)
    {
        GameObject targetUI = Resources.Load<GameObject>($"Assets/Resources/Prefabs/UI/{uiType}.prefab");

        if (targetUI == null)
            Debug.LogError($"target is null: Check path Assets/Resources/Prefabs/UI/{uiType}.prefab");

        Instantiate(targetUI, GameObject.Find("Canvas").transform);
        targetUI.GetComponent<BaseUI>().Show();
    }
}
