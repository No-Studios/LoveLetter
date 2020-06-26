using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class TextHandler : MonoBehaviour
{

    public GameObject parent; 
    public TextPanel panel;
    public List<string> words;
    int current_word_index = 0;
    int current_space_index = 0; 
    bool panel_start = true;
    public GameObject template_panel;
    public WritingParser wp; 
    private GameObject current_panel;
    int panel_count = 0;

    List<int> space_in_line;

    public TMP_Text tmptext; 




    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("AddToPanel", 1f, .25f);
        //words = wp.parsedWords; 



        CreateWordList(0);
    }

    public void CreateWordList(int currentLetter)
    {
        words = new List<string>();

        foreach (string w in wp.parsedWords[currentLetter])
        {
            words.Add(w);

        }
        panel_start = true;
        current_word_index = 0;
        panel_count = 0;
        TypeInput[] ip = FindObjectsOfType<TypeInput>();
        foreach (TypeInput t in ip) {
            Destroy(t.transform.parent.gameObject);
        }


        while (current_word_index < words.Count)
        {
            if (panel_start)
            {
                space_in_line = new List<int>();
                Debug.Log("create");
                panel_start = false;
                current_panel = Instantiate(template_panel);

                current_panel.transform.SetParent(parent.transform, false);
                panel = current_panel.GetComponent<TextPanel>();
                panel.order_num = panel_count;
                panel.user_panel.orderNum = panel.order_num;

            }
            else
            {
                for (int i = current_word_index; i <= words.Count; i++)
                {
                    current_word_index = i;
                    if (current_word_index == words.Count)
                    {
                        break;
                    }

                    Debug.Log(panel);
                    TMP_Text tempText = panel.panel_text;
                    string beforeChange = panel.panel_text.text;
                    tempText.text += words[current_word_index];

                    tempText.ForceMeshUpdate();

                    if (words[current_word_index].Contains("\n"))
                    {
                        string[] b = words[current_word_index].Split('\n');
                        panel.panel_text.text = beforeChange + b[0];
                        words.Insert(current_word_index + 1, b[1]);
                        panel_start = true;
                        panel_count++;
                        current_word_index++;
                        break;
                    }
                    else if (tempText.isTextOverflowing && !words[current_word_index].Contains("\n"))
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



                    if (i != words.Count - 1)
                    {
                        panel.panel_text.text += " ";
                    }

                    panel.panel_text = tempText;

                }
                if (current_word_index == 150)
                {
                    break;
                }

            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void AddToPanel()
    {
        panel.panel_text.text += "1";
    }
}
