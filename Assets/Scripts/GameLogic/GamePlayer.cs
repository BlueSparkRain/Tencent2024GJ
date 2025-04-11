using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer
{
    private GameCardPool pool; //������
    private GameHand hand;     //������

    /// <summary>
    /// ����
    /// </summary>
    public  int tractIndex;


    private int fakeNumber;
    public int FakeNumber
    {
        get { return fakeNumber; }
        set { fakeNumber = value; }
    }

    public GamePlayer(GameCardPool pool, GameHand hand, int fakeNumber ,int trackIndex)
    {
        this.pool = pool;
        FakeNumber = fakeNumber;
        this.hand = hand;
        hand.InitPlayButton(this);
        hand.SetFakeCard(fakeNumber);
        this.tractIndex = trackIndex;
    }

    public void SwapTrackIndex()=>tractIndex*=(-1);

    public void PlaySomeCard(PlayButton handCard)
    {
        pool.AddCard(handCard);
        GameManager.Instance.ChangeTurn();
    }

    public IEnumerator EnterTurn()
    {
        yield return  hand.EnterTurn();
    }

    public  IEnumerator ExitTurn()
    {
        yield return  hand.ExitTurn();
    }
}

public enum EMessageTrackType 
{
 ������,������
}
