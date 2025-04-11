using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TeachPanel : BasePanel
{
    public Button ExitButton;
    public Image teachImage;

    public Button LeftButton;
    public Button RightButton;
    public int panelsCount;
    public Transform Root;

    public int currrentIndex = 0;//Ä¬ÈÏ0ºÅ

    void OnClickRightButton()
    {
       StartCoroutine(ButtonFreeze());
        if (currrentIndex + 1 < panelsCount)
        {
           
            Debug.Log("ÓÒ");
            UITween.Instance.UIDoLocalMove(Root, new Vector2(-1600, 0), transTime);
            currrentIndex+=1;
        }
    }

    IEnumerator ButtonFreeze() 
    {
        RightButton.interactable = false;
        LeftButton.interactable = false;
        yield return new WaitForSeconds(transTime);
        RightButton.interactable = true;
        LeftButton.interactable = true;
        
    }

    void OnClickLeftButton()
    {
        StartCoroutine(ButtonFreeze());
        if (currrentIndex - 1 >= 0)
        {

            Debug.Log("×ó");
            UITween.Instance.UIDoLocalMove(Root, new Vector2(1600, 0), transTime);
            currrentIndex-=1;
        }
    }

    private void Update()
    {
        if (currrentIndex == 0)
        {
            LeftButton.interactable = false;
        }
        else
        {

            LeftButton.interactable = true;
        }

        if (currrentIndex == panelsCount - 1)
        {
            RightButton.interactable = false;
        }
        else
        {
            RightButton.interactable = true;
        }
    }

    public override void HidePanel()
    {
        base.HidePanel();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        UITween.Instance.UIDoFade(transform, 1, 0, transTime);
        yield return new WaitForSeconds(transTime);
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
        RightButton.onClick.AddListener(OnClickRightButton);
        LeftButton.onClick.AddListener(OnClickLeftButton);
    }

    void OnClickExitButton()
    {
        UIManager.Instance.HidePanel<TeachPanel>();

    }
}
