using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public GameObject cam;
    private Animation cameraShift;
    private bool down = true;

    // Start is called before the first frame update
    void Start()
    {
        cameraShift = cam.GetComponent<Animation>();
        //cameraShift["camera"].normalizedSpeed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) & down == true)
        {
            //Debug.Log("u");
            cameraShift["camera"].normalizedTime = 0.0f;
            
            //cameraShift["camera"].normalizedSpeed = 1.0f;
            cameraShift.Play("camera");
            
            //cameraShift.Stop();
            
            down = false;

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) & down == false)
        {
           // Debug.Log("d");
            cameraShift["camera"].normalizedTime = 0.5f;

            //cameraShift["camera"].normalizedSpeed = 1.0f;
            cameraShift.Play("camera");
           
            //cameraShift.Stop();
            
            down = true;
        }



    }
}
