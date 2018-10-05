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
		North,
		South,
		East,
		West,
		Pickup,
		Drop,
		Unknown        
	}
	
	public enum Noun
	{
		Door,
		Key,
		Unknown
        
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
				       "\n    - Help: see this help text";
			
			case Type.Start:
				return "OCTAD: Your Octad spaceship has crashed!" +
				       "\n    - try not to die" +
				       "\n    - hint: oxygen is a handy thing when you're on a non-Earth-like planet";

			case Type.North:
				return "You Have Chosen to go north";

			case Type.South:
				return "You Have Chosen to go south";

			case Type.East:
				return "You Have Chosen to go east";

			case Type.West:
				return "You Have Chosen to go west";
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
}
