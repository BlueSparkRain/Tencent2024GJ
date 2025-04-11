using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCardPool : MonoBehaviour
{
    [Header("��������ܺͣ��٣�")]
    public TMP_Text personFakeSum;
    private List<HistorySlot> gameCards = new List<HistorySlot>();//���˳��������п���

    public int TotalScore = 0;


    public int TotalScoreReal;

    public void AddCard(PlayButton playButton)
    {
        //������������һ�Ŷ�Ӧ����
        HistorySlot newCard = Instantiate(Resources.Load<GameObject>("Prefab/HistoryCard"), transform).GetComponent<HistorySlot>();
        //newCard.Init(playButton.AppearNumber);
        newCard.Init(playButton.AppearNumber, playButton.cardSprite);

        gameCards.Add(newCard);
        //����˫��Sum
        GameManager.Instance.UpdateSum(playButton);
        //��������FakeSum
        CalculateTotalScore(playButton.AppearNumber);
        personFakeSum.text = TotalScore.ToString();


        Debug.Log("��һ����ֵΪ" + playButton.AppearNumber + "����ʵ��ֵΪ" + playButton.RealNumber + "�Ŀ��Ƽ������");

        Debug.Log("��ǰ�Ƴص���ʵ��ֵΪ" + CalculateTotalScoreReal(playButton.RealNumber));

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
