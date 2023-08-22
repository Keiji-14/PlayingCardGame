using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトル画面の処理
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
        // 同時押しした時に最初に押したほうを優先させる
        chackTapButton = false;
    }

    public void TapStart()
    {
        titleWindow.SetActive(false);
        gameSelectWindow.SetActive(true);
    }

    // 神経衰弱のモード選択画面を表示
    public void ConcentrationMode()
    {
        gameSelectWindow.SetActive(false);
        concentrationModeWindow.SetActive(true);

        // 神経衰弱のレベル選択画面から戻る時に非表示
        concentrationLifeModeDifficultyWindow.SetActive(false);
        concentrationTimeAttackModeDifficultyWindow.SetActive(false);
    }

    public void GameSelect()
    {
        concentrationModeWindow.SetActive(false);
        gameSelectWindow.SetActive(true);
    }

    // 神経衰弱のライフモードのレベル選択画面を表示
    public void ConcentrationLifeModeDifficulty()
    {
        ConcentrationGame.concentrationMode = 0;
        concentrationModeWindow.SetActive(false);
        concentrationLifeModeDifficultyWindow.SetActive(true);
    }

    // 神経衰弱のタイムアタックモードのレベル選択画面を表示
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
