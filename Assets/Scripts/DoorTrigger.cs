using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    string Filename;
    [SerializeField]
    int[] QLineNumbers;
    [SerializeField]
    int ALineNumber;
    String Answer="";
    String Question="";
    String ans = "";
    bool inside;
    public Text question;
    public InputField answer;
    public GameObject player;
    public GameObject canvas;
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Filename))
        {
            string[] lines = File.ReadAllLines(Filename);
            Question = "";
            foreach (int number in QLineNumbers)
            {
                Question += lines[number] + "\n";
            }
            Answer = lines[ALineNumber];
        }
        else
        {
            Question = "Question Not Found";
            Answer = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(answer.text == Answer && inside)
        {
            OpenDoor();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<CharacterController>())
        {
            UIDisplayer(true);
            SetQuestion();
            inside = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == player.GetComponent<CharacterController>())
        {
            UIDisplayer(false);
            inside = false;
        }
    }
    private void UIDisplayer(bool status)
    {
        canvas.GetComponent<Canvas>().enabled = status;
    }
    // Modify the UI to print questions
    private void SetQuestion()
    {
        question.text = Question;
    }
    private void OpenDoor()
    {
        Door.SetActive(false);
    }
}
