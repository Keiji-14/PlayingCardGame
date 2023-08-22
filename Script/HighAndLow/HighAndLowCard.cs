using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �n�C�A���h���[�̃J�[�h�����̏���
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

    // 1���ڂ̃J�[�h�̏���
    private IEnumerator DrawCard1()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(0, 0), 0.02f);

        yield return new WaitForSeconds(1.0f);

        // 1���ڂ̏��������A1���ڂ�I���ς݂ɂ���
        highAndLowGame.openCardNum1 = cardNumber;
        StartCoroutine(OpenCard());
    }

    // 2���ڂ̃J�[�h�̏���
    private IEnumerator DrawCard2()
    {
        yield return new WaitForSeconds(1.0f);

        // 1���ڂ̏��������A1���ڂ�I���ς݂ɂ���
        highAndLowGame.openCardNum2 = cardNumber;
        StartCoroutine(OpenCard());
    }

    // �J�[�h�̕\��\������
    public IEnumerator OpenCard()
    {
        if (!front)
        {
            front = true;
            sEManager.audioSource.PlayOneShot(sEManager.audioClips[(int)SEManager.SE_Type.turnSE]);
            for (int turn = 0; turn < 180; turn++)
            {
                // �����܂ŗ��Ԃ�����摜��\�ɐ؂�ւ�
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