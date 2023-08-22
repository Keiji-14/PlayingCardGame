using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �|�[�Y��ʂ̏���
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameCanvas;

    // �|�[�Y�E�B���h�E��\������
    public void OpenPause()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        gameCanvas.SetActive(false);
    }

    // �|�[�Y�E�B���h�E���\������
    public void ClosePause()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        gameCanvas.SetActive(true);
    }
}
