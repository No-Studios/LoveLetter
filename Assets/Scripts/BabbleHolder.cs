﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabbleHolder : MonoBehaviour
{
    [SerializeField] private string[] _randDialogue0 = null;
    [SerializeField] private string[] _randDialogue1 = null;
    [SerializeField] private string[] _randDialogue2 = null;
    [SerializeField] private string[] _randDialogue3 = null;
    [SerializeField] private string[] _randDialogue4 = null;
    [SerializeField] private string[] _randDialogue5 = null;

    [SerializeField] private string[] _windowDialogue0 = null;
    [SerializeField] private string[] _windowDialogue1 = null;
    [SerializeField] private string[] _windowDialogue2 = null;

    [SerializeField] private string[] _null = null;
    [SerializeField] private string[] _null0 = null;

    [HideInInspector] public int dialogueIndex = 0;
    //[HideInInspector] public bool up = false;

    private int _index = 0;
    private string[] _dialogueReturn = null;
    
    private BabbleDialogue _babbleDialogue = null;

    [HideInInspector] public List<string[]> _dialoguePool = null;

    void Awake()
    {
        _babbleDialogue = GetComponent<BabbleDialogue>();
        //_dialogueReturn = _IntroDialogue;
        _dialoguePool = new List<string[]>();
        _dialoguePool.Add(_randDialogue0);
        _dialoguePool.Add(_randDialogue1);
        _dialoguePool.Add(_randDialogue2);
        _dialoguePool.Add(_randDialogue3);
        _dialoguePool.Add(_randDialogue4);
        _dialoguePool.Add(_randDialogue5);
        _dialoguePool.Add(_windowDialogue0);
        _dialoguePool.Add(_windowDialogue1);
        _dialoguePool.Add(_windowDialogue2);
        _dialoguePool.Add(_null);
        _dialoguePool.Add(_null0);

    }
    public void Update()
    {
        _dialogueReturn = _dialoguePool[dialogueIndex];
    }

    public string[] GetDialogue()
    {
        return _dialogueReturn;
    }
}
