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
        commandParser = new CommandParser();
        player = new Player();
        map = new Map(player);
    }

    private void Start()
    {
        ShowMessage("Loading game map ....");
        ChangeLocation(map.GetStartLocation());
        ShowMessage("" + player.GetStatus());
    }

    public void ProcessInput(string userText)
    {
        ShowMessage("------------------------------------------------------------");

        // add user text to output history
        string userTextColored = "\n " + Util.ColorText("> " + userText, "#529694");
        ShowMessage(userTextColored);

        // get command Type from text
        CommandAndOtherWords commandNounPair = commandParser.Parse(userText);

        Util.Command command = commandNounPair.command;

        switch (commandNounPair.numWords)
        {
            case 1:
                // process that command
                ProcessSingleWordUserCommand(command, userText);
                break;

            case 2:
            default:
                // process that command
                ProcessMultiWordUserCommand(commandNounPair, userText);
                break;
        }

        // set input field with Focus - ready for next user input
        textIn.Select();
        textIn.ActivateInputField();
    }

    private void ProcessMultiWordUserCommand(CommandAndOtherWords commandNounPair, string userText)
    {
        Util.Command command = commandNounPair.command;
        Util.Noun noun = commandNounPair.noun;
        // Debug.Log(command.ToString());
        // Debug.Log(noun.ToString());

        string message = "";
        switch (command)
        {
            case Util.Command.Use:
                string itemName = userText.Split(' ')[1];
                Item item = player.inventory.GetItem(itemName);
                if (item != null)
                {
                    message = "You use " + item.Name;
                    message += "\r\n"+item.use();
                    if (currentLocation.monster != null && !currentLocation.monster.amIDead())
					{
						player.receiveDommage(currentLocation.monster.getAttackPoint());
					}
                    break;
                }
                message = "You do not posess that item";
                break;

            case Util.Command.Pick:
                switch (noun)
                {
                    case Util.Noun.Up:
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
                            Debug.Log(pickedup.Name);
                            player.addItem(pickedup);
                            message = "You picked up " + pickedup.Name;
                        }

                        break;
                }
                break;            
            case Util.Command.Unknown:
            default:
                message = Util.Message(Util.Type.Unknown);
                break;
        }

        ShowMessage(message);
    }

    private void ProcessSingleWordUserCommand(Util.Command c, string userText)
    {
        string message;
        switch (c)
        {

            // case Util.Command.Status:

            //     message = player.GetStatus();
            //     break;

            // case Util.Command.Todo_List:

            //     Item item = player.inventory.GetItem("todo list");
            //     if(item != null)
            //     { 
            //         message = "Current tasks: " + map.ship.GetStatus();
            //     } else
            //         message = "You do not posess that item";
            //     break;
            case Util.Command.Pickup:
                message = "error";
                if (currentLocation.pickupables.Count == 0)
                {
                    message = "There nothing to be picked up.";
                    break;
                }
                message = "You picked up :";
                while (currentLocation.pickupables.Count != 0)
                {

                    Item pickedup = currentLocation.pickupables[currentLocation.pickupables.Count - 1];
                    currentLocation.pickupables.RemoveAt(currentLocation.pickupables.Count - 1);
                    Debug.Log(pickedup.Name);
                    player.addItem(pickedup);
                    message += "\r\n\t" + pickedup.Name;
                }

                break;
            case Util.Command.Quit:
                message = "user wants to QUIT";
                break;
            case Util.Command.Look:
                    message = currentLocation.GetDescription();
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
            case Util.Command.Status:
                message = player.GetStatus();
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

            case Util.Command.Retry:
                message = "New Game started";
                Application.LoadLevel(Application.loadedLevel);
                break;
            case Util.Command.Talk:
                if (currentLocation.npc == null)
                {
                    message = "There is nobody...";
                }
                else
                {
                    NPC currentNPC = currentLocation.npc;
                    message = "You talk to " + currentNPC.name + "\r\n" + currentNPC.GetFullIntro();
                }
                break;
            case Util.Command.Quests:
                if (player.quests.Count <= 0)
                    message = "You have no quest.";
                else
                {
                    message = "Currents quests :";
                    for(int i = 0; i < player.quests.Count; i++)
                    {
                        message += "\r\n Quest #" + i + " :"
                            + "\r\n\t" + player.quests[i].Description;
                    }
                }
                break;
            case Util.Command.Attack:
                if (currentLocation.monster.amIDead())
                {
                    message = currentLocation.monster.getName() + " is already dead !";
                    break;
                }
                else
                {
                    currentLocation.monster.receiveDommage(player.AttackPoint); //TODO take into account the attack bonus linked to an item in the inventory 
                    if (!currentLocation.monster.amIDead())
                    {
                        player.receiveDommage(currentLocation.monster.getAttackPoint());
                        if (!player.isDead())
                        {
                            message = "You still have : " + player.GetStatus() + " and the " + currentLocation.monster.getName() + " still have : " + currentLocation.monster.getFeature();
                        }
                        else
                        {
                            message = "Oh God you are Dead !";
                            //TODO 
                            //game over management
                        }
                    }
                    else
                    {
                        message = currentLocation.monster.getName() + " is dead, you win this figth !";
                    }
                }
                break;
            // case Util.Command.Watch:
            //     if(currentLocation.GetName().Equals("In Ship"))
            //     {
            //         message = " There is no monster inside your ship ";
            //     }
            //     else
            //     {
            //         if (!currentLocation.monster.amIDead())
            //         {
            //             message = " You face " + currentLocation.monster.getName() + " and he has : " + currentLocation.monster.getFeature();
            //         }
            //         else
            //         {
            //             message = currentLocation.monster.getName() + " is dead !";
            //         }
            //     }
            //     break;
            case Util.Command.Unknown:
            default:
                if (currentLocation.npc != null)                
                {
                    NPC currentNPC = currentLocation.npc;
                    message = currentNPC.dialog(userText, player);
                    if(!message.Equals(""))
                        break;
                }

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
        if (previousLocation != null)
        {
            previousLocation.firstVisit = false;
            player.OxygenTickDown(0.05f);
            if(player.isDead())
            {
                ShowMessage("GAME OVER. You are dead" + "\n type 'retry' to start again");     
                Debug.Log("" + player.GetOxygenLevel());        
            }
        }
        if(!player.isDead())
        {
            if (currentLocation.name == "In Ship" && previousLocation != null)
            {
                player.ReplenishOxygen();
                ShowMessage(Util.ColorTextPositive("Oxygen Replenished"));
            }
            ShowMessage(currentLocation.GetFullDescription());
        }
    }


    private void ShowMessage(string message)
    {
        textOut.text += "\n" + message;

        // extra lines so we can see all the output
        textOut.text += "\n";

    }



}
