using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �V�[���̊Ǘ����鏈��
/// </summary>
public class ScenesManager : MonoBehaviour
{
    public void TitleScene()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(ChangeTitleScene());
    }

    // �^�C�g����ʂɑJ��
    private IEnumerator ChangeTitleScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("TitleScene");
    }

    public void ConcentrationGameScene()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(ChangeConcentrationGameScene());
    }

    // �_�o����̃Q�[����ʂɑJ��
    private IEnumerator ChangeConcentrationGameScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("ConcentrationGameScene");
    }

    public void HighAndLowScene()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(ChangeHighAndLowScene());
    }

    // �n�C�A���h���[�̃Q�[����ʂɑJ��
    private IEnumerator ChangeHighAndLowScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("HighAndLowScene");
    }

    public void BlackJackScene()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(ChangeBlackJackScene());
    }

    // �u���b�N�W���b�N�̃Q�[����ʂɑJ��
    private IEnumerator ChangeBlackJackScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("BlackJackScene");
    }
}
