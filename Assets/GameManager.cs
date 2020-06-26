using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TypeInput[] input_panels;
    public TypeInput prev_panel; 
    [SerializeField]
    int current_input_panel = 0;
    [SerializeField]
    public int change_input_panel = 0;
    TypeInput current_panel;

    bool input_panels_found = false;
    public List<List<int>> space_breaks;

    public TextHandler txtHanlder; 
    public static GameManager instance = null;
    public ScrollCanvas sc;

    public int currentLetter = 0; 
    public LetterFinish finLetter; 
    public bool changing = false; 



    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
        space_breaks = new List<List<int>>();
        

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!input_panels_found)
        {
            input_panels = FindObjectsOfType<TypeInput>();
            foreach(TypeInput p in input_panels)
            {
                if(p.orderNum == 0)
                {
                    p.transform.parent.gameObject.SetActive(true);
                    current_panel = p; 
                 
                    p.isCurrentBox = true; 
                }
                else
                {
                    p.transform.parent.gameObject.SetActive(false);
                }

            }
            input_panels_found = true; 

        }

        /*
        if(current_input_panel != change_input_panel)
        {
            input_panels[current_input_panel].isCurrentBox = false;

            TypeInput foundpanel = FindPanel(change_input_panel);


            
            current_input_panel = change_input_panel;
            foundpanel.isCurrentBox = true; 

        }
        */
    }

    private TypeInput FindPanel(int orderNum)
    {
        foreach(TypeInput t in input_panels)
        {
            if(t.orderNum == orderNum)
            {
                return t; 
            }
        }
        return null; 
    }
    
    public void ActivatePanel(int orderNum, bool backwards)
    {
        current_panel.isCurrentBox = false;
        current_input_panel = orderNum;
        prev_panel = current_panel;
        current_panel = FindPanel(orderNum);
        current_panel.isCurrentBox = true;
        if(current_input_panel == input_panels.Length - 1)
        {
            Debug.Log("Helllo");
            EndLetter();
            return;
        }
        else
        {
            Debug.Log("Naw");
        }

        if (backwards)
        {
            //current_panel.currentChar--;
            prev_panel.transform.parent.gameObject.SetActive(false);
            current_panel.RemoveLast();
            current_panel.goingToNextLine = false;
            if(current_input_panel % 4 == 0 && orderNum != 0)
            {
                Debug.Log("going back " + orderNum);
                sc.MoveCanvasBack();

            }
            //sc.multiplier -= 2; 
        }
        else
        {

            current_panel.transform.parent.gameObject.SetActive(true);
            changing = true;
            prev_panel.removingLast = true;
            if(orderNum % 4 == 0 && orderNum != 0)
            {
                sc.MoveCanvas();
            }
            
            //sc.multiplier += .2f; 

        }
    }

    public void EndLetter()
    {
        //finLetter.EndLetter();
        GoToNextLetter();
        
    }

    public void GoToNextLetter()
    {
        currentLetter++; 
        current_input_panel = 0;
        txtHanlder.CreateWordList(currentLetter);
        sc.transform.position = sc.originalPosition; 
        input_panels_found = false;

    }

    
}
