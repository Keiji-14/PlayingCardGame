using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �u���b�N�W���b�N�̃Q�[�������̏���
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
        // �v���C���[�̔z�u��Ԃ���Utrue�ɂ���
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

    // ��ʂ��^�b�v�ŃQ�[�����J�n����
    public void TapStart()
    {
        startChack = true;
    }

    // ���̃Q�[���ׂ̈ɃJ�[�h����߂�����
    private void ResetCard()
    {
        // �g�p�����J�[�h���폜����
        GameObject[] usedCards = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject destroyCard in usedCards)
        {
            Destroy(destroyCard);
        }

        // useCardList�̗v�f���폜���Ă���baseCard��v�f�ɓ����
        useCardList.RemoveRange(0, useCardList.Count);

        foreach (GameObject resetCard in baseCard)
        {
            useCardList.Add(resetCard);
        }
    }

    // ���̃Q�[���Ɉڍs����ׂɑO�̃Q�[���̏������ɖ߂�����
    private IEnumerator NextGame()
    {
        //ProgressGame();
        ResetCard();
        gameChack = false;

        // �v���C���[�̏����폜
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

        // AI(�f�B�[���[)�̏����폜
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

        // �҂����̂��ɃQ�[�����J�n����
        gameChack = true;
        StopCoroutine(NextGame());
    }

    // �Q�[���̐i�s���Ǘ�
    private void ProgressGame()
    {
        StartCoroutine(AISetCard());

        StartCoroutine(PlayerSetCard());
        StartCoroutine(PlayerHitCard());

        AIMove();
        GameChack();
    }

    // ���s����̊m�F
    private void GameChack()
    {
        // ����Stay��I��������
        if (playerStayCard && aIStayCard)
        {
            playerStayCard = false;
            aIStayCard = false;
            // �v���C���[��AI(�f�B�[���[)���ҋ��Ƀo�[�X�g���Ă����ꍇ�͈�������
            if (playerBurst && aIBurst)
            {
                Debug.Log("Drow");
            }
            // �v���C���[���o�[�X�g���Ă����ꍇ�͕���
            else if (playerBurst)
            {
                loseChack = true;
                Debug.Log("Lose");
            }
            // AI(�f�B�[���[)���o�[�X�g���Ă����ꍇ�͏���
            else if (aIBurst)
            {
                winChack = true;
                Debug.Log("Win");
            }
            // �v���C���[���AI(�f�B�[���[)�̍��v�l�̕������������ꍇ�͕���
            else if (playerTotalNum < aITotalNum)
            {
                loseChack = true;
                Debug.Log("Lose");
            }
            // �v���C���[���AI(�f�B�[���[)�̍��v�l�̕����Ⴉ�����ꍇ�͏���
            else if (playerTotalNum > aITotalNum)
            {
                winChack = true;
                Debug.Log("Win");
            }
            // �v���C���[��AI(�f�B�[���[)�̍��v�l�������������ꍇ�͈�������
            else if (playerTotalNum == aITotalNum)
            {
                Debug.Log("Drow");
            }

            // �v���C���[�������Ă����ꍇ�̓}����t���āA�����_��1���₷
            if (winChack)
            {
                winChack = false;
                outComeCountImg[gameCount].sprite = successSprite;
                gameCount++;
                outComeCount++;
            }
            // �v���C���[�������Ă�����o�c��t���āA�����_��1���炷
            else if (loseChack)
            {
                loseChack = false;
                outComeCountImg[gameCount].sprite = failSprite;
                gameCount++;
                outComeCount--;
            }
            // ���������������牡����t����
            else if (!winChack && !loseChack)
            {
                outComeCountImg[gameCount].sprite = drowSprite;
                gameCount++;
            }

            // 5���E���h���I���܂ŃQ�[���𑱂���
            if (gameCount < 5)
            {
                StartCoroutine(NextGame());
            }
            // 5���E���h���I������Ƃ��ɏ����_�ŏ��s�����肷��
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

    // �v���C���[�ɃJ�[�h��z�鏈��
    private IEnumerator PlayerSetCard()
    {
        if (!playerSetCard)
        {
            playerSetCard = true;

            yield return new WaitForSeconds(0.75f);

            // 1���ڂ��Z�b�g���鏈��
            playerCardObj[playerSetCountNum] = useCardList[Random.Range(0, useCardList.Count)];
            playerCountCard = true;
            Instantiate(playerCardObj[playerSetCountNum], new Vector3(-2.0f, -1.0f, 0.0f), Quaternion.identity);
            

            // �I�΂ꂽ�J�[�h�̃��X�g�ԍ����擾
            var choiceNum1 = useCardList.IndexOf(playerCardObj[0]);
            //�������X�g�ԍ���cardList����폜
            useCardList.RemoveAt(choiceNum1);

            yield return new WaitForSeconds(0.75f);

            // 2���ڂ��Z�b�g���鏈��
            playerCardObj[1] = useCardList[Random.Range(playerSetCountNum, useCardList.Count)];
            playerCountCard = true;
            Instantiate(playerCardObj[playerSetCountNum], new Vector3(-1.0f, -1.0f, 0.0f), Quaternion.identity);
            
            // �I�΂ꂽ�J�[�h�̃��X�g�ԍ����擾
            var choiceNum2 = useCardList.IndexOf(playerCardObj[1]);
            //�������X�g�ԍ���cardList����폜
            useCardList.RemoveAt(choiceNum2);

            // ��莞�Ԍo������Ƀ{�^����������悤�ɂ���
            yield return new WaitForSeconds(0.75f);
            drowButton.interactable = true;
            stayButton.interactable = true;
        }
    }

    // �v���C���[���q�b�g�������̏���
    private IEnumerator PlayerHitCard()
    {
        if (playerHitCard)
        {
            playerHitCard = false;
            playerCardObj[playerSetCountNum] = useCardList[Random.Range(0, useCardList.Count)];
            
            Instantiate(playerCardObj[playerSetCountNum], new Vector3(playerSetCountNum - 2.0f, -1.0f, 0.0f), Quaternion.identity);
            playerCountCard = true;
            // �I�΂ꂽ�J�[�h�̃��X�g�ԍ����擾
            var choiceNum = useCardList.IndexOf(playerCardObj[playerSetCountNum]);
            //�������X�g�ԍ���cardList����폜
            useCardList.RemoveAt(choiceNum);
            
            // ��莞�Ԍo������Ƀ{�^����������悤�ɂ���
            yield return new WaitForSeconds(1.0f);
            PlayerChack();
        }
    }

    // �v���C���[���q�b�g������̏󋵊m�F����
    private void PlayerChack()
    {
        // �v���C���[��Stay��I�����Ă����ꍇ�̓`�F�b�N�͕s�v
        if (!playerStayCard)
        {
            // �v���C���[�̏�ɃJ�[�h��5���ɂȂ������_�ŋ���Stay
            if (playerSetCountNum < 5)
            {
                // �v���C���[�̍��v�l��22�ȏゾ������o�[�X�g�ɂ��AAI(�f�B�[���[)�̃^�[���Ɉڍs����
                if (playerTotalNum > 21)
                {
                    Debug.Log("Burst");
                    playerBurst = true;
                    playerStayCard = true;
                    aIHitCard = true;
                }
                // 21�ȉ��Ȃ�{�^�����ēx�o����悤�ɂ���
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

    // AI(�f�B�[���[)�ɃJ�[�h��z�鏈��
    private IEnumerator AISetCard()
    {
        if (!aISetCard)
        {
            aISetCard = true;

            // 1���ڂ��Z�b�g���鏈��
            aICardObj[aISetCountNum] = useCardList[Random.Range(0, useCardList.Count)];
            aICountCard = true;
            Instantiate(aICardObj[aISetCountNum], new Vector3(-2.0f, 3.0f, 1.0f), Quaternion.identity);
            
            // �I�΂ꂽ�J�[�h�̃��X�g�ԍ����擾
            var choiceNum1 = useCardList.IndexOf(aICardObj[0]);
            //�������X�g�ԍ���cardList����폜
            useCardList.RemoveAt(choiceNum1);

            yield return new WaitForSeconds(0.75f);

            playerSetCard = false;
            // 2���ڂ𕚂��ăZ�b�g���鏈��
            backCard.SetActive(true);
        }
    }

    // AI(�f�B�[���[)�̍s��
    private void AIMove()
    {
        // AI(�f�B�[���[)�̍s�����J�n
        if (playerStayCard && !aIStayCard)
        {
            backCard.SetActive(false);
            StartCoroutine(AIHit());
        }
    }

    // AI(�f�B�[���[)���q�b�g�������̏���
    private IEnumerator AIHit()
    {
        if (aIHitCard)
        {
            aIHitCard = false;
            aICardObj[aISetCountNum] = useCardList[Random.Range(0, useCardList.Count)];

            Instantiate(aICardObj[aISetCountNum], new Vector3(aISetCountNum - 2.0f, 3.0f, 0.0f), Quaternion.identity);
            aICountCard = true;
            // �I�΂ꂽ�J�[�h�̃��X�g�ԍ����擾
            var choiceNum = useCardList.IndexOf(aICardObj[aISetCountNum]);
            //�������X�g�ԍ���cardList����폜
            useCardList.RemoveAt(choiceNum);

            // ��莞�Ԍo������Ƀ{�^����������悤�ɂ���
            yield return new WaitForSeconds(1.0f);
            AIChack();
        }
    }

    // AI(�f�B�[���[)���q�b�g������̏󋵊m�F����
    private void AIChack()
    {
        // AI(�f�B�[���[)�̏�ɃJ�[�h��5���ɂȂ������_�ŋ���Stay
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

    // �J�[�h�����ƑI���������̏���
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

    // �J�[�h�������Ȃ��ƑI���������̏���
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