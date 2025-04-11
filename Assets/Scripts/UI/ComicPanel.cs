using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ComicPanel : BasePanel
{
    public List<CanvasGroup> imageCanvaGroups = new List<CanvasGroup>();
    public List<CanvasGroup> textsCanvaGroup = new List<CanvasGroup>();
    public bool canNextComic=false;
    [Header("出现所需时间")]
    public float transDuration = 2;
    public int currentIndex;

    [Header("跳过按钮")]
    public Button SkipButton;

    public Transform AnyKeyLookTeachMessage;
    public Transform AnyKeyInToGameMessage;

    [Header("荒原狼的话")]
    public Transform FirstTextGroup;

    [Header("点击信息")]
    public Transform MouseTeachGroup;


     float timer;
     bool isEnd=false;
     bool canIntoGame=false;
     bool canLookTeach=true;

    IEnumerator FadeIn()
    {
        if (currentIndex == imageCanvaGroups.Count)
             yield break;
        timer = 0;
        while (timer <= transDuration)
        {
            float value = Mathf.Lerp(0, 1, timer / transDuration);
            timer += Time.deltaTime;
            yield return null;

            imageCanvaGroups[currentIndex].alpha = value;
            textsCanvaGroup[currentIndex].alpha = value;
        }
        if (timer>=transDuration)
        {
            imageCanvaGroups[currentIndex].alpha = 1;
            textsCanvaGroup[currentIndex].alpha = 1;
            canNextComic = true;
            currentIndex++;
        }
    }

    private void Update()
    {
        if (canNextComic && Input.GetKeyDown(KeyCode.Mouse0))
        {
            canNextComic = false;
            Debug.Log("Test");
            StartCoroutine(FadeIn());
            if(currentIndex>=1)
            UITween.Instance.UIDoFade(textsCanvaGroup[currentIndex-1].transform,1,0,0.2f);
        }

        if (currentIndex == imageCanvaGroups.Count && !isEnd) 
        {
          isEnd = true;
          UITween.Instance.UIDoFade(AnyKeyLookTeachMessage, 0, 1, 0.4f);
        }

       

        if (canLookTeach && isEnd && Input.GetKeyDown(KeyCode.Space)) 
        {
            StartCoroutine(WaitCanEnterGame());
          //  AnyKeyLookTeachMessage.GetComponent<CanvasGroup>().alpha = 0;
            UIManager.Instance.ShowPanel<TeachPanel>(null);
            canLookTeach = false;
        }

        if (canIntoGame)
        {
            UITween.Instance.UIDoFade(AnyKeyInToGameMessage, 0, 1, 0.4f);
        }

        if(canIntoGame && Input.GetKeyDown(KeyCode.Space)) 
        {
            canIntoGame = false;
            StartCoroutine(WaitForNext());
        }
    }

   

    IEnumerator WaitForNext() 
    {
        UITween.Instance.UIDoFade(AnyKeyInToGameMessage,1,0,0.2f);
        yield return new WaitForSeconds(0.3f);
        UIManager.Instance.ShowPanel<SelectAudioTrackPanel>(null);
        UIManager.Instance.HidePanel<ComicPanel>();
    }

    IEnumerator WaitCanEnterGame()
    {
           UITween.Instance.UIDoFade(AnyKeyLookTeachMessage,1,0,0.5f);
        yield return new WaitForSeconds(0.8f);
        canIntoGame = true;
    }

    void OnClickSkipButton()
    {
        Debug.Log("下一章！！！");
        if(!canNextComic)
        timer = transDuration;
    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        UITween.Instance.UIDoFade(transform, 0, 1, transTime);
        yield return null;
    }

    IEnumerator ShowFirstText() 
    {
        yield return new WaitForSeconds(2);
        UITween.Instance.UIDoFade(FirstTextGroup, 0, 1, 2);
        yield return new WaitForSeconds(2);
        UITween.Instance.UIDoFade(FirstTextGroup, 1, 0, 1f);
        UITween.Instance.UIDoFade(MouseTeachGroup, 0, 1, 1);
        canNextComic = true;//消失后可以播放漫画
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        StartCoroutine(ShowFirstText());
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        UITween.Instance.UIDoFade(transform,1,0,transTime);
        UITween.Instance.UIDoFade(MouseTeachGroup, 0, 0, 0.3f);
        yield return  new WaitForSeconds(transTime);
        isEnd = false;
        currentIndex = 0;
        canNextComic = false;
        canLookTeach = true;
        AnyKeyInToGameMessage.GetComponent<CanvasGroup>().alpha = 0f;
        AnyKeyLookTeachMessage.GetComponent<CanvasGroup>().alpha = 0f;
        MouseTeachGroup.GetComponent<CanvasGroup>().alpha = 0f;
        for (int i = 0; i < imageCanvaGroups.Count; i++)
        {
            imageCanvaGroups[i].alpha = 0;
            textsCanvaGroup[i].alpha = 0;
        }
    }

    public override void HidePanel()
    {
        base.HidePanel();
        //isEnd = false;
        //currentIndex = 0;
        //canNextComic = false;
        //canIntoGame = false;
        //canLookTeach = true;
        //AnyKeyLookTeachMessage.GetComponent<CanvasGroup>().alpha = 0f;
        //AnyKeyInToGameMessage.GetComponent<CanvasGroup>().alpha = 0f;
        //MouseTeachGroup.GetComponent<CanvasGroup>().alpha = 0f;
        //for (int i = 0; i < imageCanvaGroups.Count; i++)
        //{
        //    imageCanvaGroups[i].alpha = 0;
        //    textsCanvaGroup[i].alpha = 0;
        //}
    }

    protected override void Init()
    {
        base.Init();
        SkipButton.onClick.AddListener(OnClickSkipButton);
    }
}
