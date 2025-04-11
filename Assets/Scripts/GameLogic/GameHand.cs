using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHand : MonoBehaviour
{
  
    [Header("灯光")]
    public Transform lightImage;


    private List<PlayButton>  playCards=new List<PlayButton>();

    private PlayButton ButtonOne;
    private PlayButton ButtonTwo;
    private PlayButton ButtonThree;
    private PlayButton ButtonFour;
    private CanvasGroup canvasGroup;

    public Animator characterAnim;


    private void Awake()
    {
        ButtonOne=transform.GetChild(0).GetComponent<PlayButton>();
        ButtonTwo=transform.GetChild(1).GetComponent<PlayButton>();
        ButtonThree=transform.GetChild(2).GetComponent<PlayButton>();
        ButtonFour=transform.GetChild(3).GetComponent<PlayButton>();
       
        playCards.Add(ButtonOne);
        playCards.Add(ButtonTwo);
        playCards.Add(ButtonThree);
        playCards.Add (ButtonFour);
        canvasGroup=GetComponent<CanvasGroup>();
    }


    public void InitPlayButton(GamePlayer player)
    {
        for (int i = 0; i < playCards.Count; i++) 
        {
            playCards[i].Init(player);
        }
    }

    public IEnumerator EnterTurn()
    {
        UITween.Instance.UIDoFade(lightImage,0,1,0.2f);
        //播放交换回合的音效
        MusicManager.Instance.PlaySound("ChangeTurn");

        canvasGroup.interactable = true;
        yield return null;
    }

    //public static void Freeze() 
    //{
    //    canvasGroup.interactable = false;
    //}



    public IEnumerator ExitTurn()
    {
        UITween.Instance.UIDoFade(lightImage, 1, 0, 0.2f);
        //播放
        characterAnim.SetTrigger("Play");
        canvasGroup.interactable = false;
        yield return  new WaitForSeconds(1f);
        characterAnim.SetTrigger("Idle");
    }
    /// <summary>
    /// 初始化所有卡牌的值
    /// </summary>
    public void SetFakeCard(int fakeIndex) 
    {
        playCards[fakeIndex-1].SetFake();
    }
}
