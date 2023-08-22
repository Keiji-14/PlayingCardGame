using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �w���v��ʂ̏���
/// </summary>
public class HelpMenu : TitleMenu
{
    [SerializeField] GameObject helpWindow;
    [SerializeField] GameObject highAndLowHelpWindow;
    [SerializeField] GameObject concentrationHelpWindow;
    [SerializeField] GameObject blackJackHelpWindow;

    // �������ڂ�\������
    public void OpenMainHelpMenu()
    {
        gameSelectWindow.SetActive(false);
        helpWindow.SetActive(true);
    }

    // �������ڂ��\������
    public void CloseMainHelpMenu()
    {
        gameSelectWindow.SetActive(true);
        helpWindow.SetActive(false);
    }

    // �n�C�A���h���[�̐�����\������
    public void OpenHighAndLowHelpMenu()
    {
        highAndLowHelpWindow.SetActive(true);
        helpWindow.SetActive(false);
    }

    // �_�o����̐�����\������
    public void OpenConcentrationHelpMenu()
    {
        concentrationHelpWindow.SetActive(true);
        helpWindow.SetActive(false);
    }

    // �u���b�N�W���b�N�̐�����\������
    public void OpenBlackJackHelpMenu()
    {
        blackJackHelpWindow.SetActive(true);
        helpWindow.SetActive(false);
    }

    // �e�Q�[���̐������\������
    public void CloseSubHelpMenu()
    {
        helpWindow.SetActive(true);
        highAndLowHelpWindow.SetActive(false);
        concentrationHelpWindow.SetActive(false);
        blackJackHelpWindow.SetActive(false);
    }
}
