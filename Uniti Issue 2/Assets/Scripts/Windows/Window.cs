// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private bool _isActive = false;
    
    private void Awake()=> gameObject.SetActive(false);

    public void Open()
    {
        if (_isActive) return;
        
        gameObject.SetActive(true);
        _isActive = true;
    }

    public void Close()
    {
        if(!_isActive) return;
        
        gameObject.SetActive(false);
        _isActive = false;
    }
}

public abstract class ListWindow<T> : Window 
{
    public int Id { get; private set; }
    public T Information { get; private set; }
    
    public virtual void SetData(int id,T info)
    {
        Id = id;
        Information = info;
    }
}