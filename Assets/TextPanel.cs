using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TextPanel : MonoBehaviour
{
    public TMP_Text panel_text;
    public bool overflow = false;
    

    public int order_num = 0;
    public TypeInput user_panel;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (panel_text.isTextOverflowing)
        {
            overflow = true; 
        }
        else
        {
            overflow = false; 
        }
    }
}
