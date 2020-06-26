using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public GameObject cam;
    private Animation cameraShift;
    private bool down = true;
    bool canPress = true;
    public GameObject windowUi;
    public GameObject deskUi;
    public bool typeMode = false;
    public bool goToLetterView = false;
    public GameObject ZoomButton;
    public GameObject RegButton;

    // Start is called before the first frame update
    void Start()
    {
        cameraShift = cam.GetComponent<Animation>();
        //cameraShift["camera"].normalizedSpeed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (!typeMode)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) & down == true & canPress == true)
            {
                canPress = false;
                windowUi.SetActive(false);
                deskUi.SetActive(true);
                //Debug.Log("u");
                cameraShift["camera"].normalizedTime = 0.0f;

                //cameraShift["camera"].normalizedSpeed = 1.0f;
                cameraShift["camera"].normalizedSpeed = .25f;
                cameraShift.Play("camera");


                //cameraShift.Stop();

                down = false;

            }

            if (Input.GetKeyDown(KeyCode.DownArrow) & down == false & canPress == true)
            {
                canPress = false;
                // Debug.Log("d");
                windowUi.SetActive(true);
                deskUi.SetActive(false);

                cameraShift["camera"].normalizedTime = 0.5f;

                cameraShift["camera"].normalizedSpeed = .25f;
                //cameraShift.Play("camera");

                //cameraShift.Stop();

                down = true;
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log("type cam");
                cameraShift.Play("TypingCamZoom");
                typeMode = true;
                //goToLetterView = true;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                cameraShift.Play("typeToReg");
                typeMode = false;
                //goToLetterView = false;
            }
        }




    }
    private void stopAnim()
    {
        cameraShift["camera"].normalizedSpeed = 0.0f;
        canPress = true;

    }

    public void GoToLetterVoid()
    {
        cameraShift.Play("TypingCamZoom");
        ZoomButton.SetActive(false);
        RegButton.SetActive(true);
        typeMode = false;
    }
    
    public void ExitLetterView()
    {
        cameraShift.Play("typeToReg");
        ZoomButton.SetActive(true);
        RegButton.SetActive(false);
        typeMode = false;
    }
}
