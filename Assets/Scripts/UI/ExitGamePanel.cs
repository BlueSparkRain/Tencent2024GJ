using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGamePanel : BasePanel
{
    public Button YesButton;
    public Button NoButton;
    public override void HidePanel()
    {
        base.HidePanel();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        UITween.Instance.UIDoMove(transform.GetChild(0), Vector2.zero, new Vector2(0,-1000),transTime);
        yield return new WaitForSeconds(transTime);
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        UITween.Instance.UIDoMove(transform.GetChild(0), new Vector2(0,-1000),Vector2.zero,transTime);
        yield break;
    }

    protected override void Init()
    {
        base.Init();
        YesButton.onClick.AddListener(OnClickYesButton);
        NoButton.onClick.AddListener(OnClickNoButton);
    }

    //退出游戏
    void OnClickYesButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    //关闭面板
    void OnClickNoButton() 
    {
    UIManager.Instance.HidePanel<ExitGamePanel>();
    }

}
