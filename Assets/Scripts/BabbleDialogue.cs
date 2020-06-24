using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabbleDialogue : MonoBehaviour
{
    [SerializeField] private Text _text = null;
    [SerializeField] private GameObject _speechBubble = null;
    [SerializeField] private float _waitTime = 0f;
    [SerializeField] private float _bubbleWaitTime = 0f;
    

    private float _bubbleWait = 0f;
    private float _wait = 0f;
    private int _index = 0;
    private  string[] _statements;
    private Animator _speechBubbleAnim = null;
    private BabbleHolder _babbleHolder = null;
    
    
    void Awake()
    {
        _wait = _waitTime;
        _speechBubbleAnim = GetComponent<Animator>();
        _text.gameObject.SetActive(false);
        _speechBubble.SetActive(true);
        _bubbleWait = _bubbleWaitTime;
        _babbleHolder = GetComponent<BabbleHolder>();
        _statements = _babbleHolder.GetDialogue();
        //AnimationClip clips = anim.runtimeAnimatorController.animationClips;
    }

    void Update()
    {   
        if(_index < _statements.Length){
            _speechBubbleAnim.SetBool("babble", true);
            _bubbleWait -= Time.deltaTime;
            if(_bubbleWait <= 0f){
                _text.gameObject.SetActive(true);
                _text.text = _statements[_index];
                _wait -= Time.deltaTime;
                if(_wait <= 0f){
                    _index++;
                    _wait = _waitTime;
                }
            }
        } else{
            _speechBubbleAnim.SetBool("babble", false);
            _bubbleWait = _bubbleWaitTime;
            _text.gameObject.SetActive(false);
            _babbleHolder.dialogueIndex++;
            _statements = _babbleHolder.GetDialogue();
            _index = 0;
        }
    }   
}
