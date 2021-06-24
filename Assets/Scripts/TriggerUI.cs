using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUI : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other == player.GetComponent<CharacterController>())
        {
            UIDisplayer(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other == player.GetComponent<CharacterController>())
        {
            UIDisplayer(false);
        }
    }
    private void UIDisplayer(bool status)
    {
        canvas.GetComponent<Canvas>().enabled = status;
    }
}
