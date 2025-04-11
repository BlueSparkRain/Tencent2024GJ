using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //动画播放结束，开启游戏
   public void StartGame()
   {
        GameManager.Instance.GameBegin();
   }
}
