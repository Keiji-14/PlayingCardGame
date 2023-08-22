using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 神経衰弱のゲーム部分の処理
/// </summary>
public class ConcentrationGame : ConcentrationCard
{
    [Header("EasyMode")]
    public List<GameObject> easyCardList;
    public List<GameObject> setEasyCardList = new List<GameObject>();

    [Header("NormalMode")]
    public List<GameObject> normalCardList;
    public List<GameObject> setNormalCardList = new List<GameObject>();

    [Header("HardMode")]
    public List<GameObject> hardCardList;
    public List<GameObject> setHardCardList = new List<GameObject>();

    private int choiceNum;
    private int successCount;
    private GameObject randomCard;

    [Header("Window")]
    [SerializeField] GameObject startWindow;
    [SerializeField] GameObject lifeModeClearWindow;
    [SerializeField] GameObject timeAttackclearWindow;
    [SerializeField] GameObject gameOverWindow;

    [Header("Life")]
    [SerializeField] GameObject lifeWindow;
    [SerializeField] GameObject[] lifeHeart;
    public int life = 5;

    [Header("TimeAttack")]
    [SerializeField] GameObject timeCountWindow;
    [SerializeField] Text timeCountText;
    [SerializeField] Text clearCountText;
    public float secondCount;
    public float minuteCount;

    [Header("TimeRecode")]
    [SerializeField] Text timeRecodeText;
    private float easySecondRecode;
    private float easyMinuteRecode;
    private float normalSecondRecode;
    private float normalMinuteRecode;
    private float hardSecondRecode;
    private float hardMinuteRecode;

    [Header("Level")]
    public static int concentrationMode;
    public static int concentrationLevel;

    private bool startChack;
    private bool clearChack;
    [HideInInspector] public bool checkInterval;
    [HideInInspector] public bool openCard1;
    [HideInInspector] public bool openCard2;
    [HideInInspector] public int openCardNum1;
    [HideInInspector] public int openCardNum2;
    [HideInInspector] public GameObject openCardObj1;
    [HideInInspector] public GameObject openCardObj2;

    [Header("Button")]
    [SerializeField] Button pauseButton;

    [Header("GetComponent")]
    public ScenesManager scenesManager;

    void Start()
    {
        startWindow.SetActive(true);
        // ゲームモードの別にウィンドウを切り替え
        switch (concentrationMode)
        {
            case 0:
                lifeWindow.SetActive(true);
                break;
            case 1:
                timeCountWindow.SetActive(true);
                break;
        }
        // ゲーム難易度の設定
        switch (concentrationLevel)
        {
            case 0:
                EasyMode();
                break;
            case 1:
                NormalMode();
                break;
            case 2:
                HardMode();
                break;
        }
    }

    void Update()
    {
        if (startChack)
        {
            startWindow.SetActive(false);
            // ゲームモードの設定
            switch (concentrationMode)
            {
                case 0:
                    LifeMode();
                    break;
                case 1:
                    TimeAttackMode();
                    break;
            }
        }
    }

    // 画面をタップでゲームを開始する
    public void TapStart()
    {
        startChack = true;
    }

    // イージーモードのカード配置の処理
    private void EasyMode()
    {
        successCount = 6;
        for (int i = 0; i < 12; i++)
        {
            randomCard = easyCardList[Random.Range(0, easyCardList.Count)];
            // ランダムで選ばれたカードをsetEasyCardListに追加
            setEasyCardList.Add(randomCard);
            // 選ばれたカードのリスト番号を取得
            choiceNum = easyCardList.IndexOf(randomCard);
            //同じリスト番号をeasyCardListから削除
            easyCardList.RemoveAt(choiceNum);
        }

        // カードをそれぞれの場所に配置
        setEasyCardList[0].gameObject.transform.position = new Vector2(-1.8f, 2);
        setEasyCardList[1].gameObject.transform.position = new Vector2(-0.6f, 2);
        setEasyCardList[2].gameObject.transform.position = new Vector2(0.6f, 2);
        setEasyCardList[3].gameObject.transform.position = new Vector2(1.8f, 2);
        setEasyCardList[4].gameObject.transform.position = new Vector2(-1.8f, 0);
        setEasyCardList[5].gameObject.transform.position = new Vector2(-0.6f, 0);
        setEasyCardList[6].gameObject.transform.position = new Vector2(0.6f, 0);
        setEasyCardList[7].gameObject.transform.position = new Vector2(1.8f, 0);
        setEasyCardList[8].gameObject.transform.position = new Vector2(-1.8f, -2);
        setEasyCardList[9].gameObject.transform.position = new Vector2(-0.6f, -2);
        setEasyCardList[10].gameObject.transform.position = new Vector2(0.6f, -2);
        setEasyCardList[11].gameObject.transform.position = new Vector2(1.8f, -2);
    }

    // ノーマルモードのカード配置の処理
    private void NormalMode()
    {
        successCount = 8;
        for (int i = 0; i < 16; i++)
        {
            randomCard = normalCardList[Random.Range(0, normalCardList.Count)];
            // ランダムで選ばれたカードをsetEasyCardListに追加
            setNormalCardList.Add(randomCard);
            // 選ばれたカードのリスト番号を取得
            choiceNum = normalCardList.IndexOf(randomCard);
            //同じリスト番号をeasyCardListから削除
            normalCardList.RemoveAt(choiceNum);
        }

        // カードをそれぞれの場所に配置
        setNormalCardList[0].gameObject.transform.position = new Vector2(-1.8f, 2.4f);
        setNormalCardList[1].gameObject.transform.position = new Vector2(-0.6f, 2.4f);
        setNormalCardList[2].gameObject.transform.position = new Vector2(0.6f, 2.4f);
        setNormalCardList[3].gameObject.transform.position = new Vector2(1.8f, 2.4f);
        setNormalCardList[4].gameObject.transform.position = new Vector2(-1.8f, 0.8f);
        setNormalCardList[5].gameObject.transform.position = new Vector2(-0.6f, 0.8f);
        setNormalCardList[6].gameObject.transform.position = new Vector2(0.6f, 0.8f);
        setNormalCardList[7].gameObject.transform.position = new Vector2(1.8f, 0.8f);
        setNormalCardList[8].gameObject.transform.position = new Vector2(-1.8f, -0.8f);
        setNormalCardList[9].gameObject.transform.position = new Vector2(-0.6f, -0.8f);
        setNormalCardList[10].gameObject.transform.position = new Vector2(0.6f, -0.8f);
        setNormalCardList[11].gameObject.transform.position = new Vector2(1.8f, -0.8f);
        setNormalCardList[12].gameObject.transform.position = new Vector2(-1.8f, -2.4f);
        setNormalCardList[13].gameObject.transform.position = new Vector2(-0.6f, -2.4f);
        setNormalCardList[14].gameObject.transform.position = new Vector2(0.6f, -2.4f);
        setNormalCardList[15].gameObject.transform.position = new Vector2(1.8f, -2.4f);
    }

    // ノーマルモードのカード配置の処理
    private void HardMode()
    {
        successCount = 10;
        for (int i = 0; i < 20; i++)
        {
            randomCard = hardCardList[Random.Range(0, hardCardList.Count)];
            // ランダムで選ばれたカードをsetEasyCardListに追加
            setHardCardList.Add(randomCard);
            // 選ばれたカードのリスト番号を取得
            choiceNum = hardCardList.IndexOf(randomCard);
            //同じリスト番号をeasyCardListから削除
            hardCardList.RemoveAt(choiceNum);
        }

        // カードをそれぞれの場所に配置
        setHardCardList[0].gameObject.transform.position = new Vector2(-2.0f, 2.4f);
        setHardCardList[1].gameObject.transform.position = new Vector2(-1.0f, 2.4f);
        setHardCardList[2].gameObject.transform.position = new Vector2(0.0f, 2.4f);
        setHardCardList[3].gameObject.transform.position = new Vector2(1.0f, 2.4f);
        setHardCardList[4].gameObject.transform.position = new Vector2(2.0f, 2.4f);
        setHardCardList[5].gameObject.transform.position = new Vector2(-2.0f, 0.8f);
        setHardCardList[6].gameObject.transform.position = new Vector2(-1.0f, 0.8f);
        setHardCardList[7].gameObject.transform.position = new Vector2(0.0f, 0.8f);
        setHardCardList[8].gameObject.transform.position = new Vector2(1.0f, 0.8f);
        setHardCardList[9].gameObject.transform.position = new Vector2(2.0f, 0.8f);
        setHardCardList[10].gameObject.transform.position = new Vector2(-2.0f, -0.8f);
        setHardCardList[11].gameObject.transform.position = new Vector2(-1.0f, -0.8f);
        setHardCardList[12].gameObject.transform.position = new Vector2(0.0f, -0.8f);
        setHardCardList[13].gameObject.transform.position = new Vector2(1.0f, -0.8f);
        setHardCardList[14].gameObject.transform.position = new Vector2(2.0f, -0.8f);
        setHardCardList[15].gameObject.transform.position = new Vector2(-2.0f, -2.4f);
        setHardCardList[16].gameObject.transform.position = new Vector2(-1.0f, -2.4f);
        setHardCardList[17].gameObject.transform.position = new Vector2(0.0f, -2.4f);
        setHardCardList[18].gameObject.transform.position = new Vector2(1.0f, -2.4f);
        setHardCardList[19].gameObject.transform.position = new Vector2(2.0f, -2.4f);
    }

    // カードが揃っているかどうか確認する処理
    public IEnumerator CardCheck()
    {
        // カードの数字が揃っていたら、揃ってるカードを削除する
        if (openCardNum1 == openCardNum2)
        {
            Debug.Log("揃っている");

            yield return new WaitForSeconds(1.0f);

            // 選択した2枚のカードを削除する
            Destroy(openCardObj1);
            Destroy(openCardObj2);

            // 選択したカードの情報を消す
            openCardNum1 = 0;
            openCardNum2 = 0;
            openCard1 = false;
            openCard2 = false;

            ClearChack();
        }
        // カードの数字が揃っていなかったら、カードを裏返する
        else
        {
            Debug.Log("揃っていない");
            // 選択した2枚のカードのコンポーネントを取得
            ConcentrationCard closeCardObj1 = openCardObj1.GetComponent<ConcentrationCard>();
            ConcentrationCard closeCardObj2 = openCardObj2.GetComponent<ConcentrationCard>();

            yield return new WaitForSeconds(1.0f);

            // ライフモードだった場合はライフを減らす
            if (concentrationMode == 0)
            {
                life -= 1;
            }

            StartCoroutine(closeCardObj1.CloseCard());
            StartCoroutine(closeCardObj2.CloseCard());

            // 選択したカードの情報を消す
            openCardNum1 = 0;
            openCardNum2 = 0;
            openCard1 = false;
            openCard2 = false;
        }
    }

    // ライフモードの処理
    private void LifeMode()
    {
        switch (life)
        {
            case 0:
                Debug.Log("ゲームオーバー");
                Invoke("GameOver", 1.0f);
                Destroy(lifeHeart[0]);
                break;
            case 1:
                Destroy(lifeHeart[1]);
                break;
            case 2:
                Destroy(lifeHeart[2]);
                break;
            case 3:
                Destroy(lifeHeart[3]);
                break;
            case 4:
                Destroy(lifeHeart[4]);
                break;
            case 5:
                break;
        }
    }

    // タイムアタックモードの処理
    private void TimeAttackMode()
    {
        // 全てのカードを揃えるまで計測する
        if (!clearChack)
        {
            secondCount += Time.deltaTime;
        }
        else
        {
            timeCountWindow.SetActive(false);
            ClearTime();
        }
        if (secondCount >= 60.0f)
        {
            minuteCount++;
            secondCount = secondCount - 60;
           
        }
        timeCountText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
    }

    // タイムアタックのレコード処理
    private void ClearTime()
    {
        clearCountText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        switch (concentrationLevel)
        {
            case 0:
                EasyTimeRecode();
                break;
            case 1:
                NormalTimeRecode();
                break;
            case 2:
                HardTimeRecode();
                break;
        }
    }

    // イージーモードのレコード処理
    private void EasyTimeRecode()
    {
        easyMinuteRecode = PlayerPrefs.GetFloat("SaveEasyMinute", 0);
        easySecondRecode = PlayerPrefs.GetFloat("SaveEasySecond", 0);

        // 初回の記録だった場合は新記録扱いにする
        if (easyMinuteRecode == 0 && easySecondRecode == 0)
        {
            PlayerPrefs.SetFloat("SaveEasyMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveEasySecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        // 新記録が出たら記録更新処理
        else if (easyMinuteRecode >= minuteCount && easySecondRecode > secondCount)
        {
            PlayerPrefs.SetFloat("SaveEasyMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveEasySecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        else
        {
            timeRecodeText.text = easyMinuteRecode.ToString("00") + " : " + easySecondRecode.ToString("00");
        }
    }

    // ノーマルモードのレコード処理
    private void NormalTimeRecode()
    {
        normalMinuteRecode = PlayerPrefs.GetFloat("SaveNormalMinute", 0);
        normalSecondRecode = PlayerPrefs.GetFloat("SaveNormalSecond", 0);

        // 初回の記録だった場合は新記録扱いにする
        if (normalMinuteRecode == 0 && normalSecondRecode == 0)
        {
            PlayerPrefs.SetFloat("SaveNormalMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveNormalSecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        // 新記録が出たら記録更新処理
        else if (normalMinuteRecode >= minuteCount && normalSecondRecode > secondCount)
        {
            PlayerPrefs.SetFloat("SaveNormalMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveNormalSecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        else
        {
            timeRecodeText.text = normalMinuteRecode.ToString("00") + " : " + normalSecondRecode.ToString("00");
        }
    }

    // ハードモードのレコード処理
    private void HardTimeRecode()
    {
        hardMinuteRecode = PlayerPrefs.GetFloat("SaveHardMinute", 0);
        hardSecondRecode = PlayerPrefs.GetFloat("SaveHardSecond", 0);

        // 初回の記録だった場合は新記録扱いにする
        if (hardMinuteRecode == 0 && hardSecondRecode == 0)
        {
            PlayerPrefs.SetFloat("SaveHardMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveHardSecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        // 新記録が出たら記録更新処理
        else if (hardMinuteRecode >= minuteCount && hardSecondRecode > secondCount)
        {
            PlayerPrefs.SetFloat("SaveHardMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveHardSecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        else
        {
            timeRecodeText.text = hardMinuteRecode.ToString("00") + " : " + hardSecondRecode.ToString("00");
        }
    }

    // クリアしたかどうかの確認する処理
    private void ClearChack()
    {
        // 正解するたびにカウントを1減らす
        successCount -= 1;
        // カウントが0になればゲームクリアになる
        if (successCount == 0)
        {
            // ゲームモード別にクリアウィンドウを表示
            switch (concentrationMode)
            {
                case 0:
                    lifeModeClearWindow.SetActive(true);
                    pauseButton.interactable = false;
                    break;
                case 1:
                    timeAttackclearWindow.SetActive(true);
                    pauseButton.interactable = false;
                    clearChack = true;
                    break;
            }
        }
    }

    // ゲームオーバー画面を表示
    private void GameOver()
    {
        gameOverWindow.SetActive(true);
        pauseButton.interactable = false;
    }
}
