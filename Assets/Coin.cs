using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //�������Ž�����������Ϸ
   public void StartGame()
   {
        GameManager.Instance.GameBegin();
   }
}
