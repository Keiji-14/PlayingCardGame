using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �_�o����̃Q�[�������̏���
/// </summary>
public class ConcentrationGame : ConcentrationCard
{
    [Header("EasyMode")]
    public List<GameObject> easyCardList;
    public List<GameObject> setEasyCardList = new List<GameObject>();

    [Header("NormalMode")]
    public List<GameObject> normalCardList;
    public List<GameObject> setNormalCardList = new List<GameObject>();

    [Header("HardMode")]
    public List<GameObject> hardCardList;
    public List<GameObject> setHardCardList = new List<GameObject>();

    private int choiceNum;
    private int successCount;
    private GameObject randomCard;

    [Header("Window")]
    [SerializeField] GameObject startWindow;
    [SerializeField] GameObject lifeModeClearWindow;
    [SerializeField] GameObject timeAttackclearWindow;
    [SerializeField] GameObject gameOverWindow;

    [Header("Life")]
    [SerializeField] GameObject lifeWindow;
    [SerializeField] GameObject[] lifeHeart;
    public int life = 5;

    [Header("TimeAttack")]
    [SerializeField] GameObject timeCountWindow;
    [SerializeField] Text timeCountText;
    [SerializeField] Text clearCountText;
    public float secondCount;
    public float minuteCount;

    [Header("TimeRecode")]
    [SerializeField] Text timeRecodeText;
    private float easySecondRecode;
    private float easyMinuteRecode;
    private float normalSecondRecode;
    private float normalMinuteRecode;
    private float hardSecondRecode;
    private float hardMinuteRecode;

    [Header("Level")]
    public static int concentrationMode;
    public static int concentrationLevel;

    private bool startChack;
    private bool clearChack;
    [HideInInspector] public bool checkInterval;
    [HideInInspector] public bool openCard1;
    [HideInInspector] public bool openCard2;
    [HideInInspector] public int openCardNum1;
    [HideInInspector] public int openCardNum2;
    [HideInInspector] public GameObject openCardObj1;
    [HideInInspector] public GameObject openCardObj2;

    [Header("Button")]
    [SerializeField] Button pauseButton;

    [Header("GetComponent")]
    public ScenesManager scenesManager;

    void Start()
    {
        startWindow.SetActive(true);
        // �Q�[�����[�h�̕ʂɃE�B���h�E��؂�ւ�
        switch (concentrationMode)
        {
            case 0:
                lifeWindow.SetActive(true);
                break;
            case 1:
                timeCountWindow.SetActive(true);
                break;
        }
        // �Q�[����Փx�̐ݒ�
        switch (concentrationLevel)
        {
            case 0:
                EasyMode();
                break;
            case 1:
                NormalMode();
                break;
            case 2:
                HardMode();
                break;
        }
    }

    void Update()
    {
        if (startChack)
        {
            startWindow.SetActive(false);
            // �Q�[�����[�h�̐ݒ�
            switch (concentrationMode)
            {
                case 0:
                    LifeMode();
                    break;
                case 1:
                    TimeAttackMode();
                    break;
            }
        }
    }

    // ��ʂ��^�b�v�ŃQ�[�����J�n����
    public void TapStart()
    {
        startChack = true;
    }

    // �C�[�W�[���[�h�̃J�[�h�z�u�̏���
    private void EasyMode()
    {
        successCount = 6;
        for (int i = 0; i < 12; i++)
        {
            randomCard = easyCardList[Random.Range(0, easyCardList.Count)];
            // �����_���őI�΂ꂽ�J�[�h��setEasyCardList�ɒǉ�
            setEasyCardList.Add(randomCard);
            // �I�΂ꂽ�J�[�h�̃��X�g�ԍ����擾
            choiceNum = easyCardList.IndexOf(randomCard);
            //�������X�g�ԍ���easyCardList����폜
            easyCardList.RemoveAt(choiceNum);
        }

        // �J�[�h�����ꂼ��̏ꏊ�ɔz�u
        setEasyCardList[0].gameObject.transform.position = new Vector2(-1.8f, 2);
        setEasyCardList[1].gameObject.transform.position = new Vector2(-0.6f, 2);
        setEasyCardList[2].gameObject.transform.position = new Vector2(0.6f, 2);
        setEasyCardList[3].gameObject.transform.position = new Vector2(1.8f, 2);
        setEasyCardList[4].gameObject.transform.position = new Vector2(-1.8f, 0);
        setEasyCardList[5].gameObject.transform.position = new Vector2(-0.6f, 0);
        setEasyCardList[6].gameObject.transform.position = new Vector2(0.6f, 0);
        setEasyCardList[7].gameObject.transform.position = new Vector2(1.8f, 0);
        setEasyCardList[8].gameObject.transform.position = new Vector2(-1.8f, -2);
        setEasyCardList[9].gameObject.transform.position = new Vector2(-0.6f, -2);
        setEasyCardList[10].gameObject.transform.position = new Vector2(0.6f, -2);
        setEasyCardList[11].gameObject.transform.position = new Vector2(1.8f, -2);
    }

    // �m�[�}�����[�h�̃J�[�h�z�u�̏���
    private void NormalMode()
    {
        successCount = 8;
        for (int i = 0; i < 16; i++)
        {
            randomCard = normalCardList[Random.Range(0, normalCardList.Count)];
            // �����_���őI�΂ꂽ�J�[�h��setEasyCardList�ɒǉ�
            setNormalCardList.Add(randomCard);
            // �I�΂ꂽ�J�[�h�̃��X�g�ԍ����擾
            choiceNum = normalCardList.IndexOf(randomCard);
            //�������X�g�ԍ���easyCardList����폜
            normalCardList.RemoveAt(choiceNum);
        }

        // �J�[�h�����ꂼ��̏ꏊ�ɔz�u
        setNormalCardList[0].gameObject.transform.position = new Vector2(-1.8f, 2.4f);
        setNormalCardList[1].gameObject.transform.position = new Vector2(-0.6f, 2.4f);
        setNormalCardList[2].gameObject.transform.position = new Vector2(0.6f, 2.4f);
        setNormalCardList[3].gameObject.transform.position = new Vector2(1.8f, 2.4f);
        setNormalCardList[4].gameObject.transform.position = new Vector2(-1.8f, 0.8f);
        setNormalCardList[5].gameObject.transform.position = new Vector2(-0.6f, 0.8f);
        setNormalCardList[6].gameObject.transform.position = new Vector2(0.6f, 0.8f);
        setNormalCardList[7].gameObject.transform.position = new Vector2(1.8f, 0.8f);
        setNormalCardList[8].gameObject.transform.position = new Vector2(-1.8f, -0.8f);
        setNormalCardList[9].gameObject.transform.position = new Vector2(-0.6f, -0.8f);
        setNormalCardList[10].gameObject.transform.position = new Vector2(0.6f, -0.8f);
        setNormalCardList[11].gameObject.transform.position = new Vector2(1.8f, -0.8f);
        setNormalCardList[12].gameObject.transform.position = new Vector2(-1.8f, -2.4f);
        setNormalCardList[13].gameObject.transform.position = new Vector2(-0.6f, -2.4f);
        setNormalCardList[14].gameObject.transform.position = new Vector2(0.6f, -2.4f);
        setNormalCardList[15].gameObject.transform.position = new Vector2(1.8f, -2.4f);
    }

    // �m�[�}�����[�h�̃J�[�h�z�u�̏���
    private void HardMode()
    {
        successCount = 10;
        for (int i = 0; i < 20; i++)
        {
            randomCard = hardCardList[Random.Range(0, hardCardList.Count)];
            // �����_���őI�΂ꂽ�J�[�h��setEasyCardList�ɒǉ�
            setHardCardList.Add(randomCard);
            // �I�΂ꂽ�J�[�h�̃��X�g�ԍ����擾
            choiceNum = hardCardList.IndexOf(randomCard);
            //�������X�g�ԍ���easyCardList����폜
            hardCardList.RemoveAt(choiceNum);
        }

        // �J�[�h�����ꂼ��̏ꏊ�ɔz�u
        setHardCardList[0].gameObject.transform.position = new Vector2(-2.0f, 2.4f);
        setHardCardList[1].gameObject.transform.position = new Vector2(-1.0f, 2.4f);
        setHardCardList[2].gameObject.transform.position = new Vector2(0.0f, 2.4f);
        setHardCardList[3].gameObject.transform.position = new Vector2(1.0f, 2.4f);
        setHardCardList[4].gameObject.transform.position = new Vector2(2.0f, 2.4f);
        setHardCardList[5].gameObject.transform.position = new Vector2(-2.0f, 0.8f);
        setHardCardList[6].gameObject.transform.position = new Vector2(-1.0f, 0.8f);
        setHardCardList[7].gameObject.transform.position = new Vector2(0.0f, 0.8f);
        setHardCardList[8].gameObject.transform.position = new Vector2(1.0f, 0.8f);
        setHardCardList[9].gameObject.transform.position = new Vector2(2.0f, 0.8f);
        setHardCardList[10].gameObject.transform.position = new Vector2(-2.0f, -0.8f);
        setHardCardList[11].gameObject.transform.position = new Vector2(-1.0f, -0.8f);
        setHardCardList[12].gameObject.transform.position = new Vector2(0.0f, -0.8f);
        setHardCardList[13].gameObject.transform.position = new Vector2(1.0f, -0.8f);
        setHardCardList[14].gameObject.transform.position = new Vector2(2.0f, -0.8f);
        setHardCardList[15].gameObject.transform.position = new Vector2(-2.0f, -2.4f);
        setHardCardList[16].gameObject.transform.position = new Vector2(-1.0f, -2.4f);
        setHardCardList[17].gameObject.transform.position = new Vector2(0.0f, -2.4f);
        setHardCardList[18].gameObject.transform.position = new Vector2(1.0f, -2.4f);
        setHardCardList[19].gameObject.transform.position = new Vector2(2.0f, -2.4f);
    }

    // �J�[�h�������Ă��邩�ǂ����m�F���鏈��
    public IEnumerator CardCheck()
    {
        // �J�[�h�̐����������Ă�����A�����Ă�J�[�h���폜����
        if (openCardNum1 == openCardNum2)
        {
            Debug.Log("�����Ă���");

            yield return new WaitForSeconds(1.0f);

            // �I������2���̃J�[�h���폜����
            Destroy(openCardObj1);
            Destroy(openCardObj2);

            // �I�������J�[�h�̏�������
            openCardNum1 = 0;
            openCardNum2 = 0;
            openCard1 = false;
            openCard2 = false;

            ClearChack();
        }
        // �J�[�h�̐����������Ă��Ȃ�������A�J�[�h�𗠕Ԃ���
        else
        {
            Debug.Log("�����Ă��Ȃ�");
            // �I������2���̃J�[�h�̃R���|�[�l���g���擾
            ConcentrationCard closeCardObj1 = openCardObj1.GetComponent<ConcentrationCard>();
            ConcentrationCard closeCardObj2 = openCardObj2.GetComponent<ConcentrationCard>();

            yield return new WaitForSeconds(1.0f);

            // ���C�t���[�h�������ꍇ�̓��C�t�����炷
            if (concentrationMode == 0)
            {
                life -= 1;
            }

            StartCoroutine(closeCardObj1.CloseCard());
            StartCoroutine(closeCardObj2.CloseCard());

            // �I�������J�[�h�̏�������
            openCardNum1 = 0;
            openCardNum2 = 0;
            openCard1 = false;
            openCard2 = false;
        }
    }

    // ���C�t���[�h�̏���
    private void LifeMode()
    {
        switch (life)
        {
            case 0:
                Debug.Log("�Q�[���I�[�o�[");
                Invoke("GameOver", 1.0f);
                Destroy(lifeHeart[0]);
                break;
            case 1:
                Destroy(lifeHeart[1]);
                break;
            case 2:
                Destroy(lifeHeart[2]);
                break;
            case 3:
                Destroy(lifeHeart[3]);
                break;
            case 4:
                Destroy(lifeHeart[4]);
                break;
            case 5:
                break;
        }
    }

    // �^�C���A�^�b�N���[�h�̏���
    private void TimeAttackMode()
    {
        // �S�ẴJ�[�h�𑵂���܂Ōv������
        if (!clearChack)
        {
            secondCount += Time.deltaTime;
        }
        else
        {
            timeCountWindow.SetActive(false);
            ClearTime();
        }
        if (secondCount >= 60.0f)
        {
            minuteCount++;
            secondCount = secondCount - 60;
           
        }
        timeCountText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
    }

    // �^�C���A�^�b�N�̃��R�[�h����
    private void ClearTime()
    {
        clearCountText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        switch (concentrationLevel)
        {
            case 0:
                EasyTimeRecode();
                break;
            case 1:
                NormalTimeRecode();
                break;
            case 2:
                HardTimeRecode();
                break;
        }
    }

    // �C�[�W�[���[�h�̃��R�[�h����
    private void EasyTimeRecode()
    {
        easyMinuteRecode = PlayerPrefs.GetFloat("SaveEasyMinute", 0);
        easySecondRecode = PlayerPrefs.GetFloat("SaveEasySecond", 0);

        // ����̋L�^�������ꍇ�͐V�L�^�����ɂ���
        if (easyMinuteRecode == 0 && easySecondRecode == 0)
        {
            PlayerPrefs.SetFloat("SaveEasyMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveEasySecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        // �V�L�^���o����L�^�X�V����
        else if (easyMinuteRecode >= minuteCount && easySecondRecode > secondCount)
        {
            PlayerPrefs.SetFloat("SaveEasyMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveEasySecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        else
        {
            timeRecodeText.text = easyMinuteRecode.ToString("00") + " : " + easySecondRecode.ToString("00");
        }
    }

    // �m�[�}�����[�h�̃��R�[�h����
    private void NormalTimeRecode()
    {
        normalMinuteRecode = PlayerPrefs.GetFloat("SaveNormalMinute", 0);
        normalSecondRecode = PlayerPrefs.GetFloat("SaveNormalSecond", 0);

        // ����̋L�^�������ꍇ�͐V�L�^�����ɂ���
        if (normalMinuteRecode == 0 && normalSecondRecode == 0)
        {
            PlayerPrefs.SetFloat("SaveNormalMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveNormalSecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        // �V�L�^���o����L�^�X�V����
        else if (normalMinuteRecode >= minuteCount && normalSecondRecode > secondCount)
        {
            PlayerPrefs.SetFloat("SaveNormalMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveNormalSecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        else
        {
            timeRecodeText.text = normalMinuteRecode.ToString("00") + " : " + normalSecondRecode.ToString("00");
        }
    }

    // �n�[�h���[�h�̃��R�[�h����
    private void HardTimeRecode()
    {
        hardMinuteRecode = PlayerPrefs.GetFloat("SaveHardMinute", 0);
        hardSecondRecode = PlayerPrefs.GetFloat("SaveHardSecond", 0);

        // ����̋L�^�������ꍇ�͐V�L�^�����ɂ���
        if (hardMinuteRecode == 0 && hardSecondRecode == 0)
        {
            PlayerPrefs.SetFloat("SaveHardMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveHardSecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        // �V�L�^���o����L�^�X�V����
        else if (hardMinuteRecode >= minuteCount && hardSecondRecode > secondCount)
        {
            PlayerPrefs.SetFloat("SaveHardMinute", minuteCount);
            PlayerPrefs.SetFloat("SaveHardSecond", secondCount);
            timeRecodeText.text = minuteCount.ToString("00") + " : " + secondCount.ToString("00");
        }
        else
        {
            timeRecodeText.text = hardMinuteRecode.ToString("00") + " : " + hardSecondRecode.ToString("00");
        }
    }

    // �N���A�������ǂ����̊m�F���鏈��
    private void ClearChack()
    {
        // �������邽�тɃJ�E���g��1���炷
        successCount -= 1;
        // �J�E���g��0�ɂȂ�΃Q�[���N���A�ɂȂ�
        if (successCount == 0)
        {
            // �Q�[�����[�h�ʂɃN���A�E�B���h�E��\��
            switch (concentrationMode)
            {
                case 0:
                    lifeModeClearWindow.SetActive(true);
                    pauseButton.interactable = false;
                    break;
                case 1:
                    timeAttackclearWindow.SetActive(true);
                    pauseButton.interactable = false;
                    clearChack = true;
                    break;
            }
        }
    }

    // �Q�[���I�[�o�[��ʂ�\��
    private void GameOver()
    {
        gameOverWindow.SetActive(true);
        pauseButton.interactable = false;
    }
}
