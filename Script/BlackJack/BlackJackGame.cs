using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ブラックジャックのゲーム部分の処理
/// </summary>
public class BlackJackGame : MonoBehaviour
{    
    private bool startChack;
    private bool gameChack;

    [Header("Card")]
    [SerializeField] GameObject backCard;
    [SerializeField] GameObject[] baseCard;
    [SerializeField] List<GameObject> useCardList;

    [Header("Player")]
    [HideInInspector] public int playerTotalNum;
    [HideInInspector] public int playerHitNum;
    [HideInInspector] public int playerSetCountNum;
    [HideInInspector] public int[] playerSetCardNum;
    [HideInInspector] public bool playerSetCard;
    [HideInInspector] public bool playerAceCard;
    [HideInInspector] public bool playerMoveCard;
    [HideInInspector] public bool playerHitCard;
    [HideInInspector] public bool playerCountCard;
    [HideInInspector] public bool playerStayCard;
    [HideInInspector] public bool playerBurst;
    [HideInInspector] public GameObject[] playerCardObj;

    [Header("AI")]
    [HideInInspector] public int aITotalNum;
    [HideInInspector] public int aIHitNum;
    [HideInInspector] public int aISetCountNum;
    [HideInInspector] public int[] aISetCardNum;
    [HideInInspector] public bool aISetCard;
    [HideInInspector] public bool aIFirstSetCard;
    [HideInInspector] public bool aIAceCard;
    [HideInInspector] public bool aIMoveCard;
    [HideInInspector] public bool aIHitCard;
    [HideInInspector] public bool aICountCard;
    [HideInInspector] public bool aIStayCard;
    [HideInInspector] public bool aIBurst;
    [HideInInspector] public GameObject[] aICardObj;

    [Header("Text")]
    [SerializeField] Text playerTotalCountText;
    [SerializeField] Text aITotalCountText;

    [Header("Button")]
    [SerializeField] Button drowButton;
    [SerializeField] Button stayButton;
    [SerializeField] Button pauseButton;

    [Header("Window")]
    [SerializeField] GameObject startWindow;
    [SerializeField] GameObject winWindow;
    [SerializeField] GameObject loseWindow;
    [SerializeField] GameObject drowWindow;

    [Header("OutCome")]
    private int outComeCount;
    private int gameCount;
    private bool winChack;
    private bool loseChack;
    [SerializeField] Image[] outComeCountImg;
    [SerializeField] Sprite successSprite;
    [SerializeField] Sprite failSprite;
    [SerializeField] Sprite drowSprite;

    [Header("GetComponent")]
    private SEManager seManager;

    void Start()
    {
        startWindow.SetActive(true);

        gameChack = true;
        // プレイヤーの配置状態を一旦trueにする
        playerSetCard = true;
        ResetCard();

        seManager = GetComponent<SEManager>();
    }

    void Update()
    {
        playerTotalCountText.text = playerTotalNum.ToString("00");
        aITotalCountText.text = aITotalNum.ToString("00");

        if (startChack && gameChack)
        {
            startWindow.SetActive(false);
            ProgressGame();
        }
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

        foreach (GameObject resetCard in baseCard)
        {
            useCardList.Add(resetCard);
        }
    }

    // 次のゲームに移行する為に前のゲームの情報を元に戻す処理
    private IEnumerator NextGame()
    {
        //ProgressGame();
        ResetCard();
        gameChack = false;

        // プレイヤーの情報を削除
        playerTotalNum = 0;
        playerSetCountNum = 0;
        playerStayCard = false;
        playerAceCard = false;
        playerBurst = false;
        for (int i = 0; i < playerSetCardNum.Length; i++)
        {
            playerCardObj[i] = null;
            playerSetCardNum[i] = 0;
        }

        // AI(ディーラー)の情報を削除
        aITotalNum = 0;
        aISetCountNum = 0;
        aIStayCard = false;
        aISetCard = false;
        aIAceCard = false;
        aIBurst = false;
        for (int i = 0; i < aISetCardNum.Length; i++)
        {
            aICardObj[i] = null;
            aISetCardNum[i] = 0;
        }

        yield return new WaitForSeconds(1.0f);

        // 待ったのちにゲームを開始する
        gameChack = true;
        StopCoroutine(NextGame());
    }

    // ゲームの進行を管理
    private void ProgressGame()
    {
        StartCoroutine(AISetCard());

        StartCoroutine(PlayerSetCard());
        StartCoroutine(PlayerHitCard());

        AIMove();
        GameChack();
    }

    // 勝敗判定の確認
    private void GameChack()
    {
        // 両者Stayを選択したら
        if (playerStayCard && aIStayCard)
        {
            playerStayCard = false;
            aIStayCard = false;
            // プレイヤーとAI(ディーラー)両者共にバーストしていた場合は引き分け
            if (playerBurst && aIBurst)
            {
                Debug.Log("Drow");
            }
            // プレイヤーがバーストしていた場合は負け
            else if (playerBurst)
            {
                loseChack = true;
                Debug.Log("Lose");
            }
            // AI(ディーラー)がバーストしていた場合は勝ち
            else if (aIBurst)
            {
                winChack = true;
                Debug.Log("Win");
            }
            // プレイヤーよりAI(ディーラー)の合計値の方が高かった場合は負け
            else if (playerTotalNum < aITotalNum)
            {
                loseChack = true;
                Debug.Log("Lose");
            }
            // プレイヤーよりAI(ディーラー)の合計値の方が低かった場合は勝ち
            else if (playerTotalNum > aITotalNum)
            {
                winChack = true;
                Debug.Log("Win");
            }
            // プレイヤーとAI(ディーラー)の合計値が同じだった場合は引き分け
            else if (playerTotalNum == aITotalNum)
            {
                Debug.Log("Drow");
            }

            // プレイヤーが勝っていた場合はマルを付けて、勝ち点を1増やす
            if (winChack)
            {
                winChack = false;
                outComeCountImg[gameCount].sprite = successSprite;
                gameCount++;
                outComeCount++;
            }
            // プレイヤーが負けていたらバツを付けて、勝ち点を1減らす
            else if (loseChack)
            {
                loseChack = false;
                outComeCountImg[gameCount].sprite = failSprite;
                gameCount++;
                outComeCount--;
            }
            // 引き分けだったら横線を付ける
            else if (!winChack && !loseChack)
            {
                outComeCountImg[gameCount].sprite = drowSprite;
                gameCount++;
            }

            // 5ラウンドが終わるまでゲームを続ける
            if (gameCount < 5)
            {
                StartCoroutine(NextGame());
            }
            // 5ラウンドが終わったときに勝ち点で勝敗を決定する
            else
            {
                pauseButton.interactable = false;
                if (outComeCount >= 1)
                {
                    winWindow.SetActive(true);
                    Debug.Log("PlayerWinner");
                }
                else if (outComeCount <= -1)
                {
                    loseWindow.SetActive(true);
                    Debug.Log("PlayerLoser");
                }
                else
                {
                    drowWindow.SetActive(true);
                    Debug.Log("Game Drow");
                }
            }
        }   
    }

    // プレイヤーにカードを配る処理
    private IEnumerator PlayerSetCard()
    {
        if (!playerSetCard)
        {
            playerSetCard = true;

            yield return new WaitForSeconds(0.75f);

            // 1枚目をセットする処理
            playerCardObj[playerSetCountNum] = useCardList[Random.Range(0, useCardList.Count)];
            playerCountCard = true;
            Instantiate(playerCardObj[playerSetCountNum], new Vector3(-2.0f, -1.0f, 0.0f), Quaternion.identity);
            

            // 選ばれたカードのリスト番号を取得
            var choiceNum1 = useCardList.IndexOf(playerCardObj[0]);
            //同じリスト番号をcardListから削除
            useCardList.RemoveAt(choiceNum1);

            yield return new WaitForSeconds(0.75f);

            // 2枚目をセットする処理
            playerCardObj[1] = useCardList[Random.Range(playerSetCountNum, useCardList.Count)];
            playerCountCard = true;
            Instantiate(playerCardObj[playerSetCountNum], new Vector3(-1.0f, -1.0f, 0.0f), Quaternion.identity);
            
            // 選ばれたカードのリスト番号を取得
            var choiceNum2 = useCardList.IndexOf(playerCardObj[1]);
            //同じリスト番号をcardListから削除
            useCardList.RemoveAt(choiceNum2);

            // 一定時間経った後にボタンを押せるようにする
            yield return new WaitForSeconds(0.75f);
            drowButton.interactable = true;
            stayButton.interactable = true;
        }
    }

    // プレイヤーがヒットした時の処理
    private IEnumerator PlayerHitCard()
    {
        if (playerHitCard)
        {
            playerHitCard = false;
            playerCardObj[playerSetCountNum] = useCardList[Random.Range(0, useCardList.Count)];
            
            Instantiate(playerCardObj[playerSetCountNum], new Vector3(playerSetCountNum - 2.0f, -1.0f, 0.0f), Quaternion.identity);
            playerCountCard = true;
            // 選ばれたカードのリスト番号を取得
            var choiceNum = useCardList.IndexOf(playerCardObj[playerSetCountNum]);
            //同じリスト番号をcardListから削除
            useCardList.RemoveAt(choiceNum);
            
            // 一定時間経った後にボタンを押せるようにする
            yield return new WaitForSeconds(1.0f);
            PlayerChack();
        }
    }

    // プレイヤーがヒットした後の状況確認処理
    private void PlayerChack()
    {
        // プレイヤーがStayを選択していた場合はチェックは不要
        if (!playerStayCard)
        {
            // プレイヤーの場にカードが5枚になった時点で強制Stay
            if (playerSetCountNum < 5)
            {
                // プレイヤーの合計値が22以上だったらバーストにし、AI(ディーラー)のターンに移行する
                if (playerTotalNum > 21)
                {
                    Debug.Log("Burst");
                    playerBurst = true;
                    playerStayCard = true;
                    aIHitCard = true;
                }
                // 21以下ならボタンを再度出来るようにする
                else
                {
                    drowButton.interactable = true;
                    stayButton.interactable = true;
                }
            }
            else
            {
                playerStayCard = true;
                aIHitCard = true;
            }
        }
    }

    // AI(ディーラー)にカードを配る処理
    private IEnumerator AISetCard()
    {
        if (!aISetCard)
        {
            aISetCard = true;

            // 1枚目をセットする処理
            aICardObj[aISetCountNum] = useCardList[Random.Range(0, useCardList.Count)];
            aICountCard = true;
            Instantiate(aICardObj[aISetCountNum], new Vector3(-2.0f, 3.0f, 1.0f), Quaternion.identity);
            
            // 選ばれたカードのリスト番号を取得
            var choiceNum1 = useCardList.IndexOf(aICardObj[0]);
            //同じリスト番号をcardListから削除
            useCardList.RemoveAt(choiceNum1);

            yield return new WaitForSeconds(0.75f);

            playerSetCard = false;
            // 2枚目を伏せてセットする処理
            backCard.SetActive(true);
        }
    }

    // AI(ディーラー)の行動
    private void AIMove()
    {
        // AI(ディーラー)の行動を開始
        if (playerStayCard && !aIStayCard)
        {
            backCard.SetActive(false);
            StartCoroutine(AIHit());
        }
    }

    // AI(ディーラー)がヒットした時の処理
    private IEnumerator AIHit()
    {
        if (aIHitCard)
        {
            aIHitCard = false;
            aICardObj[aISetCountNum] = useCardList[Random.Range(0, useCardList.Count)];

            Instantiate(aICardObj[aISetCountNum], new Vector3(aISetCountNum - 2.0f, 3.0f, 0.0f), Quaternion.identity);
            aICountCard = true;
            // 選ばれたカードのリスト番号を取得
            var choiceNum = useCardList.IndexOf(aICardObj[aISetCountNum]);
            //同じリスト番号をcardListから削除
            useCardList.RemoveAt(choiceNum);

            // 一定時間経った後にボタンを押せるようにする
            yield return new WaitForSeconds(1.0f);
            AIChack();
        }
    }

    // AI(ディーラー)がヒットした後の状況確認処理
    private void AIChack()
    {
        // AI(ディーラー)の場にカードが5枚になった時点で強制Stay
        if (aISetCountNum < 5)
        {
            if (aITotalNum > 21)
            {
                aIStayCard = true;
                aIBurst = true;
            }
            else if (aITotalNum >= 17)
            {
                aIStayCard = true;
            }
            else
            {
                aIHitCard = true;
            }
        }
        else
        {
            aIStayCard = true;
        }
    }

    // カード引くと選択した時の処理
    public void HIT()
    {
        Debug.Log("HIT");
        drowButton.interactable = false;
        stayButton.interactable = false;
        StartCoroutine(HITCoroutine());
    }

    private IEnumerator HITCoroutine()
    {
        yield return new WaitForSeconds(0.25f);
        playerHitCard = true;
    }

    // カードを引かないと選択した時の処理
    public void Stay()
    {
        Debug.Log("Stay");
        drowButton.interactable = false;
        stayButton.interactable = false;
        StartCoroutine(StayCoroutine());
    }

    private IEnumerator StayCoroutine()
    {
        yield return new WaitForSeconds(0.25f);
        playerStayCard = true;
        aIHitCard = true;
    }
}