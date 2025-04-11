using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCardPool : MonoBehaviour
{
    [Header("自身出牌总和（假）")]
    public TMP_Text personFakeSum;
    private List<HistorySlot> gameCards = new List<HistorySlot>();//个人出牌区所有卡牌

    public int TotalScore = 0;


    public int TotalScoreReal;

    public void AddCard(PlayButton playButton)
    {
        //在手牌区生成一张对应卡牌
        HistorySlot newCard = Instantiate(Resources.Load<GameObject>("Prefab/HistoryCard"), transform).GetComponent<HistorySlot>();
        //newCard.Init(playButton.AppearNumber);
        newCard.Init(playButton.AppearNumber, playButton.cardSprite);

        gameCards.Add(newCard);
        //更新双方Sum
        GameManager.Instance.UpdateSum(playButton);
        //更新自身FakeSum
        CalculateTotalScore(playButton.AppearNumber);
        personFakeSum.text = TotalScore.ToString();


        Debug.Log("将一张数值为" + playButton.AppearNumber + "，真实数值为" + playButton.RealNumber + "的卡牌加入池子");

        Debug.Log("当前牌池的真实数值为" + CalculateTotalScoreReal(playButton.RealNumber));

    }

    private void CalculateTotalScore(int newValue)
    {
        TotalScore += newValue;

    }

    private int CalculateTotalScoreReal(int newValue)
    {
        TotalScoreReal += newValue;
        return TotalScoreReal;
    }
}
