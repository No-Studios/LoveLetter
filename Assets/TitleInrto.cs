using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleInrto : MonoBehaviour
{
    Animator anim;
    public SceneSwitch sc; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTitle()
    {
        anim.SetTrigger("Show");
    }

    public void PlayGame()
    {
        sc.SwitchScene();
    }
}
