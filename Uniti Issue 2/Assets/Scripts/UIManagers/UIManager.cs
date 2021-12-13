// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private List<Window> _prefabs;

    private Dictionary<Type, Window> _associativeMapOfPrefabs;

    private Stack<Window> _queueOfWillOpenedWindow;

    protected void Awake()
    {
        _associativeMapOfPrefabs = new Dictionary<Type, Window>();
        _queueOfWillOpenedWindow = new Stack<Window>();
        
        foreach (var prefab in _prefabs)
        {
            var window = Instantiate(prefab, _mainCanvas.transform, false);
            _associativeMapOfPrefabs.Add(window.GetType(),window);
        }
        
        OpenWindow<MainMenu>();
    }

    public static Window GetWindow<T>() where T : Window => Instance._associativeMapOfPrefabs[typeof(T)];

    public static void OpenWindow<T>() where T : Window
    {
        // Closing any window before opening new
        CloseWindowsProcess();
        
        Instance._associativeMapOfPrefabs[typeof(T)].Open();
    }

    public static void OpenListWindow<T, TData>(int id, TData data) where T : ListWindow<TData>
    {
        ((ListWindow<TData>)Instance._associativeMapOfPrefabs[typeof(T)]).SetData(id, data);
        OpenWindow<T>();
    }
    
    private static void CloseWindowsProcess()
    {
        foreach (var window in Instance._associativeMapOfPrefabs.Where(window => window.Value.isActiveAndEnabled))
        {
            window.Value.Close();
            Instance._queueOfWillOpenedWindow.Push(window.Value);
        }
    }

    public static void CloseWindow<T>() where T: Window
    {
        Instance._associativeMapOfPrefabs[typeof(T)].Close();
        var window = Instance._queueOfWillOpenedWindow.Pop();
        window?.Open();
    }
}
