using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;
public abstract class BasePanel : MonoBehaviour 
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public float transTime = 1;

    /// <summary>
    /// 面板进入动画缓动逻辑
    /// </summary>
    /// <returns></returns>
    /// <summary>
    /// 面板关闭调用
    /// </summary>
    public abstract IEnumerator ShowPanelTweenEffect();
    /// <summary>
    /// 面板显示调用
    /// </summary>
    public virtual void ShowPanel()
    {
        transform.SetAsLastSibling();
        Init();
    }
    /// <summary>
    /// 面板退出动画缓动逻辑
    /// </summary>
    public abstract IEnumerator HidePanelTweenEffect();
    /// <summary>
    /// 面板退出调用
    /// </summary>
    public virtual void HidePanel()
    {
    }

    protected virtual void Init() { }
    protected virtual void ClickButton(string buttonName)
    {
    }
    protected virtual void SliderValueChange(string sliderName, float value)
    {
    }
    protected virtual void ToggleValueChange(string sliderName, bool value)
    {
    }

 
}
