using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    #region players
    [Header("��Ҷ���")]
    public Animator coinAnim;
    public Animator clothAnim;


    private GamePlayer playerWhite;
    [SerializeField] private GameCardPool playerWhitePool;
    [SerializeField] private GameHand playerWhiteHand;

    private GamePlayer playerBlack;
    [SerializeField] private GameCardPool playerBlackPool;
    [SerializeField] private GameHand playerBlackHand;

    private List<GamePlayer> gamePlayers = new List<GamePlayer>();
    private int currPlayerIndex;
    public int CurrPlayerIndex
    {
        get { return currPlayerIndex; }
        set
        {
            if (value >= gamePlayers.Count)
            {
                value = 0;
            }
            currPlayerIndex = value;
        }
    }
    [Header("�ٺ�")]
    public int FakeSum;
    public TMP_Text FakeSumText;
    [Header("���")]
    public int RealSum;
    public TMP_Text RealSumText;

    //�����ܺʹ���Ŀ��ֵ
    bool FakeBeyondRealSum=false;

    string currentPlayerName;
    //public CanvasGroup WholeCanvaGroup;

 
    #endregion

    #region number

    public int goalNumber;
    [Header("ϵͳ���Ŀ��Sum")]
    public TMP_Text goalText;
    [SerializeField] private int goalNumberMax;
    [SerializeField] private int goalNumberMin;

    public int TotalNumber
    {
        get { return playerWhitePool.TotalScore + playerBlackPool.TotalScore; }
    }
    public int TotalNumberReal
    {
        get { return playerWhitePool.TotalScoreReal + playerBlackPool.TotalScoreReal; }
    }

    [Header("С������")]
    bool startWhite;
    [Header("˫�����ƶ�Ӧ��������")]
    public  string whiteFakeMsName, blackFakeMsName;

    [Header("С�׼������Ѱ�ť")]
    public Button RePlayFakeCardMessage_White;
    [Header("С�ڼ������Ѱ�ť")]
    public Button RePlayFakeCardMessage_Black;

    #endregion


    protected override void InitPlayer()
    {
        playerBlack = new GamePlayer(playerBlackPool, playerBlackHand, Random.Range(1, 5), -1); //С��Ĭ��������
        playerWhite = new GamePlayer(playerWhitePool, playerWhiteHand, Random.Range(1, 5), 1);//С��Ĭ��������

        int WhiteFakeIndex = playerWhite.FakeNumber;
        int BlackFakeIndex = playerBlack.FakeNumber;

        whiteFakeMsName =  WhiteFakeIndex.ToString();
        blackFakeMsName =  BlackFakeIndex.ToString();
      


        gamePlayers.Add(playerWhite);
        gamePlayers.Add(playerBlack);
    }

    public void SwapAudioTrack()
    {
        playerBlack.SwapTrackIndex();
        playerWhite.SwapTrackIndex();
    }

    private void Start()
    {
        InitPlayer();
        RePlayFakeCardMessage_Black.onClick.AddListener(OnClickBlackRePlayFakeMSButton);
        RePlayFakeCardMessage_White.onClick.AddListener(OnClickWhiteRePlayFakeMSButton);
        UIManager.Instance.ShowPanel<ComicPanel>(null);
    }

    void OnClickBlackRePlayFakeMSButton() => MusicManager.Instance.SayTrackMessage(playerBlack.tractIndex, whiteFakeMsName);
    void OnClickWhiteRePlayFakeMSButton() => MusicManager.Instance.SayTrackMessage(playerWhite.tractIndex, blackFakeMsName);

   

    void Update()
    {
      

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (hasAppear)
            {
                hasAppear = false;
                UIManager.Instance.ShowPanel<SettingPanel>(null);
            }
            else
            {
                UIManager.Instance.HidePanel<SettingPanel>();
                hasAppear = true;
            }
        }

        //�����������������ܺ��״δ��ڵ���Ŀ���ܺ�ʱ��������Ч
        if (!FakeBeyondRealSum &&  FakeSum!=0 &&FakeSum >= goalNumber) 
        {
            FakeBeyondRealSum = true;
            MusicManager.Instance.PlaySound("FakeSumBeyondRealSum");
        }
    }

  

    /// <summary>
    /// ����Ļ����������������
    /// </summary>
    /// <returns></returns>
    public IEnumerator SelectFirstHand()
    {
        yield return new WaitForSeconds(1);
        //Ļ������
        clothAnim.SetTrigger("Open");
        yield return new WaitForSeconds(0.5f);
        //Ӳ�ҳ���
        coinAnim.SetTrigger("Appear");
        yield return new WaitForSeconds(1);
        startWhite = (Random.value > 0.5f);

        if (startWhite)
            coinAnim.SetTrigger("WhiteFirst");
        else
            coinAnim.SetTrigger("BlackFirst");

        yield return new WaitForSeconds(0.3f);
        MusicManager.Instance.PlaySound("CoinBegin");
        yield return new WaitForSeconds(1.5f);
        MusicManager.Instance.PlaySound("CoinEnd");
        yield return new WaitForSeconds(1.5f);
        //����Ӳ�����µ���Ч
        coinAnim.SetTrigger("DisAppear");
    }

    public void FirstHand()
    {
        StartCoroutine(SelectFirstHand());
    }

    //Ӳ�����£���ʼ��Ϸ
    public void GameBegin()
    {
        MusicManager.Instance.PlayBKMusic("BK2");
        if (startWhite)
        {
            currentPlayerName = "White";
            CurrPlayerIndex = 1;
            StartCoroutine(gamePlayers[CurrPlayerIndex].EnterTurn());
        }
        else
        {
            currentPlayerName = "Black";
            CurrPlayerIndex = 0;
            StartCoroutine(gamePlayers[CurrPlayerIndex].EnterTurn());
        }

        UIManager.Instance.ShowPanel<MessagePanel>(panel => StartCoroutine(panel.ShowMessage("Now It Is" + currentPlayerName + "Turn��")));
       // StartCoroutine(FirstRand());

        goalNumber = Random.Range(goalNumberMin, goalNumberMax + 1);
        goalText.text = goalNumber.ToString();
        Debug.Log("Ŀ�������" + goalNumber.ToString());

      
       MusicManager.Instance.SayTrackMessage(playerBlack.tractIndex, whiteFakeMsName);
       MusicManager.Instance.SayTrackMessage(playerWhite.tractIndex, blackFakeMsName);
     
    }

    IEnumerator FirstRand() 
    {
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowPanel<MessagePanel>(panel => StartCoroutine(panel.ShowMessage("Now It Is" + currentPlayerName + "Turn��")));
    }

    public void ChangeTurn()
    {
        if (TotalNumberReal < goalNumber)
        {
          //  Debug.Log("��Ϸ����");
          //  Debug.Log("����ֵΪ" + TotalNumber + "����ʵ����ֵΪ" + TotalNumberReal);
        }
        else if (TotalNumberReal == goalNumber)
        {

           // Debug.Log("��ֵ���");
            currentPlayerName = currPlayerIndex == 0 ? "Black" : "White";
            MusicManager.Instance.PlaySound("PerfectSum");
            GetWinner();
        }
        else
        {
           // Debug.Log("��ֵ����");
            currentPlayerName = currPlayerIndex == 1 ? "White" : "Black";
            MusicManager.Instance.PlaySound("BeyondSum");
            GetWinner();
        }

        StartCoroutine(gamePlayers[CurrPlayerIndex].ExitTurn());

        if (CurrPlayerIndex + 1 < gamePlayers.Count)
            CurrPlayerIndex++;
        else
            currPlayerIndex = 0;
        currentPlayerName = currPlayerIndex == 1 ? "White" : "Black";

        UIManager.Instance.ShowPanel<MessagePanel>(panel => StartCoroutine(panel.ShowMessage("Now It Is" + currentPlayerName + "Turn��")));
        StartCoroutine(NextPlayer());
    }

    void GetWinner()
    {
        UIManager.Instance.ShowPanel<WinPanel>(panel => panel.ShowWinner(currentPlayerName));
    }

    IEnumerator NextPlayer()
    {
        yield return new WaitForSeconds(2f);
        yield return gamePlayers[CurrPlayerIndex].EnterTurn();
    }


    /// <summary>
    /// ������ʵ���ܺ�
    /// </summary>
    private void UpdateRealSum(PlayButton newCard)
    {
        RealSum += newCard.RealNumber;
        RealSumText.text = RealSum.ToString();
    }

    public void NewGame()
    {
     
    }

    /// <summary>
    /// ���¼ٵ��ܺ�
    /// </summary>
    private void UpdateFakeSum(PlayButton newCard)
    {
        FakeSum += newCard.AppearNumber;
        FakeSumText.text = FakeSum.ToString();
    }

    public void UpdateSum(PlayButton newCard)
    {
        UpdateFakeSum(newCard);
        UpdateRealSum(newCard);
    }

    public void HandCard(PlayButton playbutton)
    {

    }


    bool hasAppear = false;



}
