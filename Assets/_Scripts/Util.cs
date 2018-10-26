using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{
	public enum Type
	{
		Start,
		Help,
		Unknown,
		North,
		South,
		East,
		West
	}
	
	public enum Command
	{
		Quit,
		Help,
		Look,
		North,
		South,
		East,
		West,
		Pickup,
		Drop,
		Inventory,
		Use,
		Read,
		Pick,
		// Todo_List,
		// Status,
		Retry,
        Talk,
        Attack,
        Status,
        Watch, //display the characteristics of the monster 
        Quests,
		Unknown        
	}
	
	public enum Noun
	{
		Door,
		Key,
		Unknown,
		Up,
		Todo_List
        
	}

	public static string Message(Type t)
	{
		switch (t)
		{
			case Type.Unknown:
				return "UNKNOWN command - please write something I understand";
			
			case Type.Help:
				return "Help:" +
						"\n    - Quit: give up" +
						"\n    - Help: see this help text" +
   						"\n    - Look: describe your current location"+
   						"\n    - Inventory: show your current inventory"+
   						"\n    - Talk: talk with NPC"+
   						"\n    - Attack: attack the monster" +
   						"\n    - Status: show your current characteristics"+
   						"\n    - Watch: displays all the NPC and Monster present in the current location and their characteristics"+
   						"\n    - Use: use a object in your inventory"+
   						"\n    - Quests: show your current quests"+
   						"\n    - Pickup: add a object in your inventory";

			default:
				/*
				 * TODO: Generate some kind of error event ??
				 */
				return "";				
		}

	}


	public static string ColorText(string t, string color)
	{
		return "<color=" + color + ">" + t + "</color>";
	}

	public static string ColorTextImportant(string t)
	{
		return "<color=#A569BD>" + t + "</color>";
	}

	public static string ColorTextInteractible(string t)
	{
		return "<color=#D2B4DE>" + t + "</color>";

	}

	public static string ColorTextPositive(string t)
	{
		return "<color=Green>" + t + "</color>";
	}
}
