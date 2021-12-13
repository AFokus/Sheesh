// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using UnityEngine;

public class UIListManager : Singleton<UIListManager>
{
    [SerializeField] private Transform _content;
    [SerializeField] private ListWindow<Human> _listItemPrefab;

    private List<ListWindow<Human>> _listItems;

    public int Count() => _listItems.Count;

    protected void Awake()
    {
        UIListManager.Instance._listItems = new List<ListWindow<Human>>();

        //It's just for creating an instance
        Instance.Count();
    }

    public static void CreateWindow(Human human)
    {
        var newHuman = Instantiate(UIListManager.Instance._listItemPrefab, UIListManager.Instance._content, true);
        UIListManager.Instance._listItems.Add(newHuman);
        newHuman.SetData(Instance.Count(),human);
    }

    public static void ModifyWindow(int id, Human human) =>
        UIListManager.Instance._listItems.Find(window => window.Id == id).SetData(id, human);

    public static void DestroyWindow(int id)
    {
        var deletable = UIListManager.Instance._listItems.Find(window => window.Id == id);
        Destroy(deletable.gameObject);
        UIListManager.Instance._listItems.Remove(deletable);
    }
}