using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TypeInput[] input_panels;
    int current_input_panel = 0;

    bool input_panels_found = false;
    public List<List<int>> space_breaks;

    public TextHandler txtHanlder; 
    public static GameManager instance = null; 



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
                    p.isCurrentBox = true; 
                }
            }
            input_panels_found = true; 

        }

    }
}
