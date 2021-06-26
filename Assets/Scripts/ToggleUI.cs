using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{
    public GameObject game;
    private Canvas canvasObject;
    private bool inputMode = false;
    public InputField ansField;
    string t="";
    // Start is called before the first frame update
    void Start()
    {
        canvasObject = game.GetComponent<Canvas>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            canvasObject.enabled = !canvasObject.enabled;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputMode = !inputMode;
            // Clear InputField when input mode is toggled
            t = "";
            ansField.SetTextWithoutNotify(t);
        }
        if (inputMode && canvasObject.enabled)
        {
            foreach (char c in Input.inputString)
            {
                if (c == '\b') // has backspace/delete been pressed?
                {
                    if (t.Length != 0)
                    {
                        t = t.Substring(0, t.Length - 1);
                    }
                }
                else if ((c == '\n') || (c == '\r')) // enter/return
                {

                }
                else
                {
                    t += c;
                }
            }
            ansField.SetTextWithoutNotify(t);
        }
    }
}