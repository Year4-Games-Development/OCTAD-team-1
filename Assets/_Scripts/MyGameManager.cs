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
    private Player player;

    private Map map;

    private Location currentLocation;
    private Location previousLocation;
    private NPC currentNPC;

    void Awake()
    {
        map = new Map();
        commandParser = new CommandParser();
        player = new Player();
    }

    private void Start()
    {
        ShowMessage("Loading game map ....");
        ChangeLocation(map.GetStartLocation());
    }

    public void ProcessInput(string userText)
    {
        // add user text to output history
        string userTextColored = "\n >" + Util.ColorText(userText, "red");
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
        switch (c)
        {
            case Util.Command.Pickup:
                message = "error";
                if (currentLocation.pickupables.Count == 0)
                {
                    message = "There nothing to be picked up.";
                    break;
                }
                while (currentLocation.pickupables.Count != 0)
                {
                    
                    Item pickedup = currentLocation.pickupables[currentLocation.pickupables.Count - 1];
                    currentLocation.pickupables.RemoveAt(currentLocation.pickupables.Count - 1);
                    player.addItem(pickedup);
                    message = "You picked up " + pickedup.name;
                }               
                break;
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
            case Util.Command.Inventory:

                message = "" + player.inventory.ShowInventory();

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

        //This eliminates firstVisit being set to false while you are still "in" that location
        previousLocation = currentLocation;
        currentLocation = newLocation;
        ShowMessage(currentLocation.GetFullDescription());
        if(previousLocation != null) 
        {
            previousLocation.firstVisit = false;
        }
    }


    private void ShowMessage(string message)
    {
        textOut.text += "\n" + message;

        // extra lines so we can see all the output
        textOut.text += "\n\n\n";

    }



}
