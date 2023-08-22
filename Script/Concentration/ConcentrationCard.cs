using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 神経衰弱のカード部分の処理
/// </summary>
public class ConcentrationCard : Card, IPointerClickHandler
{
    [SerializeField] GameObject gameEvantObj;
    [SerializeField] GameObject sEManagerObj;

    [Header("GetComponent")]
    ConcentrationGame concentrationGame;
    SEManager sEManager;

    void Start()
    {
        gameEvantObj = GameObject.Find("GameEvent");
        sEManagerObj = GameObject.Find("SEManager");
        concentrationGame = gameEvantObj.GetComponent<ConcentrationGame>();
        sEManager = sEManagerObj.GetComponent<SEManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // ライフが0になるまで引ける
        if (concentrationGame.life > 0)
        {
            if (!front)
            {
                // 1枚目がまだ選択されていない場合
                if (!concentrationGame.openCard1)
                {
                    // 1枚目の情報を代入し、1枚目を選択済みにする
                    concentrationGame.openCard1 = true;
                    concentrationGame.openCardNum1 = cardNumber;

                    concentrationGame.openCardObj1 = this.gameObject;

                    StartCoroutine(OpenCard());
                }
                // 1枚目がまだ選択されていて2枚目がまだ選択していない場合
                else if (concentrationGame.openCard1 &&
                        !concentrationGame.openCard2)
                {
                    concentrationGame.openCard2 = true;
                    // 2枚目の情報を代入し、2枚目を選択済みにする
                    concentrationGame.openCardNum2 = cardNumber;
                    concentrationGame.openCardObj2 = this.gameObject;

                    // 二枚目以降めくれないようにする
                    concentrationGame.checkInterval = true;

                    StartCoroutine(OpenCard());
                }
            }
        }
        if (concentrationGame.checkInterval)
        {
            concentrationGame.checkInterval = false;
            StartCoroutine(concentrationGame.CardCheck());
        }
    }

    // カードの表を表示する
    public IEnumerator OpenCard()
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

    // カードの裏を表示する
    public IEnumerator CloseCard()
    {
        sEManager.audioSource.PlayOneShot(sEManager.audioClips[(int)SEManager.SE_Type.turnSE]);
        for (int turn = 0; turn < 180; turn++)
        {
            if (turn > 90)
            {
                front = false;
                spriteRenderer.sprite = backSprite;
            }
            transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
