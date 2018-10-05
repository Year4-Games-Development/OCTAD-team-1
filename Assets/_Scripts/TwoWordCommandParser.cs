using System.Collections;
using System.Collections.Generic;
using UnityScript.Steps;

public class TwoWordCommandParser
{
 

    public CommandNounPair Parse(string word1, string word2)
    {
        CommandNounPair commandNounPair = new CommandNounPair();

        //        string[] words = sentence.Split(' ');

        commandNounPair.command = ParseCommand(word1);
        commandNounPair.noun = ParseNoun(word2);

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

        }
    return Util.Noun.Unknown;
    }

    public Util.Command ParseCommand(string t)
    {
        switch (t)
        {
            case "pickup":
                return Util.Command.Pickup;

            case "help":
                return Util.Command.Help;

            case "quit":
                return Util.Command.Quit;

        }
        return Util.Command.Unknown;
    }
    
}

