using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class penis : MonoBehaviour
{
    [SerializeField] private InputField _passwordInput = null;
    private bool _passwordActive = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && _passwordActive == false){
            
            _passwordActive = true;
        } else if(Input.GetKeyDown(KeyCode.Escape) && _passwordActive == true){
            _passwordActive = false;
        }
        if(_passwordActive == true)
        {
            _passwordInput.gameObject.SetActive(true); 
        } else{
            _passwordInput.gameObject.SetActive(false);
        }

        if(_passwordInput.text == "penis")
            {
                print("fuck yeah dude");
            }
    }
}
