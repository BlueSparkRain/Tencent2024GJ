using System.Net.Security;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BasePlayButton : MonoBehaviour
{

   public ICanExcute canExcute;
   public ICanInit  cardInit;
}

public interface ICanExcute 
{
    public void TriggerMe();
}

public interface ICanInit 
{
    public void InitMe();
}
