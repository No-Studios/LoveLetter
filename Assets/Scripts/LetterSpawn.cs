using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private GameObject _letter = null;
    [SerializeField] private float _waitTime = 2f;
    private float _wait = 2f;


    void Update()
    {
        _wait -= Time.deltaTime;
        if(_wait <= 0f){
            Instantiate(_letter, _spawnPoint.position, Quaternion.identity);
            _wait = _waitTime;
        }
    }
}
