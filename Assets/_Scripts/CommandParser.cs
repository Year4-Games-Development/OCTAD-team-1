using System.Collections;
using System.Collections.Generic;
using UnityScript.Steps;

public class CommandParser
{
    public enum Command
    {
        Quit,
        Help,
        Unknown
    }

    public Command Parse(string userText)
    {
        /*
         * NORMALISATION OF TEXT
         * @TODO convert text into LOWER CASE
         * @TODO trim spaces from beginning / end of text
         * @TODO replace multiple spaces inside text with a SINGLE space - then can split with ' '
         */
        
        switch (userText)
        {
            case "help":
                return Command.Help;
            case "quit":
                return Command.Quit;
            
        }
        return Command.Unknown;
    }
    
}
