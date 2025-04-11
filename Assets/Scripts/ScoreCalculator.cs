using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoSingleton<ScoreCalculator>
{
    [Header("所有玩家")]
    public List<Player> players;
    public int trueSum;
    public int falseSum;

    [Header("当前玩家")]
    private Player currentPlayer;

    /// <summary>
    /// 为所有玩家分别随机一个数字
    /// </summary>
   public void BeginNewRand() 
   {
    
   
   }


    public void NextPlayer() 
    {
    
    }

    private void Update()
    {
        
    }
}

public enum E_Player 
{
  Player1, Player2, Player3, Player4, Player5,
}


