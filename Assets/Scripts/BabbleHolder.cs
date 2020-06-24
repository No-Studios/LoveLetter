using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabbleHolder : MonoBehaviour
{
    [SerializeField] private string[] _IntroDialogue = null;
    [SerializeField] private string[] _IntroDialogue0 = null;
    [SerializeField] private string[] _randDialogue1 = null;
    [SerializeField] private string[] _randDialogue2 = null;
    [SerializeField] private string[] _randDialogue3 = null;
    [SerializeField] private string[] _randDialogue4 = null;
    [SerializeField] private string[] _randDialogue5 = null;

    [SerializeField] private string[] _windowDialogue0 = null;
    [SerializeField] private string[] _windowDialogue1 = null;
    [SerializeField] private string[] _windowDialogue2 = null;

    [HideInInspector] public int dialogueIndex = 0;
    private string[] _dialogueReturn;

    void Update()
    {

    }
    public string[] GetDialogue()
    {
        if (dialogueIndex == 0){
            return _IntroDialogue;
        } else if (dialogueIndex == 1)
        {
            return _randDialogue1;
        } else
        {
            return _randDialogue2;
        }

    }
}
