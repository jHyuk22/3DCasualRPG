using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public struct UserAuthInfo
{
    public string userId;
    public string password;

    public UserAuthInfo(string userId, string password)
    {
        this.userId = userId;
        this.password = password;
    }
}

public class LogInPopUp : BaseUI
{
    private string url = "http://13.124.148.53:8080";

    [SerializeField]
    private TextMeshProUGUI id;
    [SerializeField]
    private TextMeshProUGUI password;

    public UserAuthInfo PackData()
    {
        return new UserAuthInfo(id.text, password.text);
    }

    public void LogIn()
    {
        string path = url + "/auth/login";
        string requestData = JsonUtility.ToJson(PackData());

        StartCoroutine(Post(path, requestData));
    }

    public void SignUp()
    {
        string path = url + "/auth/signup";
        string requestData = JsonUtility.ToJson(PackData());

        StartCoroutine(Post(path, requestData));
    }

    IEnumerator Post(string path, string requestData)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.PostWwwForm(path, requestData))
        {
            byte[] jsonData = new System.Text.UTF8Encoding().GetBytes(requestData);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonData);
            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.error == null)
            {
                UIManager.Instance.Instantiate(UIType.CharacterSelectPopUp);

            }
            else
            {
                Debug.LogError(webRequest.error);
            }
        }
    }

    public void Test()
    {
        StartCoroutine(UnityWebRequestGetTest());
    }

    IEnumerator UnityWebRequestGetTest()
    {
        string path = url + "/test";
        using (UnityWebRequest webResponse = UnityWebRequest.Get(path))
        {
            yield return webResponse.SendWebRequest();

            if (webResponse.error == null)
                Debug.Log(webResponse.downloadHandler.text);
            else
                Debug.Log("error");
        }
    }
}
