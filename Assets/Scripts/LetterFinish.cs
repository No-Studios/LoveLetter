using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterFinish : MonoBehaviour
{
   [SerializeField] private Animator _letterToss;
   [SerializeField] private GameObject _kiss;

    void Awake()
    {
        _kiss.SetActive(false);
    }
    
    void EndLetter()
    {
        _kiss.SetActive(true);
        _letterToss.SetBool("finished", true);
    }
}
