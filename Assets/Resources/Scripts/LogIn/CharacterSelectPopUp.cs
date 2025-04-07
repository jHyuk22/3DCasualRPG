public class CharacterSelectPopUp : BaseUI
{
    public void OnClickOK()
    {
        SceneName sceneName = SceneName.Town;        //TODO: 추후 로그아웃한 씬 기억해서 해당 씬으로 로그인하도록 작업
        SceneManager.Instance.LoadScene(sceneName);
    }
}
