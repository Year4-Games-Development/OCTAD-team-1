using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityScript.Steps;

public class CommandParser
{
    public CommandAndOtherWords Parse(string userText) 
    {      
        userText = userText.ToLower();
        string[] words = userText.Split(' ');
        string word1 = words[0];

        CommandAndOtherWords commandNounPair = new CommandAndOtherWords();

        commandNounPair.command = ParseCommand(word1);

        
        // was there a second word?
        if (words.Length > 1)
        {
            string word2 = words[1];
            commandNounPair.noun = ParseNoun(word2);
            commandNounPair.numWords = words.Length;
        }

        return commandNounPair;

    }


    public Util.Noun ParseNoun(string word)
    {
        switch (word)
        {
            case "door":
                return Util.Noun.Door;

            case "key":
                return Util.Noun.Key;
            case "list":
                return Util.Noun.List;

        }
        return Util.Noun.Unknown;
    }

    public Util.Command ParseCommand(string word)
    {
  
        
        /*
         * NORMALISATION OF TEXT
         * @TODO convert text into LOWER CASE //complete besides testing
         * @TODO trim spaces from beginning / end of text
         * @TODO replace multiple spaces inside text with a SINGLE space - then can split with ' '
         */
        
        switch (word)
        {
            case "help":
                return Util.Command.Help;
            case "look":
                return Util.Command.Look;
            case "quit":
                return Util.Command.Quit;
            case "north":
                return Util.Command.North;
            case "n":
                return Util.Command.North;
            case "south":
                return Util.Command.South;
            case "s":
                return Util.Command.South;
            case "east":
                return Util.Command.East;
            case "e":
                return Util.Command.East;
            case "west":
                return Util.Command.West;
            case "w":
                return Util.Command.West;
            case "inventory": 
                return Util.Command.Inventory;
            case "pickup":
                return Util.Command.Pickup;
            case "use":
                return Util.Command.Use;
            case "read":
                return Util.Command.Read;  
            case "todo":
                return Util.Command.Todo_List;
            
        }
        return Util.Command.Unknown;
    }

    
}
