public class CharacterSelectPopUp : BaseUI
{
    public void OnClickOK()
    {
        SceneName sceneName = SceneName.Town;        //TODO: ���� �α׾ƿ��� �� ����ؼ� �ش� ������ �α����ϵ��� �۾�
        SceneManager.Instance.LoadScene(sceneName);
    }
}
