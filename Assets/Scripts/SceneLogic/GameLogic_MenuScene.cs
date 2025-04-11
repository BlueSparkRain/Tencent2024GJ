using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic_MenuScene : MonoBehaviour
{
   
    void Start()
    {
        UIManager.Instance.ShowPanel<MenuPanel>(null);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            UIManager.Instance.ShowPanel<MenuPanel>(null);
        }
        if (Input.GetKey(KeyCode.E))
        {
            UIManager.Instance.HidePanel<MenuPanel>();
        }
    }
}
