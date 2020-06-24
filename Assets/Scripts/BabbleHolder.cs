using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabbleHolder : MonoBehaviour
{
    [SerializeField] private string[] _dialogue0 = null;
    [SerializeField] private string[] _dialogue1 = null;
    [SerializeField] private string[] _dialogue2 = null;
    [HideInInspector] public int dialogueIndex = 0;

    // Update is called once per frame
    public string[] GetDialogue()
    {
        if (dialogueIndex == 0){
            return _dialogue0;
        } else if (dialogueIndex == 1)
        {
            return _dialogue1;
        } else
        {
            return _dialogue2;
        }

    }
}
