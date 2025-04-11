using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SettingPanel : BasePanel
{
    public Button MenuButton;
    public Button TeachButton;
    public Button AudioButton;
    public Button ReturnButton;
    public Button EndButton;
    private Transform root;


    public override void HidePanel()
    {
        base.HidePanel();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        UITween.Instance.UIDoMove(transform.GetChild(1),  Vector2.zero, new Vector2(0, -1000), transTime);
        UITween.Instance.UIDoFade(transform.GetChild(0), 1, 0, transTime);
        yield return new WaitForSeconds(transTime);
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        yield return null;
        UITween.Instance.UIDoMove(transform.GetChild(1), new Vector2(0, -1000), Vector2.zero, transTime);
        UITween.Instance.UIDoFade(transform.GetChild(0), 0, 1, transTime);

    }

    protected override void Init()
    {
        base.Init();
        if (root != null)
            return;
        MenuButton.onClick.AddListener(OnClickMenuButton);
        TeachButton.onClick.AddListener(OnClickTeachButton);
        AudioButton.onClick.AddListener(OnClickAudioButton);
        ReturnButton.onClick.AddListener(OnClickReturnButton);
        EndButton.onClick.AddListener(OnClickEndButton);
        root = transform.GetChild(1);

    }
    void OnClickEndButton() 
    {
        UIManager.Instance.ShowPanel<EndPanel>(null);
        UIManager.Instance.HidePanel<SettingPanel>();

    }

    void OnClickMenuButton()
    {
        UIManager.Instance.ShowPanel<BlackPanel>(panel => panel.SceneLoadingTrans(1));
        UIManager.Instance.HidePanel<SettingPanel>();
    }
    void OnClickTeachButton()
    {
        UIManager.Instance.ShowPanel<TeachPanel>(null);
        UIManager.Instance.HidePanel<SettingPanel>();
    }
    void OnClickAudioButton()
    {
        UIManager.Instance.ShowPanel<AudioPanel>(null);
        UIManager.Instance.HidePanel<SettingPanel>();
    }
    void OnClickReturnButton()
    {

        UIManager.Instance.HidePanel<SettingPanel>();
    }
}
