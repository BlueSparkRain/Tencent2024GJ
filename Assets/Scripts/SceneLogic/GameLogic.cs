using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoSingleton<GameLogic>
{
    public SceneData  MenuScene;
  
    void Start()
    {
        InitFun();
        MusicManager.Instance.PlayBKMusic("BK1");
    }

    public void InitFun() 
    {
        StartCoroutine(SceneLoader.Instance.LoadNewScene(1));
    }
 
}
