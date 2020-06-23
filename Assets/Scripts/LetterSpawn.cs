using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private GameObject[] _letter = null;
    [SerializeField] private float _waitTime = 2f;
    private float _wait = 2f;
    private int _index = 0;

    void Update()
    {
        _wait -= Time.deltaTime;
        if(_wait <= 0f){
            _index = Random.Range(0,4);
            Instantiate(_letter[_index], _spawnPoint.position, Quaternion.identity);
            _wait = _waitTime;
        }
    }
}
