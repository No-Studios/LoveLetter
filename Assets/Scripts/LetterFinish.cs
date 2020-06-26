using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterFinish : MonoBehaviour
{
   [SerializeField] private Animator _letterToss;
   [SerializeField] private GameObject _kiss;
   [SerializeField] private LetterSpawn _letterSpawn;

    void Awake()
    {
        _kiss.SetActive(false);
    }
    
    public void EndLetter()
    {
        _kiss.SetActive(true);
        _letterToss.SetBool("finished", true);
        _letterSpawn.SpawnLetter();
    }
}
