using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TextReader : MonoBehaviour
{
    [SerializeField]
    string Filename = "";
    [SerializeField]
    int[] LineNumbers = { };
    string RootFolder = "";
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Filename))
        {
            string[] lines = File.ReadAllLines(Filename);
            string Question = "";
            foreach(int number in LineNumbers)
            {
                Question += lines[number] + "\n";
            }
            GetComponent<Text>().text = Question;
        }
        else
        {
            GetComponent<Text>().text = "Question Not Found";
        }
    }
}
