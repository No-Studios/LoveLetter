using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq; 
using UnityEngine;

public class WritingParser : MonoBehaviour
{
    public string fileName;
    public string[] fileNames;
    public List<List<string>> parsedWords;
    // Start is called before the first frame update
    private void Awake()
    {
        parsedWords = new List<List<string>>();
        foreach (string f in fileNames)
        {
            parsedWords.Add(File.ReadAllText("Assets/" + f + ".txt").Split(' ').ToList());
        }

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
