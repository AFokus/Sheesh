// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class MainMenu : Window
{
    public void AddHuman()
    {
        UIManager.OpenWindow<ChooseMenu>();
    }

    public void Exit()
    {
        Close();
        Application.Quit();
    }
}
