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
    bool wordChanged = false; 
    string actualType = "";
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
                if (letter == '\b') // has backspace/delete been pressed?
                {
                    if (text.text.Length != 0)
                    {
                        typedLetters.RemoveAt(typedLetters.Count - 1);
                        //typedDisplay.RemoveAt(typedDisplay.Count - 1);
                        //text.text = text.text.Substring(0, text.text.Length - 1);
                        currentChar--;
                    }
                }
                else
                {
                    if(letter != txtPnl.panel_text.text[currentChar])
                    {
                        typedLetters.Add("<color=red>" + letter + "</color>");
                    }
                    else
                    {
                        typedLetters.Add("" + letter);
                    }
                    //typedLetters.Add(""+letter);
                    //typedDisplay.Add("" + letter);
                    currentChar++;
                    
                }
                wordChanged = true;
            }

            if (wordChanged)
            {
                string newString = ""; 
                foreach (string l in typedLetters)
                {
                    newString += l;
                }
                text.text = newString;
                wordChanged = false; 
            }
            /*
            if(currentChar >= GameManager.instance.space_breaks[orderNum][currentSpaceBreak])
            {
                Debug.Log("current text" + text.text);
                //Debug.Log("currentChar " + currentChar + "currentSpace)
                if (currentSpaceBreak == 0 && text.text.Substring(currentSpaceBreak, GameManager.instance.space_breaks[orderNum][currentSpaceBreak]) != txtHandler.words[currentSpaceBreak])
                {
                    string first = text.text.Insert(GameManager.instance.space_breaks[orderNum][currentSpaceBreak] - 1, "</color>");
                    string second = text.text.Insert(currentSpaceBreak, "<color=red>");
                    text.text = second; 
                }
                else if (text.text.Substring(GameManager.instance.space_breaks[orderNum][currentSpaceBreak] + 1, GameManager.instance.space_breaks[orderNum][currentSpaceBreak]) != txtHandler.words[currentSpaceBreak])
                {
                    string first = text.text.Insert(GameManager.instance.space_breaks[orderNum][currentSpaceBreak] - 1, "</color>");
                    string second = text.text.Insert(currentSpaceBreak, "<color=red>");
                    text.text = second;
                }
                currentSpaceBreak++; 

            }
            if(currentSpaceBreak != 0 && currentChar < GameManager.instance.space_breaks[orderNum][currentSpaceBreak - 1])
            {
                currentSpaceBreak--; 
            }*/

        }
    }
}
