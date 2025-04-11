using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HistorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public TMP_Text numberText;

    public Image image;

    private void Awake()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale += Vector3.one * 0.2f;
        transform.localPosition += new Vector3(0, 1, 0) * 30f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        transform.localScale -= Vector3.one * 0.2f;
        transform.localPosition -= new Vector3(0, 1, 0) * 30f;
    }

    //public void Init(int num)=>numberText.text=num.ToString();
    public void Init(int num, Sprite sprite)
    {
        // numberText.text = num.ToString();
        image.sprite = sprite;
    }

}
