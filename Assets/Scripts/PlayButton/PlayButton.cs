using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayButton : BasePlayButton, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public int RealNumber;
    public int AppearNumber;
    private GamePlayer player;
    public Sprite cardSprite;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickHnadCardButton);
        RealNumber = AppearNumber;
        cardSprite=transform.GetChild(1).GetComponent<Image>().sprite;
    }

    public void Init(GamePlayer player) 
    {
        this.player = player;
    }

    void OnClickHnadCardButton() 
    {
        player.PlaySomeCard(this);
        MusicManager.Instance.PlaySound("CardHandOut");

    }

  
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale += Vector3.one * 0.2f;
        MusicManager.Instance.PlaySound("CardPointerIn");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale -= Vector3.one * 0.2f;
    }

    public void SetFake()
    {
        RealNumber = 0;
    }

}
