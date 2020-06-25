using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TypeInput : MonoBehaviour
{

    public TMP_Text text;
    public TextPanel txtPnl; 
    public bool isCurrentBox = false;
    public int orderNum;
    public int currentChar = 0; 
    public int currentSpaceBreak = 0;
    public TextHandler txtHandler;
    List<bool> wordCheck;
    List<string> typedLetters;
    List<string> typedDisplay; 
    bool wordCheckCreated = false;
    public bool wordChanged = false; 
    string actualType = "";
    public bool goingToNextLine = false;
    public bool removingLast = false; 
    // Start is called before the first frame update
    void Start()
    {
        typedLetters = new List<string>();
        wordCheck = new List<bool>(); 
        txtHandler = GameManager.instance.txtHanlder; 
    }

    // Update is called once per frame
    void Update()
    {




        if (isCurrentBox)
        {
            foreach (char letter in Input.inputString)
            {
                /*
                if (currentChar == txtPnl.panel_text.text.Length - 2)
                {
                    Debug.Log("going to next line");
                    Debug.Log(txtPnl.panel_text.text.Length);
                    goingToNextLine = true; 

                }
                */
                if (letter == '\b') // has backspace/delete been pressed?
                {
                    if (text.text.Length != 0 && !removingLast)
                    {
                        Debug.Log("removing");
                        typedLetters.RemoveAt(typedLetters.Count - 1);
                        //typedDisplay.RemoveAt(typedDisplay.Count - 1);
                        //text.text = text.text.Substring(0, text.text.Length - 1);
                        currentChar--;
                    }

                    else if (orderNum != 0 && text.text.Length == 0)
                    {
                        Debug.Log("Ordern Num " + orderNum);
                        GameManager.instance.ActivatePanel(orderNum - 1, true);
                        break;
                    }
                    wordChanged = true; 
                }
                else if (letter != '\n')
                {


                        if (letter != txtPnl.panel_text.text[currentChar])
                        {
                            typedLetters.Add("<color=red>" + letter + "</color>");
                        }
                        else
                        {
                            typedLetters.Add("" + letter);
                        }
                        currentChar++;

                        if (currentChar == txtPnl.panel_text.text.Length - 1)
                        {
                            GameManager.instance.ActivatePanel(orderNum + 1, false);
                        }
                        wordChanged = true;

                    


                    //typedLetters.Add(""+letter);
                    //typedDisplay.Add("" + letter);


                }
                
            }

            if (wordChanged)
            {
                string newString = ""; 
                foreach (string l in typedLetters)
                {
                    newString += l;
                }
                text.text = newString;
                //if(goingToNextLine == true
                wordChanged = false; 
            }
        }
    }

    public void RemoveLast()
    {
        typedLetters.RemoveAt(typedLetters.Count - 1);
        wordChanged = true;
        currentChar--;
        removingLast = false; 
    }
}
