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
    [SerializeField] private float _minStatementWaitTime = 5f;
    [SerializeField] private float _maxStatementWaitTime = 5f;
    [SerializeField] private InputField _passwordInput = null;
    
    
    private float _bubbleWait = 0f;
    private float _wait = 0f;
    private float _statementWait = 0f;
    private  string[] _statements = null;
    private Animator _speechBubbleAnim = null;
    private BabbleHolder _babbleHolder = null;
    private bool _passwordActive = false;

    [HideInInspector] public int index = 0;
    [HideInInspector] public bool pause = false;
    
    
    void Awake()
    {
        _wait = _waitTime;
        _speechBubbleAnim = GetComponent<Animator>();
        _text.gameObject.SetActive(false);
        _speechBubble.SetActive(true);
        _bubbleWait = _bubbleWaitTime;
        _babbleHolder = GetComponent<BabbleHolder>();
        _statements = _babbleHolder.GetDialogue();
        _statementWait = 0;
        //AnimationClip clips = anim.runtimeAnimatorController.animationClips;
    }

    void Update()
    {   
        if(_babbleHolder.dialogueIndex < _babbleHolder._dialoguePool.Count - 1 && _passwordActive == false){
            if (pause == false){
                _statementWait -= Time.deltaTime;
            }
            if(_statementWait <= 0f){
                if(index < _statements.Length && pause == false){
                    _speechBubbleAnim.SetBool("babble", true);
                    _bubbleWait -= Time.deltaTime;
                    if(_bubbleWait <= 0f){
                        _text.gameObject.SetActive(true);
                        _text.text = _statements[index];
                        _wait -= Time.deltaTime;
                        if(_wait <= 0f){
                            index++;
                            _wait = _waitTime;
                        }
                    }
                } else if (index >= _statements.Length && pause == false){
                    _speechBubbleAnim.SetBool("babble", false);
                    _bubbleWait = _bubbleWaitTime;
                    _statementWait = Random.Range(_minStatementWaitTime,_maxStatementWaitTime) + _bubbleWait +_wait;
                    _text.gameObject.SetActive(false);
                    _babbleHolder.dialogueIndex++;
                    _statements = _babbleHolder.GetDialogue();
                    index = 0;
                }
            }
        } else{
            pause = true;
        }



        if(Input.GetKeyDown(KeyCode.Escape) && _passwordActive == false){
                _passwordActive = true;
            }else if(Input.GetKeyDown(KeyCode.Escape) && _passwordActive == true){  
                _speechBubbleAnim.SetBool("babble", false);
                _bubbleWait = _bubbleWaitTime;
                _statementWait = Random.Range(_minStatementWaitTime,_maxStatementWaitTime) + _bubbleWait +_wait;
                _passwordInput.gameObject.SetActive(false);
            }

        if (_passwordActive == true){
            if(_speechBubbleAnim.GetBool("babble") == false){
                _speechBubbleAnim.SetBool("babble", true);
                _bubbleWait -= Time.deltaTime;
            }
            if(_bubbleWait <= 0f){
                _passwordInput.gameObject.SetActive(true); 
                if(_passwordInput.text == "penis")
                {
                    print("fuck yeah dude");
                }
            }
        }  
    }
}
    

/*if (index != 0 && _babbleHolder.dialogueIndex < _babbleHolder._dialoguePool.Count){
                    _babbleHolder.dialogueIndex++;
                } else if (index != 0 && _babbleHolder.dialogueIndex > _babbleHolder._dialoguePool.Count){
                    pause = true;
                }*/