using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    public Text textOut;
    public InputField textIn;
    private CommandParser commandParser;    
    

    void Awake()
    {
        commandParser = new CommandParser();
        textOut.text = Util.Message(Util.Type.Start);

        Debug.Log("updated screen text with: " + Util.Message(Util.Type.Start));
    }

    public void ProcessInput(string userText)
    {
        // add user text to output history
        textOut.text += "\n >" + Util.ColorText(userText, "red");

        /*
         * TODO: extend for commands with 2 or more words ...
         */
        // get command Type from text
        CommandParser.Command command = commandParser.Parse(userText);
        
        // process that command
        ProcessUserCommand(command);
        
        // set input field with Focus - ready for next user input
        textIn.Select();
        textIn.ActivateInputField();
    }

    private void ProcessUserCommand(CommandParser.Command c)
    {
        string message;
        switch(c)
        {
            case CommandParser.Command.Quit:
                message = "user wants to QUIT";
                break;
            case CommandParser.Command.Help:
                message = Util.Message(Util.Type.Help);
                break;
            case CommandParser.Command.Unknown:
            default:
                message = Util.Message(Util.Type.Unknown);
                break;
        }

        textOut.text += "\n" + message;
    }

}
