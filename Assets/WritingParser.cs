using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq; 
using UnityEngine;

public class WritingParser : MonoBehaviour
{
    public string fileName; 
    public List<string> parsedWords;
    // Start is called before the first frame update
    private void Awake()
    {
        parsedWords = File.ReadAllText("Assets/" + fileName + ".txt").Split(' ').ToList();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
