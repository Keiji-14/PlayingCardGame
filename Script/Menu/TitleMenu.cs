using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �^�C�g����ʂ̏���
/// </summary>
public class TitleMenu : MonoBehaviour
{
    private bool chackTapButton;

    [Header("Title")]
    public GameObject titleWindow;
    [Header("GameSelect")]
    public GameObject gameSelectWindow;
    [Header("Concentration")]
    public GameObject concentrationModeWindow;
    public GameObject concentrationLifeModeDifficultyWindow;
    public GameObject concentrationTimeAttackModeDifficultyWindow;

    [Header("Scene")]
    public ScenesManager scenesManager;

    enum Level
    {
        easy,
        normal,
        hard,
    }

    private void Start()
    {
        // ���������������ɍŏ��ɉ������ق���D�悳����
        chackTapButton = false;
    }

    public void TapStart()
    {
        titleWindow.SetActive(false);
        gameSelectWindow.SetActive(true);
    }

    // �_�o����̃��[�h�I����ʂ�\��
    public void ConcentrationMode()
    {
        gameSelectWindow.SetActive(false);
        concentrationModeWindow.SetActive(true);

        // �_�o����̃��x���I����ʂ���߂鎞�ɔ�\��
        concentrationLifeModeDifficultyWindow.SetActive(false);
        concentrationTimeAttackModeDifficultyWindow.SetActive(false);
    }

    public void GameSelect()
    {
        concentrationModeWindow.SetActive(false);
        gameSelectWindow.SetActive(true);
    }

    // �_�o����̃��C�t���[�h�̃��x���I����ʂ�\��
    public void ConcentrationLifeModeDifficulty()
    {
        ConcentrationGame.concentrationMode = 0;
        concentrationModeWindow.SetActive(false);
        concentrationLifeModeDifficultyWindow.SetActive(true);
    }

    // �_�o����̃^�C���A�^�b�N���[�h�̃��x���I����ʂ�\��
    public void ConcentrationTimeAttackModeDifficulty()
    {
        ConcentrationGame.concentrationMode = 1;
        concentrationModeWindow.SetActive(false);
        concentrationTimeAttackModeDifficultyWindow.SetActive(true);
    }

    public void ConcentrationLevelEasy()
    {
        if (!chackTapButton)
        {
            chackTapButton = true;
            ConcentrationGame.concentrationLevel = (int)Level.easy;
            scenesManager.ConcentrationGameScene();
        }
    }

    public void ConcentrationLevelNormal()
    {
        if (!chackTapButton)
        {
            chackTapButton = true;
            ConcentrationGame.concentrationLevel = (int)Level.normal;
            scenesManager.ConcentrationGameScene();
        }
    }

    public void ConcentrationLevelHead()
    {
        if (!chackTapButton)
        {
            chackTapButton = true;
            ConcentrationGame.concentrationLevel = (int)Level.hard;
            scenesManager.ConcentrationGameScene();
        }
    }
}
