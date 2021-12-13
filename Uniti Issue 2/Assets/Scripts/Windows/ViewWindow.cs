// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewWindow : ListWindow<Human>
{
    [SerializeField] private Text _outputField;

    protected void OnEnable()
    {
        _outputField.text = Information.ToString();
    }

    public void Back() => UIManager.CloseWindow<ViewWindow>();
}