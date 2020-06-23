using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class TextHandler : MonoBehaviour
{

    public GameObject parent; 
    public TextPanel panel;
    public string[] words = {"yo", "bling", "blick", "bah", "hi", "why", "guy", "die!", "fry", "buy" };
    int current_word_index = 0;
    int current_space_index = 0; 
    bool panel_start = true;
    public GameObject template_panel; 
    private GameObject current_panel;
    int panel_count = 0;

    List<int> space_in_line;




    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("AddToPanel", 1f, .25f);

        
        while (current_word_index < words.Length)
        {
            if (panel_start)
            {
                space_in_line = new List<int>(); 
                Debug.Log("create");
                panel_start = false;
                current_panel = Instantiate(template_panel);

                current_panel.transform.SetParent(parent.transform,false); 
                panel = current_panel.GetComponent<TextPanel>();
                panel.order_num = panel_count;
                panel.user_panel.orderNum = panel.order_num; 

            }
            else
            {
                for(int i = current_word_index; i <= words.Length; i++)
                {
                    current_word_index = i;
                    if (current_word_index == words.Length)
                    {
                        break;
                    }
                    
                    Debug.Log(panel);
                    TMP_Text tempText = panel.panel_text;
                    string beforeChange = panel.panel_text.text;
                    tempText.text += words[current_word_index];

                    tempText.ForceMeshUpdate();
                    if (tempText.isTextOverflowing)
                    {
                        Debug.Log("Overflow at " + words[current_word_index]);
                        panel.panel_text.text = beforeChange;
                        GameManager.instance.space_breaks.Add(space_in_line);
                        current_space_index = 0; 
                        //current_word_index -= 1; 
                        panel_start = true;
                        panel_count++; 
                        break; 
                    }
                    

                    if(i != words.Length - 1)
                    {
                        panel.panel_text.text += " ";
                       /*
                        Debug.Log(current_word_index);
                        if (current_space_index == 0)
                        {
                            space_in_line.Add(words[current_word_index].Length);
                        }
                        else
                        {
                            Debug.Log("space in line: " + space_in_line.Count + " / " + current_space_index);
                            Debug.Log("words: " + words.Length + "/" + current_word_index);
                            space_in_line.Add(words[current_word_index].Length + space_in_line[current_space_index] + 1);
                            current_space_index++;
                        }
                       */
                        //Debug.Log("Text overflowing = " + panel.panel_text.isTextOverflowing);
                    }

                    panel.panel_text = tempText;

                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        while (current_word_index < words.Length)
        {
            if (panel_start)
            {
                Debug.Log("Create");
                panel_start = false;
                current_panel = Instantiate(template_panel);

                current_panel.transform.SetParent(parent.transform, false);
                panel = current_panel.GetComponent<TextPanel>();

            }
            else
            {
                for (int i = current_word_index; i < words.Length; i++)
                {
                    current_word_index = i;
                    //Debug.Log(panel);
                    TMP_Text tempText = panel.panel_text;
                    tempText.text += words[current_word_index];

                    if (tempText.isTextOverflowing)
                    {
                        Debug.Log("Overflow at " + words[current_word_index]);

                        //current_word_index -= 1; 
                        panel_start = true;
                        break;
                    }


                    if (i != words.Length - 1)
                    {
                        panel.panel_text.text += " ";
                        Debug.Log("Text overflowing = " + panel.panel_text.isTextOverflowing);
                    }

                    panel.panel_text = tempText;

                    if (panel.panel_text.isTextOverflowing)
                    {
                        Debug.Log("Overflow at " + words[current_word_index]);
                    }
                }
                if (current_word_index == words.Length - 1)
                {
                    current_word_index = words.Length;
       
                }

            }
        }*/
    }

    public void AddToPanel()
    {
        panel.panel_text.text += "1";
    }
}
