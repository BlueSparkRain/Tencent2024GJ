using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoSingleton<ScoreCalculator>
{
    [Header("�������")]
    public List<Player> players;
    public int trueSum;
    public int falseSum;

    [Header("��ǰ���")]
    private Player currentPlayer;

    /// <summary>
    /// Ϊ������ҷֱ����һ������
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


