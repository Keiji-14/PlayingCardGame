using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ハイアンドローのカード部分の処理
/// </summary>
public class HighAndLowCard : Card
{
    [SerializeField] GameObject gameEvant;
    [SerializeField] GameObject sEManagerObj;

    [Header("GetComponent")]
    HighAndLowGame highAndLowGame;
    SEManager sEManager;

    void Start()
    {
        gameEvant = GameObject.Find("GameEvent");
        sEManagerObj = GameObject.Find("SEManager");
        highAndLowGame = gameEvant.GetComponent<HighAndLowGame>();
        sEManager = sEManagerObj.GetComponent<SEManager>();
        transform.Rotate(0, 180, 0);
    }

    void Update()
    { 
        if (highAndLowGame.openCard1 && !highAndLowGame.openCard2)
        {
            StartCoroutine(DrawCard1());
        }
        if (highAndLowGame.openCard2)
        {
            StartCoroutine(DrawCard2());
        }
    }

    // 1枚目のカードの処理
    private IEnumerator DrawCard1()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(0, 0), 0.02f);

        yield return new WaitForSeconds(1.0f);

        // 1枚目の情報を代入し、1枚目を選択済みにする
        highAndLowGame.openCardNum1 = cardNumber;
        StartCoroutine(OpenCard());
    }

    // 2枚目のカードの処理
    private IEnumerator DrawCard2()
    {
        yield return new WaitForSeconds(1.0f);

        // 1枚目の情報を代入し、1枚目を選択済みにする
        highAndLowGame.openCardNum2 = cardNumber;
        StartCoroutine(OpenCard());
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
}