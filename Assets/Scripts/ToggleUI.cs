using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject game;
    private Canvas canvasObject;
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
    }
}
