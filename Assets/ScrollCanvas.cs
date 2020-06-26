using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCanvas : MonoBehaviour
{

    public float deltaY = 3.55f;
    public float deltaZ = 1f;
    public float multiplier = 4;
    public Vector3 originalPosition; 

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
        }   
    }

    public void MoveCanvas()
    {
        this.GetComponent<RectTransform>().transform.position = new Vector3(this.GetComponent<RectTransform>().transform.position.x, this.GetComponent<RectTransform>().transform.position.y + deltaY, this.GetComponent<RectTransform>().transform.position.z + deltaZ);
    }

    public void MoveCanvasBack()
    {
        this.GetComponent<RectTransform>().transform.position = new Vector3(this.GetComponent<RectTransform>().transform.position.x, this.GetComponent<RectTransform>().transform.position.y - deltaY, this.GetComponent<RectTransform>().transform.position.z - deltaZ);

    }
}
