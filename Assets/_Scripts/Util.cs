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
   						"\n    - Look: describe your current location";

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
}
