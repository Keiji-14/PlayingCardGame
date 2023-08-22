using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブラックジャックのカード部分の処理
/// </summary>
public class BlackJackCard : Card
{
    private bool usedCard;
    [SerializeField] GameObject gameEvantObj;
    [SerializeField] GameObject sEManagerObj;

    [Header("GetComponent")]
    BlackJackGame blackJackGame;
    SEManager sEManager;

    void Start()
    {
        gameEvantObj = GameObject.Find("GameEvent");
        sEManagerObj = GameObject.Find("SEManager");

        // Componentを取得する
        blackJackGame = gameEvantObj.GetComponent<BlackJackGame>();
        sEManager = sEManagerObj.GetComponent<SEManager>();

        // カードを180度回転させる（表向きになった場合に反転を防止）
        transform.Rotate(0, 180, 0);
        setBJCardNumber();
    }

    void Update()
    {
        // カードが生成されたら直ぐにカードを表向きにする
        StartCoroutine(OpenCard());

        // プレイヤーのカードが引いた時に動作させる
        if (blackJackGame.playerCountCard && !usedCard)
        { 
            // usedCardで既出のカード処理を再度発生させないようにする
            usedCard = true;
            blackJackGame.playerCountCard = false;
            blackJackGame.playerSetCardNum[blackJackGame.playerSetCountNum] = cardNumber;
            blackJackGame.playerSetCountNum++;
            
            // プレイヤーの合計値にカードの数字を足す
            blackJackGame.playerTotalNum += cardNumber;
        }

        // ディーラー(AI)のカードが引いた時に動作させる
        if (blackJackGame.aICountCard && !usedCard)
        {
            // usedCardで既出のカード処理を再度発生させないようにする
            usedCard = true;
            blackJackGame.aICountCard = false;
            blackJackGame.aISetCardNum[blackJackGame.aISetCountNum] = cardNumber;
            blackJackGame.aISetCountNum++;

            // ディーラー(AI)の合計値にカードの数字を足す
            blackJackGame.aITotalNum += cardNumber;
        }

        PlayerTurn();
        AITurn();
    }

    // プレイヤーのターン時に動作する
    private void PlayerTurn()
    {
        // プレイヤーがSTAYを選択していない場合
        if (!blackJackGame.playerStayCard)
        {
            AceCardChack();
        }
    }

    // ディーラーのターン時に動作する
    private void AITurn()
    {
        // プレイヤーがSTAYを選択していた場合
        if (blackJackGame.playerStayCard)
        {
            AceCardChack();
        }
    }

    // カードの表を表示する
    public IEnumerator OpenCard()
    {
        if (!front)
        {
            front = true;
            sEManager.audioSource.PlayOneShot(sEManager.audioClips[(int)SEManager.SE_Type.turnSE]);
            for (int turn = 0; turn < 180; turn++)
            {
                // 半分まで裏返ったら画像を表に切り替え
                if (turn > 90)
                {
                    spriteRenderer.sprite = frontSprite;
                }
                transform.Rotate(0, 1, 0);
                yield return new WaitForSeconds(0.001f);
            }
        }
    }

    // カードにブラックジャックの点数を設定
    private void setBJCardNumber()
    {
        switch (cardId)
        {
            case (int)CardId.spade1:
            case (int)CardId.heart1:
            case (int)CardId.diamond1:
            case (int)CardId.club1:
                AceCard();
                break;
            case (int)CardId.spade2:
            case (int)CardId.heart2:
            case (int)CardId.diamond2:
            case (int)CardId.club2:
                cardNumber = 2;
                break;
            case (int)CardId.spade3:
            case (int)CardId.heart3:
            case (int)CardId.diamond3:
            case (int)CardId.club3:
                cardNumber = 3;
                break;
            case (int)CardId.spade4:
            case (int)CardId.heart4:
            case (int)CardId.diamond4:
            case (int)CardId.club4:
                cardNumber = 4;
                break;
            case (int)CardId.spade5:
            case (int)CardId.heart5:
            case (int)CardId.diamond5:
            case (int)CardId.club5:
                cardNumber = 5;
                break;
            case (int)CardId.spade6:
            case (int)CardId.heart6:
            case (int)CardId.diamond6:
            case (int)CardId.club6:
                cardNumber = 6;
                break;
            case (int)CardId.spade7:
            case (int)CardId.heart7:
            case (int)CardId.diamond7:
            case (int)CardId.club7:
                cardNumber = 7;
                break;
            case (int)CardId.spade8:
            case (int)CardId.heart8:
            case (int)CardId.diamond8:
            case (int)CardId.club8:
                cardNumber = 8;
                break;
            case (int)CardId.spade9:
            case (int)CardId.heart9:
            case (int)CardId.diamond9:
            case (int)CardId.club9:
                cardNumber = 9;
                break;
            case (int)CardId.spade10:
            case (int)CardId.heart10:
            case (int)CardId.diamond10:
            case (int)CardId.club10:
                cardNumber = 10;
                break;
            case (int)CardId.spade11:
            case (int)CardId.heart11:
            case (int)CardId.diamond11:
            case (int)CardId.club11:
                cardNumber = 10;
                break;
            case (int)CardId.spade12:
            case (int)CardId.heart12:
            case (int)CardId.diamond12:
            case (int)CardId.club12:
                cardNumber = 10;
                break;
            case (int)CardId.spade13:
            case (int)CardId.heart13:
            case (int)CardId.diamond13:
            case (int)CardId.club13:
                cardNumber = 10;
                break;
            default:
                break;
        }
    }

    // エースカードがヒットした場合の処理
    private void AceCard()
    {
        // 現在の合計値が10以下だったら11を足す
        if (blackJackGame.playerCountCard)
        {
            if (blackJackGame.playerTotalNum <= 10)
            {
                blackJackGame.playerAceCard = true;
                cardNumber = 11;
            }
            // 合計値が11以上だった場合は1を足す
            else
            {
                cardNumber = 1;
            }
        }
        
        if (blackJackGame.aICountCard)
        {
            // 現在の合計値が10以下だったら11を足す
            if (blackJackGame.aITotalNum <= 10)
            {
                blackJackGame.aIAceCard = true;
                cardNumber = 11;
            }
            // 合計値が11以上だった場合は1を足す
            else
            {
                cardNumber = 1;
            }
        }
    }

    private void AceCardChack()
    {
        // エースカードが置いてある場合でバーストした時は10減らす
        if (blackJackGame.playerAceCard)
        {
            if (blackJackGame.playerTotalNum > 21)
            {
                blackJackGame.playerAceCard = false;
                blackJackGame.playerTotalNum -= 10;
            }
        }

        // エースカードが置いてある場合でバーストした時は10減らす
        if (blackJackGame.playerAceCard)
        {
            if (blackJackGame.aITotalNum > 21)
            {
                blackJackGame.aIAceCard = false;
                blackJackGame.aITotalNum -= 10;
            }
        }
    }
}
