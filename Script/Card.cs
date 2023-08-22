using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// トランプカードを管理する処理
/// </summary>
public class Card : MonoBehaviour
{
    public int cardId;
    public int cardMark;
    public int cardNumber;

    public bool front;

    public SpriteRenderer spriteRenderer;
    public Sprite backSprite;
    public Sprite frontSprite;

    void Start()
    {
        //Componentを取得
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 最初は裏面を表示する
        spriteRenderer.sprite = backSprite;

        setCardNumber();
        setCardMark();
    }

    public enum CardId
    {
        spade1,
        spade2,
        spade3,
        spade4,
        spade5,
        spade6,
        spade7,
        spade8,
        spade9,
        spade10,
        spade11,
        spade12,
        spade13,
        heart1,
        heart2,
        heart3,
        heart4,
        heart5,
        heart6,
        heart7,
        heart8,
        heart9,
        heart10,
        heart11,
        heart12,
        heart13,
        diamond1,
        diamond2,
        diamond3,
        diamond4,
        diamond5,
        diamond6,
        diamond7,
        diamond8,
        diamond9,
        diamond10,
        diamond11,
        diamond12,
        diamond13,
        club1,
        club2,
        club3,
        club4,
        club5,
        club6,
        club7,
        club8,
        club9,
        club10,
        club11,
        club12,
        club13,
    }

    private void setCardNumber()
    {
        switch (cardId)
        {
            case (int)CardId.spade1:
            case (int)CardId.heart1:
            case (int)CardId.diamond1:
            case (int)CardId.club1:
                cardNumber = 1;
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
                cardNumber = 11;
                break;
            case (int)CardId.spade12:
            case (int)CardId.heart12:
            case (int)CardId.diamond12:
            case (int)CardId.club12:
                cardNumber = 12;
                break;
            case (int)CardId.spade13:
            case (int)CardId.heart13:
            case (int)CardId.diamond13:
            case (int)CardId.club13:
                cardNumber = 13;
                break;
            default:
                break;
        }
    }
    private void setCardMark()
    {
        switch (cardId)
        {
            case (int)CardId.spade1:
            case (int)CardId.spade2:
            case (int)CardId.spade3:
            case (int)CardId.spade4:
            case (int)CardId.spade5:
            case (int)CardId.spade6:
            case (int)CardId.spade7:
            case (int)CardId.spade8:
            case (int)CardId.spade9:
            case (int)CardId.spade10:
            case (int)CardId.spade11:
            case (int)CardId.spade12:
            case (int)CardId.spade13:
                cardMark = 1;
                break;
            case (int)CardId.heart1:  
            case (int)CardId.heart2:
            case (int)CardId.heart3:
            case (int)CardId.heart4:
            case (int)CardId.heart5:
            case (int)CardId.heart6:
            case (int)CardId.heart7:
            case (int)CardId.heart8:
            case (int)CardId.heart9:
            case (int)CardId.heart10:
            case (int)CardId.heart11:
            case (int)CardId.heart12:
            case (int)CardId.heart13:
                cardMark = 2;
                break;
            case (int)CardId.diamond1:
            case (int)CardId.diamond2:
            case (int)CardId.diamond3:
            case (int)CardId.diamond4:
            case (int)CardId.diamond5:
            case (int)CardId.diamond6:
            case (int)CardId.diamond7:
            case (int)CardId.diamond8:
            case (int)CardId.diamond9:
            case (int)CardId.diamond10:
            case (int)CardId.diamond11:
            case (int)CardId.diamond12:
            case (int)CardId.diamond13:
                cardMark = 3;
                break;
            case (int)CardId.club1:
            case (int)CardId.club2:
            case (int)CardId.club3:
            case (int)CardId.club4:
            case (int)CardId.club5:
            case (int)CardId.club6:
            case (int)CardId.club7:
            case (int)CardId.club8:
            case (int)CardId.club9:
            case (int)CardId.club10:
            case (int)CardId.club11:
            case (int)CardId.club12:
            case (int)CardId.club13:
                cardMark = 4;
                break;
        }
    }
}
