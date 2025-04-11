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
    /// �����붯�������߼�
    /// </summary>
    /// <returns></returns>
    /// <summary>
    /// ���رյ���
    /// </summary>
    public abstract IEnumerator ShowPanelTweenEffect();
    /// <summary>
    /// �����ʾ����
    /// </summary>
    public virtual void ShowPanel()
    {
        transform.SetAsLastSibling();
        Init();
    }
    /// <summary>
    /// ����˳����������߼�
    /// </summary>
    public abstract IEnumerator HidePanelTweenEffect();
    /// <summary>
    /// ����˳�����
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
