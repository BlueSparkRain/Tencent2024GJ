using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : BasePanel
{
    public Button MenuButton;
    public Button ReturnButton;

    void OnClickReturnButton() 
    { 
        UIManager.Instance.HidePanel<EndPanel>();
    }
    void OnClickMenuButton() 
    {
        UIManager.Instance.ShowPanel<BlackPanel>(panel => panel.SceneLoadingTrans(1));
        UIManager.Instance.HidePanel<EndPanel>();
    }
    public override void HidePanel()
    {
        base.HidePanel();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        UITween.Instance.UIDoFade(transform.GetChild(3), 1, 0, transTime);
        UITween.Instance.UIDoFade(transform.GetChild(2), 1, 0, transTime);
        UITween.Instance.UIDoFade(transform,1,0,transTime);
        yield return new WaitForSeconds(transTime);
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        StartCoroutine(PlayText());

    }

    IEnumerator PlayText() 
    {
        yield return new WaitForSeconds(1f);
        UITween.Instance.UIDoFade(transform.GetChild(2),0,1,transTime*3);
        yield return new WaitForSeconds(2);
        UITween.Instance.UIDoFade(transform.GetChild(3),0,1,transTime*3);

     
    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        UITween.Instance.UIDoFade(transform, 0, 1, transTime);
        yield return null;
    }

    protected override void Init()
    {
        base.Init();
        MenuButton.onClick.AddListener(OnClickMenuButton);
        ReturnButton.onClick.AddListener(OnClickReturnButton);
    }
}
