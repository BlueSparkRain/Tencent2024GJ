using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MessagePanel : BasePanel
{
    private Animator anim;
    public TMP_Text  message;
    public override void HidePanel()
    {
        base.HidePanel();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        anim.SetTrigger("Close");
        UITween.Instance.UIDoFade(transform, 1, 0, 0.5f);
        yield return new WaitForSeconds(1);
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        yield return null;
        anim.SetTrigger("Open");
        UITween.Instance.UIDoFade(transform,0,1,0.5f);
    }

    public  IEnumerator ShowMessage(string text) 
    {
        message.text = text;
        yield return new WaitForSeconds(1);
        UIManager.Instance.HidePanel<MessagePanel>();
    }

    protected override void Init()
    {
        base.Init();
        if (anim != null)
            return;
        anim = GetComponent<Animator>();
    }
}
