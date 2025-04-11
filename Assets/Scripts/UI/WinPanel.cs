using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : BasePanel
{
    public Button NewGameButton;
    public Button MenuButton;
    public SceneData  menuSceneData;
    public SceneData  playSceneData;
    public TMP_Text WinnerText;

    public GameObject WhiteWin;
    public GameObject BlackWin;
    public override void HidePanel()
    {
        base.HidePanel();
        WhiteWin.SetActive(false);
        BlackWin.SetActive(false);
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        UITween.Instance.UIDoMove(transform.GetChild(1), Vector2.zero, new Vector2(0, -2000), transTime);
        UITween.Instance.UIDoFade(transform.GetChild(0), 1, 0, transTime);
        yield return new WaitForSeconds(transTime);
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        UITween.Instance.UIDoMove(transform.GetChild(1),new Vector2(0,-2000),Vector2.zero,transTime);
        UITween.Instance.UIDoFade(transform.GetChild(0),0,1,transTime);
        yield break;
    }

    public void ShowWinner(string winnerName) 
    {
        WinnerText.text = "Winner Is" + winnerName + "!!!";

        switch (winnerName)
        {
            case "White":
                WhiteWin.SetActive(true);
                   break;
            case "Black":
                BlackWin.SetActive(true);
                break;
            default:
                break;
        }
    }
    protected override void Init()
    {
        base.Init();
        NewGameButton.onClick.AddListener(OnClickNewGameButton);
        MenuButton.onClick.AddListener(OnClickReturnMenuButton);
    }

    void OnClickNewGameButton() 
    {
        GameManager.Instance.NewGame();
        UIManager.Instance.ShowPanel<BlackPanel>(panel => panel.SceneLoadingTrans(2));
        UIManager.Instance.HidePanel<WinPanel>();
    }
    void OnClickReturnMenuButton() 
    {
        UIManager.Instance.ShowPanel<BlackPanel>(panel => panel.SceneLoadingTrans(1));
        UIManager.Instance.HidePanel<WinPanel>();
    }
}
