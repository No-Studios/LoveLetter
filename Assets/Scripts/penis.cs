using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class penis : MonoBehaviour
{
    [SerializeField] private InputField _passwordInput = null;
    [SerializeField] private float _crotchLookTime = 0f;
    [SerializeField] private GameObject _babbleDialogue = null;
    private bool _passwordActive = false;
    public Animation peepee;
    public GameObject cam;
    private bool peenlever = false;
    private float camstart;
    
    


    void start()
    {
        peepee= cam.GetComponent<Animation>();
        camstart = cam.transform.position.y;
        _crotchLookTime = 4.9f;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && _passwordActive == false){
            
            _passwordActive = true;
        } else if(Input.GetKeyDown(KeyCode.Escape) && _passwordActive == true){
            _passwordActive = false;
        }
        if(_passwordActive == true && peenlever == false)
        {
            _passwordInput.gameObject.SetActive(true); 
        } else{
            _passwordInput.gameObject.SetActive(false);
        }

        if(_passwordInput.text == "penis" && peenlever == false && camstart <= cam.transform.position.y+.1 )
        {
            
            _babbleDialogue.SetActive(false);
            peepee.Play("crotchShot");
            _passwordInput.gameObject.SetActive(false);
            peenlever = true;
            //print("fuck yeah dude");
        }
        if(peepee.IsPlaying("crotchShot")){
            _crotchLookTime -= Time.deltaTime;
            if(_crotchLookTime <= 0f){
                _babbleDialogue.SetActive(true);
                _crotchLookTime = 4.9f;
            }
        }
    }
}
