using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAudioTrackPanel : BasePanel
{
    public Animator  swapAnim;
    bool  hasSwap=false;

    [Header("交换声道按钮")]
    public Button swapButon;
    [Header("开始游戏")]
    public Button beginButton;

    public Transform White;
    public Transform Black;

    void OnClickSwapButton() 
    {
        if (!hasSwap)
        {
            swapButon.interactable=false;
            swapAnim.SetBool("Swap",true);
            swapAnim.SetBool("NoSwap", false);
            StartCoroutine(Wait1());
        }
        else 
        {
            swapButon.interactable = false;
            swapAnim.SetBool("NoSwap",true);
            swapAnim.SetBool("Swap", false);

            StartCoroutine(Wait2());
        }
        GameManager.Instance.SwapAudioTrack();
    }

    IEnumerator Wait1() 
    {
        yield return new WaitForSeconds(0.5f);
        hasSwap = true;
        swapButon.interactable=true;
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.5f);
        hasSwap = false;
        swapButon.interactable = true;
    }

    void OnClickBeginGameButton() 
    {
        GameManager.Instance.FirstHand();
        UIManager.Instance.HidePanel<SelectAudioTrackPanel>();
    }

    public override void HidePanel()
    {
        base.HidePanel();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        UITween.Instance.UIDoFade(transform,1,0,transTime);
        UITween.Instance.UIDoMove(Black, new Vector2(-400, -30), new Vector2(-2000, -30), 0.5f);
        UITween.Instance.UIDoMove(White, new Vector2(400, -30), new Vector2(2000, -30), 0.5f);

        yield return new WaitForSeconds(transTime);
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        UIManager.Instance.HidePanel<ComicPanel>();
    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        UITween.Instance.UIDoFade(transform, 0, 1, transTime);
        UITween.Instance.UIDoMove(Black, new Vector2(-2000, -30), new Vector2(-400, -30), 0.5f);
        UITween.Instance.UIDoMove(White, new Vector2(2000, -30), new Vector2(400, -30), 0.5f);
      
        yield return null;
    }

    protected override void Init()
    {
        base.Init();
        swapButon.onClick.AddListener(OnClickSwapButton);
        beginButton.onClick.AddListener(OnClickBeginGameButton);
    }
}
