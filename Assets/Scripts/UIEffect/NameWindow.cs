using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class NameWindow : MonoBehaviour, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler
{
    Animator anim;
    GameObject nameWindow;
    LayerMouseOffset layerMouseOffset;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        nameWindow = transform.GetChild(0).gameObject;
        layerMouseOffset = GetComponent<LayerMouseOffset>();

    }
    public void OnDrag(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition += eventData.delta * 0.8f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetTrigger("open");
        // StartCoroutine(HelperTool.MakeLerp(transform.localScale, Vector3.one*0.2f, 0.1f, val => transform.localScale = val));
        transform.localScale += Vector3.one * 0.2f;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetTrigger("close");
        transform.localScale -= Vector3.one * 0.2f;
        //StartCoroutine(HelperTool.MakeLerp(transform.localScale, -Vector3.one * 0.2f, 0.1f, val => transform.localScale = val));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        layerMouseOffset.SetPosition(transform.position);
    }
}
