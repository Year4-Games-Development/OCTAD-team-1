using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInputter : MonoBehaviour
{
    public MyGameManager myGameManager;
    private InputField textIn;

    void Awake()
    {
        textIn = GetComponent<InputField>();
    }

    public void OnSubmitted()
    {
        // get text 
        string userText = textIn.text;

        // reset user text to empty string
        textIn.text = "";

        // send text for processing by Game Manager
        myGameManager.ProcessInput(userText);
        
    }

}
