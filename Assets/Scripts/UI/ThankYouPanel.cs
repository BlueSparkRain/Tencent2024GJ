using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class ThankYouPanel : BasePanel
{
    [Header("ÍË³ö°´¼ü")]
    public Button ExitButton;
    public override void HidePanel()
    {
        base.HidePanel();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        UITween.Instance.UIDoFade(transform,1,0,transTime);
        yield return  new WaitForSeconds(transTime);
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        yield return null;
        UITween.Instance.UIDoFade(transform, 0, 1, transTime);
    }

    protected override void Init()
    {
        base.Init();
        ExitButton.onClick.AddListener(OnClickExitButton);
    }

    void OnClickExitButton() 
    {
        UIManager.Instance.HidePanel<ThankYouPanel>();
    }
}
