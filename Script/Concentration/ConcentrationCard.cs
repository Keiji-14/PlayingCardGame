using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �_�o����̃J�[�h�����̏���
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
        // ���C�t��0�ɂȂ�܂ň�����
        if (concentrationGame.life > 0)
        {
            if (!front)
            {
                // 1���ڂ��܂��I������Ă��Ȃ��ꍇ
                if (!concentrationGame.openCard1)
                {
                    // 1���ڂ̏��������A1���ڂ�I���ς݂ɂ���
                    concentrationGame.openCard1 = true;
                    concentrationGame.openCardNum1 = cardNumber;

                    concentrationGame.openCardObj1 = this.gameObject;

                    StartCoroutine(OpenCard());
                }
                // 1���ڂ��܂��I������Ă���2���ڂ��܂��I�����Ă��Ȃ��ꍇ
                else if (concentrationGame.openCard1 &&
                        !concentrationGame.openCard2)
                {
                    concentrationGame.openCard2 = true;
                    // 2���ڂ̏��������A2���ڂ�I���ς݂ɂ���
                    concentrationGame.openCardNum2 = cardNumber;
                    concentrationGame.openCardObj2 = this.gameObject;

                    // �񖇖ڈȍ~�߂���Ȃ��悤�ɂ���
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

    // �J�[�h�̕\��\������
    public IEnumerator OpenCard()
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

    // �J�[�h�̗���\������
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
