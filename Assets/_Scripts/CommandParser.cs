using System;
using System.Collections;
using System.Collections.Generic;
using UnityScript.Steps;

public class CommandParser
{


    public Util.Command Parse(string userText)
    {

        userText = userText.ToLower();
        
        /*
         * NORMALISATION OF TEXT
         * @TODO convert text into LOWER CASE //complete besides testing
         * @TODO trim spaces from beginning / end of text
         * @TODO replace multiple spaces inside text with a SINGLE space - then can split with ' '
         */
        
        switch (userText)
        {
            case "help":
                return Util.Command.Help;
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
            
        }
        return Util.Command.Unknown;
    }
    
}
