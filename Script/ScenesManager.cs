using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの管理する処理
/// </summary>
public class ScenesManager : MonoBehaviour
{
    public void TitleScene()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(ChangeTitleScene());
    }

    // タイトル画面に遷移
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

    // 神経衰弱のゲーム画面に遷移
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

    // ハイアンドローのゲーム画面に遷移
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

    // ブラックジャックのゲーム画面に遷移
    private IEnumerator ChangeBlackJackScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("BlackJackScene");
    }
}
