using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class MenuPanel : BasePanel
{
    public Button PlayButton;
    public Button ThankYouButton;
    public Button ExitGameButton;
    public Button AudioButton;
    public SceneData GameScene;
    public Animator characterAnim;
    public CanvasGroup buttonsGroup;
    
    public override void HidePanel()
    {
        base.HidePanel();
        transform.GetChild(0).localScale = Vector3.one;
        buttonsGroup.interactable = true;
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        UITween.Instance.UIDoFade(transform,1,0,transTime*1.5f);
        yield return  new  WaitForSeconds(transTime*1.5f);
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
        PlayButton.onClick.AddListener(OnClickPlayButton);
        ThankYouButton.onClick.AddListener(OnClickThankYouButton);
        AudioButton.onClick.AddListener(OnClickAudioButton);
        ExitGameButton.onClick.AddListener(OnClickExitGameButton);
    }

    private void OnClickPlayButton()
   {
      StartCoroutine(StartGame()); 
    }
    private void OnClickThankYouButton() 
    {
        UIManager.Instance.ShowPanel<ThankYouPanel>(null);
    }

    private void OnClickAudioButton() 
    {
        UIManager.Instance.ShowPanel<AudioPanel>(null);
    }

    private void OnClickExitGameButton() 
    {
        UIManager.Instance.ShowPanel<ExitGamePanel>(null);
    }

    IEnumerator StartGame() 
    {
        buttonsGroup.interactable = false;
        yield return HelperTool.MakeLerp(transform.GetChild(0).localScale,Vector3.one*0.8f,2,val=> transform.GetChild(0).localScale=val);
        yield return new WaitForSeconds(0.5f);
        characterAnim.SetTrigger("OpenEye");
        yield return new WaitForSeconds(0.5f);
        UIManager.Instance.ShowPanel<BlackPanel>(panel => panel.SceneLoadingTrans(2));
        yield return Wait();
    }
  
    IEnumerator Wait() 
    {
        yield return new WaitForSeconds(1f);
        UIManager.Instance.HidePanel<MenuPanel>();
    }
}

 
