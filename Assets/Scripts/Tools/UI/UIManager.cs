using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public enum E_UILayer
{
    Bottom,
    Middle,
    Top,
    System,
}

/// <summary>
/// ��������UI���
/// ע�⣺Ԥ����������������豣��һ��
/// </summary>
public class UIManager : BaseSingletonManager<UIManager>
{

    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();
    public void ShowPanel<T>(UnityAction<T> callBack, E_UILayer layer = E_UILayer.Middle, bool isSync = false) where T : BasePanel
    {
        //��ȡ�������Ԥ����������������豣��һ��
        string panelName = typeof(T).Name;
        BasePanel panel;
        //�������
        if (panelDic.ContainsKey(panelName))
        {
            panel = panelDic[panelName];
            if (!panel.gameObject.activeSelf)
                panel.gameObject.SetActive(true);

            panel.ShowPanel();
            MonoManager.Instance.StartCoroutine(panel.ShowPanelTweenEffect());
            Debug.Log("����Ѵ���:" + panelName);
            callBack?.Invoke(panelDic[panelName] as T);
            return;
        }
        //��������壬�ȼ�����Դ
        GameObject panelobj = Resources.Load<GameObject>("Prefab/UIPanel/" + panelName);
      
   
        //�����Ԥ�Ƽ���������Ӧ��layer�£�������ԭ�������Ŵ�С
        panelobj = GameObject.Instantiate(panelobj);
        panelobj.transform.SetAsFirstSibling();

        //��ȡ��ӦUI�������
        panel = panelobj.GetComponent<BasePanel>();
        panel.ShowPanel();
        MonoManager.Instance.StartCoroutine(panel.ShowPanelTweenEffect());

        Debug.Log("����壡" + panelName);
        callBack?.Invoke(panel as T);
        //�洢panel
        if (!panelDic.ContainsKey(panelName))
        {
            panelDic.Add(panelName, panel);
        }
    }

    public void HidePanel<T>(bool isDestroy = false)
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            if (isDestroy)
            {
                //ѡ������ʱ�Ż��Ƴ��ֵ�
                GameObject.Destroy(panelDic[panelName].gameObject);
                panelDic.Remove(panelName);
            }
            else //��ʧ��
                MonoManager.Instance.StartCoroutine(PanelHideEnd(panelDic[panelName]));
        }
    }
    IEnumerator PanelHideEnd(BasePanel panel)
    {
        panel.HidePanel();
        yield return panel.HidePanelTweenEffect();
        panel.gameObject.SetActive(false);

    }





}
