using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ヘルプ画面の処理
/// </summary>
public class HelpMenu : TitleMenu
{
    [SerializeField] GameObject helpWindow;
    [SerializeField] GameObject highAndLowHelpWindow;
    [SerializeField] GameObject concentrationHelpWindow;
    [SerializeField] GameObject blackJackHelpWindow;

    // 説明項目を表示する
    public void OpenMainHelpMenu()
    {
        gameSelectWindow.SetActive(false);
        helpWindow.SetActive(true);
    }

    // 説明項目を非表示する
    public void CloseMainHelpMenu()
    {
        gameSelectWindow.SetActive(true);
        helpWindow.SetActive(false);
    }

    // ハイアンドローの説明を表示する
    public void OpenHighAndLowHelpMenu()
    {
        highAndLowHelpWindow.SetActive(true);
        helpWindow.SetActive(false);
    }

    // 神経衰弱の説明を表示する
    public void OpenConcentrationHelpMenu()
    {
        concentrationHelpWindow.SetActive(true);
        helpWindow.SetActive(false);
    }

    // ブラックジャックの説明を表示する
    public void OpenBlackJackHelpMenu()
    {
        blackJackHelpWindow.SetActive(true);
        helpWindow.SetActive(false);
    }

    // 各ゲームの説明を非表示する
    public void CloseSubHelpMenu()
    {
        helpWindow.SetActive(true);
        highAndLowHelpWindow.SetActive(false);
        concentrationHelpWindow.SetActive(false);
        blackJackHelpWindow.SetActive(false);
    }
}
