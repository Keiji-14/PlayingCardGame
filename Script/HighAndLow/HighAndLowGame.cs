using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ハイアンドローのゲーム部分の処理
/// </summary>
public class HighAndLowGame : HighAndLowCard
{
    private int nextHeightCard;
    private int selectNextHeightCard;
    private int successCount;
    private int recodeCount;
    private bool startChack;
    private bool selectChack;
    private bool nextChack;

    [HideInInspector] public int openCardNum1;
    [HideInInspector] public int openCardNum2;
    [HideInInspector] public bool openCard1;
    [HideInInspector] public bool openCard2;
    [HideInInspector] public GameObject cardObj1;
    [HideInInspector] public GameObject cardObj2;
    
    [SerializeField] GameObject backCardObj;
    [SerializeField] GameObject[] baseCard;
    [SerializeField] List<GameObject> useCardList;

    [Header("Text")]
    [SerializeField] Text successCountText;
    [SerializeField] Text resultCountText;
    [SerializeField] Text recodeCountText;

    [Header("Button")]
    [SerializeField] Button highButton;
    [SerializeField] Button lowButton;
    [SerializeField] Button pauseButton;

    [Header("Window")]
    [SerializeField] GameObject startWindow;
    [SerializeField] GameObject successWindow;
    [SerializeField] GameObject failWindow;
    [SerializeField] GameObject gameOverWindow;

    enum Height
    {
        lowCard = -1,
        drowCard,
        highCrad,
    }

    void Start()
    {
        startWindow.SetActive(true);
        recodeCount = PlayerPrefs.GetInt("SaveHALCount",0);

        ResetCard();
    }

    void Update()
    {
        // ゲームを開始する処理
        if (startChack)
        {
            startWindow.SetActive(false);

            // 一枚目がめくられる処理
            StartCoroutine(SetCard1());
        }

        // 二枚目がめくられる処理
        if (selectChack)
        {
            SetCard2();
        }

        if (openCard1 && openCard2)
        {
            StartCoroutine(ChackHighAndLow());
        }

        successCountText.text = successCount.ToString("00");
    }

    // 画面をタップでゲームを開始する
    public void TapStart()
    {
        startChack = true;
    }

    // 次のゲームの為にカード情報を戻す処理
    private void ResetCard()
    {
        // 使用したカードを削除する
        GameObject[] usedCards = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject destroyCard in usedCards)
        {
            Destroy(destroyCard);
        }

        // useCardListの要素を削除してからbaseCardを要素に入れる
        useCardList.RemoveRange(0, useCardList.Count);

        foreach(GameObject resetCard in baseCard)
        {
            useCardList.Add(resetCard);
        }
    }

    // 次のゲームに移行する為に前のゲームの情報を元に戻す処理
    private void NextGame()
    {
        StopCoroutine(ChackHighAndLow());

        if (!nextChack)
        {
            backCardObj.SetActive(true);

            ResetCard();

            openCard1 = false;
            openCard2 = false;
            nextChack = true;
            
            // プレイヤーが選択したものが正解だったら加点する
            if (nextHeightCard == selectNextHeightCard)
            {
                successCount++;
            }
        }
    }

    // 1枚目のカードを展開する処理
    private IEnumerator SetCard1()
    {
        if (!openCard1)
        {
            openCard1 = true;
            cardObj1 = useCardList[Random.Range(0, useCardList.Count)];

            Instantiate(cardObj1, new Vector2(0, 2.0f), Quaternion.identity);
            // 選ばれたカードのリスト番号を取得
            var choiceNum = useCardList.IndexOf(cardObj1);
            //同じリスト番号をcardListから削除
            useCardList.RemoveAt(choiceNum);

            // 一定時間経った後にボタンを押せるようにする
            yield return new WaitForSeconds(2.0f);
            highButton.interactable = true;
            lowButton.interactable = true;
        }
    }

    // 2枚目のカードを展開する処理
    private void SetCard2()
    {
        backCardObj.SetActive(false);
        selectChack = false;
        openCard2 = true;
        cardObj2 = useCardList[Random.Range(0, useCardList.Count)];

        Instantiate(cardObj2, new Vector2(0, 2.0f), Quaternion.identity);
        // 選ばれたカードのリスト番号を取得
        var choiceNum = useCardList.IndexOf(cardObj2);
        //同じリスト番号をcardListから削除
        useCardList.RemoveAt(choiceNum);
    }

    // 1枚目に引いたカードの数字より次に引くカードの数字が高いか低いか
    private IEnumerator ChackHighAndLow()
    {
        nextChack = false;

        yield return new WaitForSeconds(1.0f);

        // 1枚目と2枚目のカードを比較してその結果を代入
        if (openCardNum1 < openCardNum2)
        {
            nextHeightCard = (int)Height.highCrad;
        }
        if (openCardNum1 > openCardNum2)
        {
            nextHeightCard = (int)Height.lowCard;
        }
        if (openCardNum1 == openCardNum2)
        {
            nextHeightCard = (int)Height.drowCard;
        }

        yield return new WaitForSeconds(1.0f);

        // 結果が自分の選択した結果と合っているか比較
        if (nextHeightCard == selectNextHeightCard)
        {
            NextGame();
        }
        else if (nextHeightCard == 0)
        {
            yield return new WaitForSeconds(1.0f);
            NextGame();
        }
        else
        {
            yield return new WaitForSeconds(1.0f);
            GameOver();
        }
    }

    // 高い方を選択
    public void HighButton()
    {
        selectChack = true;
        selectNextHeightCard = (int)Height.highCrad;
        highButton.interactable = false;
        lowButton.interactable = false;
    }

    // 低い方を選択
    public void LowButton()
    {
        selectChack = true;
        selectNextHeightCard = (int)Height.lowCard;
        highButton.interactable = false;
        lowButton.interactable = false;
    }

    // ゲームオーバー画面を表示
    private void GameOver()
    {
        gameOverWindow.SetActive(true);
        pauseButton.interactable = false;

        // 記録が更新したかどうか確認
        if (recodeCount < successCount)
        {
            recodeCount = successCount;
            PlayerPrefs.SetInt("SaveHALCount", recodeCount);
        }
        
        recodeCountText.text = "：" + recodeCount.ToString("00");
        resultCountText.text = "：" + successCount.ToString("00");
    }
}