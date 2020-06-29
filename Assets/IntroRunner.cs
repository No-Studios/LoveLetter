using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroRunner : MonoBehaviour
{

    public int currentSprite = 0;
    public Animator anim; 
    public List<GameObject> introSprites;
    bool runningIntro = false;
    public TitleInrto ti; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunIntro()
    {
        if (runningIntro)
        {
            if (currentSprite == introSprites.Count - 1)
            {
                ti.ShowTitle();
                runningIntro = false;
            }
            else
            {
                anim.SetTrigger("FadeOut");
            }
            //introSprites[currentSprite].SetActive(false);
            //introSprites[currentSprite + 1].SetActive(true);
            //currentSprite++;
        }
    }

    public void StartIntro()
    {
        runningIntro = true; 
    }

    public void SwitchPic()
    {
        introSprites[currentSprite].SetActive(false);
        introSprites[currentSprite + 1].SetActive(true);
        currentSprite++;

    }
}
