using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPanel : BasePanel
{
    public Slider  BGM_Slider;
    public Slider  SFX_Slider;
    public Button exitButton;
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
        UITween.Instance.UIDoFade(transform, 0, 1, transTime);
        yield return null;
    }

    protected override void Init()
    {
        base.Init();
        BGM_Slider.onValueChanged.AddListener(MusicManager.Instance.ChangeBKMusicValue);
        SFX_Slider.onValueChanged.AddListener(MusicManager.Instance.ChangeSoundValue);
        exitButton.onClick.AddListener(OnClickExitButton);
    }
    void OnClickExitButton()
    {
        UIManager.Instance.HidePanel<AudioPanel>();
    }
}
