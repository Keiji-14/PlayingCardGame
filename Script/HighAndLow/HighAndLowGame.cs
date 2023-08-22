using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �n�C�A���h���[�̃Q�[�������̏���
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
        // �Q�[�����J�n���鏈��
        if (startChack)
        {
            startWindow.SetActive(false);

            // �ꖇ�ڂ��߂����鏈��
            StartCoroutine(SetCard1());
        }

        // �񖇖ڂ��߂����鏈��
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

        foreach(GameObject resetCard in baseCard)
        {
            useCardList.Add(resetCard);
        }
    }

    // ���̃Q�[���Ɉڍs����ׂɑO�̃Q�[���̏������ɖ߂�����
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
            
            // �v���C���[���I���������̂���������������_����
            if (nextHeightCard == selectNextHeightCard)
            {
                successCount++;
            }
        }
    }

    // 1���ڂ̃J�[�h��W�J���鏈��
    private IEnumerator SetCard1()
    {
        if (!openCard1)
        {
            openCard1 = true;
            cardObj1 = useCardList[Random.Range(0, useCardList.Count)];

            Instantiate(cardObj1, new Vector2(0, 2.0f), Quaternion.identity);
            // �I�΂ꂽ�J�[�h�̃��X�g�ԍ����擾
            var choiceNum = useCardList.IndexOf(cardObj1);
            //�������X�g�ԍ���cardList����폜
            useCardList.RemoveAt(choiceNum);

            // ��莞�Ԍo������Ƀ{�^����������悤�ɂ���
            yield return new WaitForSeconds(2.0f);
            highButton.interactable = true;
            lowButton.interactable = true;
        }
    }

    // 2���ڂ̃J�[�h��W�J���鏈��
    private void SetCard2()
    {
        backCardObj.SetActive(false);
        selectChack = false;
        openCard2 = true;
        cardObj2 = useCardList[Random.Range(0, useCardList.Count)];

        Instantiate(cardObj2, new Vector2(0, 2.0f), Quaternion.identity);
        // �I�΂ꂽ�J�[�h�̃��X�g�ԍ����擾
        var choiceNum = useCardList.IndexOf(cardObj2);
        //�������X�g�ԍ���cardList����폜
        useCardList.RemoveAt(choiceNum);
    }

    // 1���ڂɈ������J�[�h�̐�����莟�Ɉ����J�[�h�̐������������Ⴂ��
    private IEnumerator ChackHighAndLow()
    {
        nextChack = false;

        yield return new WaitForSeconds(1.0f);

        // 1���ڂ�2���ڂ̃J�[�h���r���Ă��̌��ʂ���
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

        // ���ʂ������̑I���������ʂƍ����Ă��邩��r
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

    // ��������I��
    public void HighButton()
    {
        selectChack = true;
        selectNextHeightCard = (int)Height.highCrad;
        highButton.interactable = false;
        lowButton.interactable = false;
    }

    // �Ⴂ����I��
    public void LowButton()
    {
        selectChack = true;
        selectNextHeightCard = (int)Height.lowCard;
        highButton.interactable = false;
        lowButton.interactable = false;
    }

    // �Q�[���I�[�o�[��ʂ�\��
    private void GameOver()
    {
        gameOverWindow.SetActive(true);
        pauseButton.interactable = false;

        // �L�^���X�V�������ǂ����m�F
        if (recodeCount < successCount)
        {
            recodeCount = successCount;
            PlayerPrefs.SetInt("SaveHALCount", recodeCount);
        }
        
        recodeCountText.text = "�F" + recodeCount.ToString("00");
        resultCountText.text = "�F" + successCount.ToString("00");
    }
}