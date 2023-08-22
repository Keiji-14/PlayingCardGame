using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ポーズ画面の処理
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameCanvas;

    // ポーズウィンドウを表示する
    public void OpenPause()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        gameCanvas.SetActive(false);
    }

    // ポーズウィンドウを非表示する
    public void ClosePause()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        gameCanvas.SetActive(true);
    }
}
