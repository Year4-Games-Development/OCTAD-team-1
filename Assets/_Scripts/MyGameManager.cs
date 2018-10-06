using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    public Text textOut;
    public InputField textIn;
    private CommandParser commandParser;

    private Map map;

    private Location currentLocation;

    void Awake()
    {
        map = new Map();
        commandParser = new CommandParser();
    }

    private void Start()
    {
        ShowMessage("Loading game map ....");

        ChangeLocation(map.GetStartLocation());
    }

    public void ProcessInput(string userText)
    {
        // add user text to output history
        string userTextColored =  "\n >" + Util.ColorText(userText, "red");
        ShowMessage(userTextColored);

        // get command Type from text
        CommandAndOtherWords commandNounPair = commandParser.Parse(userText);

        Util.Command command = commandNounPair.command;

        switch (commandNounPair.numWords)
        {
            case 1:
                // process that command
                ProcessSingleWordUserCommand(command);
                break;

            case 2:
            default:
                // process that command
                ProcessMultiWordUserCommand(commandNounPair);
                break;
        }

        // set input field with Focus - ready for next user input
        textIn.Select();
        textIn.ActivateInputField();
    }

    private void ProcessMultiWordUserCommand(CommandAndOtherWords commandNounPair)
    {
        ShowMessage("sorry - I don't know how to process 2(or more)-word commands yet");
    }

    private void ProcessSingleWordUserCommand(Util.Command c)
    {
        string message;
        switch(c)
        {
            case Util.Command.Quit:
                message = "user wants to QUIT";
                break;
            case Util.Command.Look:
                message = currentLocation.GetFullDescription();
                break;
            case Util.Command.Help:
                message = Util.Message(Util.Type.Help);
                break;
            case Util.Command.North:
                if (null != currentLocation.exitNorth)
                {
                    message = Util.Message(Util.Type.North);
                    ChangeLocation(currentLocation.exitNorth);                    
                }
                else
                {
                    message = "Sorry - there is no exit to the North";
                }
                break;
            case Util.Command.South:
                if (null != currentLocation.exitSouth)
                {
                    message = Util.Message(Util.Type.South
                    );
                    ChangeLocation(currentLocation.exitSouth);                    
                }
                else
                {
                    message = "Sorry - there is no exit to the South";
                }
                break;
            case Util.Command.East:
                if (null != currentLocation.exitEast)
                {
                    message = Util.Message(Util.Type.East
                    );
                    ChangeLocation(currentLocation.exitEast);                    
                }
                else
                {
                message = "Sorry - there is no exit to the East";
                }
                break;
            case Util.Command.West:
                if (null != currentLocation.exitWest)
                {
                    message = Util.Message(Util.Type.West
                    );
                    ChangeLocation(currentLocation.exitWest);                    
                }
                else
                {
                message = "Sorry - there is no exit to the West";
                }
                break;
            case Util.Command.Unknown:
            default:
                message = Util.Message(Util.Type.Unknown);
                break;
        }

        ShowMessage(message);
    }

    private void ChangeLocation(Location newLocation)
    {
        currentLocation = newLocation;        
        currentLocation.firstVisit = false;

        ShowMessage(currentLocation.GetFullDescription());
    }


    private void ShowMessage(string message)
    {
        textOut.text += "\n" + message;
        
        // extra lines so we can see all the output
        textOut.text += "\n\n\n";

    }
    
    

}
