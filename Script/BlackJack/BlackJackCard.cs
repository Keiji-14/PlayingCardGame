using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�W���b�N�̃J�[�h�����̏���
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

        // Component���擾����
        blackJackGame = gameEvantObj.GetComponent<BlackJackGame>();
        sEManager = sEManagerObj.GetComponent<SEManager>();

        // �J�[�h��180�x��]������i�\�����ɂȂ����ꍇ�ɔ��]��h�~�j
        transform.Rotate(0, 180, 0);
        setBJCardNumber();
    }

    void Update()
    {
        // �J�[�h���������ꂽ�璼���ɃJ�[�h��\�����ɂ���
        StartCoroutine(OpenCard());

        // �v���C���[�̃J�[�h�����������ɓ��삳����
        if (blackJackGame.playerCountCard && !usedCard)
        { 
            // usedCard�Ŋ��o�̃J�[�h�������ēx���������Ȃ��悤�ɂ���
            usedCard = true;
            blackJackGame.playerCountCard = false;
            blackJackGame.playerSetCardNum[blackJackGame.playerSetCountNum] = cardNumber;
            blackJackGame.playerSetCountNum++;
            
            // �v���C���[�̍��v�l�ɃJ�[�h�̐����𑫂�
            blackJackGame.playerTotalNum += cardNumber;
        }

        // �f�B�[���[(AI)�̃J�[�h�����������ɓ��삳����
        if (blackJackGame.aICountCard && !usedCard)
        {
            // usedCard�Ŋ��o�̃J�[�h�������ēx���������Ȃ��悤�ɂ���
            usedCard = true;
            blackJackGame.aICountCard = false;
            blackJackGame.aISetCardNum[blackJackGame.aISetCountNum] = cardNumber;
            blackJackGame.aISetCountNum++;

            // �f�B�[���[(AI)�̍��v�l�ɃJ�[�h�̐����𑫂�
            blackJackGame.aITotalNum += cardNumber;
        }

        PlayerTurn();
        AITurn();
    }

    // �v���C���[�̃^�[�����ɓ��삷��
    private void PlayerTurn()
    {
        // �v���C���[��STAY��I�����Ă��Ȃ��ꍇ
        if (!blackJackGame.playerStayCard)
        {
            AceCardChack();
        }
    }

    // �f�B�[���[�̃^�[�����ɓ��삷��
    private void AITurn()
    {
        // �v���C���[��STAY��I�����Ă����ꍇ
        if (blackJackGame.playerStayCard)
        {
            AceCardChack();
        }
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

    // �J�[�h�Ƀu���b�N�W���b�N�̓_����ݒ�
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

    // �G�[�X�J�[�h���q�b�g�����ꍇ�̏���
    private void AceCard()
    {
        // ���݂̍��v�l��10�ȉ���������11�𑫂�
        if (blackJackGame.playerCountCard)
        {
            if (blackJackGame.playerTotalNum <= 10)
            {
                blackJackGame.playerAceCard = true;
                cardNumber = 11;
            }
            // ���v�l��11�ȏゾ�����ꍇ��1�𑫂�
            else
            {
                cardNumber = 1;
            }
        }
        
        if (blackJackGame.aICountCard)
        {
            // ���݂̍��v�l��10�ȉ���������11�𑫂�
            if (blackJackGame.aITotalNum <= 10)
            {
                blackJackGame.aIAceCard = true;
                cardNumber = 11;
            }
            // ���v�l��11�ȏゾ�����ꍇ��1�𑫂�
            else
            {
                cardNumber = 1;
            }
        }
    }

    private void AceCardChack()
    {
        // �G�[�X�J�[�h���u���Ă���ꍇ�Ńo�[�X�g��������10���炷
        if (blackJackGame.playerAceCard)
        {
            if (blackJackGame.playerTotalNum > 21)
            {
                blackJackGame.playerAceCard = false;
                blackJackGame.playerTotalNum -= 10;
            }
        }

        // �G�[�X�J�[�h���u���Ă���ꍇ�Ńo�[�X�g��������10���炷
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
